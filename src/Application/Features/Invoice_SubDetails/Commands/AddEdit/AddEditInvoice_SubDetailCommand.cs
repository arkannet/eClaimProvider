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

namespace eClaimProvider.Application.Features.Invoice_SubDetails.Commands.AddEdit
{
    public partial class AddEditInvoice_SubDetailCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string Comment { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditInvoice_SubDetailCommandHandler : IRequestHandler<AddEditInvoice_SubDetailCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditInvoice_SubDetailCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditInvoice_SubDetailCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditInvoice_SubDetailCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditInvoice_SubDetailCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<Invoice_SubDetail>(command);
                await _unitOfWork.Repository<Invoice_SubDetail>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoice_SubDetailCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["Invoice_SubDetail Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<Invoice_SubDetail>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.DetailId = command.DetailId;
                    claim.Comment = command.Comment ?? claim.Comment;
                   
                   
  

                    await _unitOfWork.Repository<Invoice_SubDetail>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoice_SubDetailCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["Invoice_SubDetail Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Invoice_SubDetail Not Found!"]);
                }
            }
        }
    }
}