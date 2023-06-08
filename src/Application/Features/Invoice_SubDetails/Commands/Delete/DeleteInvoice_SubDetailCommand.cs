using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Invoice_SubDetails.Commands.Delete
{
    public class DeleteInvoice_SubDetailCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteInvoice_SubDetailCommandHandler : IRequestHandler<DeleteInvoice_SubDetailCommand, Result<int>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteInvoice_SubDetailCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteInvoice_SubDetailCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteInvoice_SubDetailCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteInvoice_SubDetailCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.Id);
            //if (!isBrandUsed)
            //{
                var claim_form = await _unitOfWork.Repository<Invoice_SubDetail>().GetByIdAsync(command.Id);
                if (claim_form != null)
                {
                    await _unitOfWork.Repository<Invoice_SubDetail>().DeleteAsync(claim_form);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoice_SubDetailCacheKey);
                    return await Result<int>.SuccessAsync(claim_form.Id, _localizer["Invoice_SubDetail Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Invoice_SubDetail Not Found!"]);
                }
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}