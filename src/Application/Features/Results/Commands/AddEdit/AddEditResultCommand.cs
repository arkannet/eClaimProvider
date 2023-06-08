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
using eClaimProvider.Domain.Entities.Catalog;

namespace eClaimProvider.Application.Features.Results.Commands.AddEdit
{
    public partial class AddEditResultCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int DetailId { get; set; }
        public string ResultDetails { get; set; }

        public string ServiceId { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditResultCommandHandler : IRequestHandler<AddEditResultCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditResultCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditResultCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditResultCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditResultCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<Domain.Entities.Catalog.Result>(command);
                await _unitOfWork.Repository<Domain.Entities.Catalog.Result>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllResultCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["Result Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<Domain.Entities.Catalog.Result>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.DetailId = command.DetailId;
                    claim.ResultDetails = command.ResultDetails ?? claim.ResultDetails;
                    claim.ServiceId = command.ServiceId ?? claim.ServiceId;

                    await _unitOfWork.Repository<Domain.Entities.Catalog.Result>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllResultCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["Result Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Result Not Found!"]);
                }
            }
        }
    }
}