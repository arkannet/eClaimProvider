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

namespace eClaimProvider.Application.Features.REJECTEDs.Commands.AddEdit
{
    public partial class AddEditREJECTEDCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int Invoice_DetailId { get; set; }
        public string Comment { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditREJECTEDCommandHandler : IRequestHandler<AddEditREJECTEDCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditREJECTEDCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditREJECTEDCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditREJECTEDCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditREJECTEDCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<REJECTED>(command);
                await _unitOfWork.Repository<REJECTED>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllREJECTEDCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["REJECTED Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<REJECTED>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.Invoice_DetailId = command.Invoice_DetailId;
                    claim.Comment = command.Comment ?? claim.Comment;
  

                    await _unitOfWork.Repository<REJECTED>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllREJECTEDCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["REJECTED Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["REJECTED Not Found!"]);
                }
            }
        }
    }
}