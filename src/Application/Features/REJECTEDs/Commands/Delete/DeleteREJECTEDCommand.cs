using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.REJECTEDs.Commands.Delete
{
    public class DeleteREJECTEDCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteREJECTEDCommandHandler : IRequestHandler<DeleteREJECTEDCommand, Result<int>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteREJECTEDCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteREJECTEDCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteREJECTEDCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteREJECTEDCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.Id);
            //if (!isBrandUsed)
            //{
                var claim_form = await _unitOfWork.Repository<REJECTED>().GetByIdAsync(command.Id);
                if (claim_form != null)
                {
                    await _unitOfWork.Repository<REJECTED>().DeleteAsync(claim_form);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllREJECTEDCacheKey);
                    return await Result<int>.SuccessAsync(claim_form.Id, _localizer["Claim Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Claim_Form Not Found!"]);
                }
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}