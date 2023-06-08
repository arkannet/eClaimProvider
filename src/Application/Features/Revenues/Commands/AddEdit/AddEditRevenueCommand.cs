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

namespace eClaimProvider.Application.Features.Revenues.Commands.AddEdit
{
    public partial class AddEditRevenueCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        //public UploadRequest UploadRequest { get; set; }

    }

    internal class AddEditRevenueCommandHandler : IRequestHandler<AddEditRevenueCommand, Result<int>>
    {
        //private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditRevenueCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditRevenueCommandHandler(IUnitOfWork<int> unitOfWork, IUploadService uploadService, IMapper mapper, IStringLocalizer<AddEditRevenueCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditRevenueCommand command, CancellationToken cancellationToken)
        {
            //var uploadRequest = command.UploadRequest;
            if (command.Id == 0)
            {
                var claim = _mapper.Map<Revenue>(command);
                await _unitOfWork.Repository<Revenue>().AddAsync(claim);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllRevenueCacheKey);
                return await Result<int>.SuccessAsync(claim.Id, _localizer["Revenue Saved"]);
            }
            else
            {
                var claim = await _unitOfWork.Repository<Revenue>().GetByIdAsync(command.Id);
                if (claim != null)
                {


                    claim.CompanyId = command.CompanyId;
                    claim.Comment = command.Comment ?? claim.Comment;


                    claim.Active = command.Active;
                    claim.Deleted = command.Deleted;

                    await _unitOfWork.Repository<Revenue>().UpdateAsync(claim);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllRevenueCacheKey);
                    return await Result<int>.SuccessAsync(claim.Id, _localizer["Revenue Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Revenue Not Found!"]);
                }
            }
        }
    }
}