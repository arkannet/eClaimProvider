using System.ComponentModel.DataAnnotations;
using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;
using eClaimProvider;
using eClaimProvider.Application.Interfaces.Services;
using eClaimProvider.Application.Requests;
using System;

namespace eClaimProvider.Application.Features.Invoice_Details.Commands.AddEdit
{
    public partial class AddEditInvoice_DetailCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public string ServiceId { get; set; }
        public string Service_Name { get; set; }
        public string DrName { get; set; }
        public decimal Price { get; set; }
        public int Isurance_Ratio { get; set; }
        public DateTime ServiceDate { get; set; }
        public decimal Co_Cash { get; set; }
        public decimal P_Cash { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        public bool IsExamination { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditInvoice_DetailCommandHandler : IRequestHandler<AddEditInvoice_DetailCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditInvoice_DetailCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditInvoice_DetailCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditInvoice_DetailCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditInvoice_DetailCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<Invoice_Detail>(command);
                await _unitOfWork.Repository<Invoice_Detail>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoice_DetailCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["Company Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<Invoice_Detail>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.InvoiceId = command.InvoiceId ?? claim.InvoiceId;
                    claim.ServiceId = command.ServiceId ?? claim.ServiceId;

                    claim.Service_Name = command.Service_Name ?? claim.Service_Name;
                    claim.DrName = command.DrName ?? claim.DrName;
                    claim.IsExamination = command.IsExamination;
                    claim.Comment = command.Comment ?? claim.Comment;
                    claim.Price = command.Price;
                    claim.Isurance_Ratio = command.Isurance_Ratio;
                    claim.ServiceDate = command.ServiceDate;
                    claim.Co_Cash = command.Co_Cash;
                    claim.P_Cash = command.P_Cash;
                    claim.Qty = command.Qty;



                    //Invoice_Detail
                    await _unitOfWork.Repository<Invoice_Detail>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoice_DetailCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["Invoice_Detail Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Invoice_Detail Not Found!"]);
                }
            }
        }
    }
}