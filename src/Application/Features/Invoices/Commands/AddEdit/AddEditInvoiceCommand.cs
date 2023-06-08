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
using System;
using eClaimProvider.Application.Interfaces.Services;
using eClaimProvider.Application.Requests;

namespace eClaimProvider.Application.Features.Invoices.Commands.AddEdit
{
    public partial class AddEditInvoiceCommand : IRequest<Result<string >>
    {


        
        public string Id { get; set; }
        public string PatientId { get; set; }
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public int Stat { get; set; }
        public DateTime DoneDate { get; set; }
        public bool Moved { get; set; }
        public DateTime Movedon { get; set; }
        public string Isrealted { get; set; }
        public int suspended { get; set; }
        public bool Cards { get; set; }
        public string Policy_Insu_no { get; set; }


        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditInvoiceCommandHandler : IRequestHandler<AddEditInvoiceCommand, Result<string >>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditInvoiceCommandHandler> _localizer;
        private readonly IUnitOfWork<string > _unitOfWork;

        public AddEditInvoiceCommandHandler(IUnitOfWork<string> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditInvoiceCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<string >> Handle(AddEditInvoiceCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            //if (command.Id == null)
            //{

            //}
            //else
            {
                var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(command.Id);
                if (invoice != null)
                {

                    invoice.PatientId = command.PatientId ?? invoice.PatientId;
                    invoice.ContractId = command.ContractId;
                    invoice.CompanyId=command.CompanyId;
                    invoice.Stat = command.Stat;
                    invoice.DoneDate = command.DoneDate;

                    invoice.Moved = command.Moved;
                    invoice.Movedon = command.Movedon;
                    invoice.suspended = command.suspended;
                    invoice.Cards = command.Cards;
                    invoice.Policy_Insu_no = command.Policy_Insu_no ?? invoice.Policy_Insu_no;
                    invoice.Isrealted = command.Isrealted;

                    await _unitOfWork.Repository<Invoice>().UpdateAsync(invoice);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoiceCacheKey);
                    return await Result<string>.SuccessAsync(invoice.Id, _localizer["Invoice Updated"]);
                }
                else
                {
                    var invoice1 = _mapper.Map<Invoice>(command);
                    await _unitOfWork.Repository<Invoice>().AddAsync(invoice1);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoiceCacheKey);
                    return await Result<string>.SuccessAsync(invoice1.Id, _localizer["Invoice Saved"]);
                }
            }
        }
    }
}// ?? patient.CategoryName;