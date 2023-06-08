using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Revenues.Commands.Delete
{
    public class DeleteRevenueCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteRevenueCommandHandler : IRequestHandler<DeleteRevenueCommand, Result<int>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteRevenueCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteRevenueCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteRevenueCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteRevenueCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.Id);
            //if (!isBrandUsed)
            //{
                var claim_form = await _unitOfWork.Repository<Revenue>().GetByIdAsync(command.Id);
                if (claim_form != null)
                {
                    await _unitOfWork.Repository<Revenue>().DeleteAsync(claim_form);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllRevenueCacheKey);
                    return await Result<int>.SuccessAsync(claim_form.Id, _localizer["Revenue Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Revenue Not Found!"]);
                }
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}