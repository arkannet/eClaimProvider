using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Results.Commands.Delete
{
    public class DeleteResultCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteResultCommandHandler : IRequestHandler<DeleteResultCommand, Result<int>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteResultCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteResultCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteResultCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteResultCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.Id);
            //if (!isBrandUsed)
            //{
                var claim_form = await _unitOfWork.Repository<Domain.Entities.Catalog.Result>().GetByIdAsync(command.Id);
                if (claim_form != null)
                {
                    await _unitOfWork.Repository<Domain.Entities.Catalog.Result>().DeleteAsync(claim_form);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllResultCacheKey);
                    return await Result<int>.SuccessAsync(claim_form.Id, _localizer["Result Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Result Not Found!"]);
                }
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}