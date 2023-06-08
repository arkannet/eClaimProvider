using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Invoice_Details.Commands.Delete
{
    public class DeleteInvoice_DetailCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteInvoice_DetailCommandHandler : IRequestHandler<DeleteInvoice_DetailCommand, Result<int>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteInvoice_DetailCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteInvoice_DetailCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteInvoice_DetailCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteInvoice_DetailCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.Id);
            //if (!isBrandUsed)
            //{
                var claim_form = await _unitOfWork.Repository<Invoice_Detail>().GetByIdAsync(command.Id);
                if (claim_form != null)
                {
                    await _unitOfWork.Repository<Invoice_Detail>().DeleteAsync(claim_form);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoice_DetailCacheKey);
                    return await Result<int>.SuccessAsync(claim_form.Id, _localizer["Invoice_Detail Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Invoice_Detail Not Found!"]);
                }
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}