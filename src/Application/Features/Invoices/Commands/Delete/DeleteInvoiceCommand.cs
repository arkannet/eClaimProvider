using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Invoices.Commands.Delete
{
    public class DeleteInvoiceCommand : IRequest<Result<string>>
    {
        public string Id { get; set; }
    }

    internal class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Result<string>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteInvoiceCommandHandler> _localizer;
        private readonly IUnitOfWork<string> _unitOfWork;

        public DeleteInvoiceCommandHandler(IUnitOfWork<string> unitOfWork,   IStringLocalizer<DeleteInvoiceCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(DeleteInvoiceCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.ServiceId);
            //if (!isBrandUsed)
            //{
                var service_invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(command.Id);
                if (service_invoice != null)
                {
                    await _unitOfWork.Repository<Invoice>().DeleteAsync(service_invoice);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllInvoiceCacheKey);
                    return await Result<string>.SuccessAsync(service_invoice.Id, _localizer["Invoices Deleted"]);
                }
                else
                {
                    return await Result<string>.FailAsync(_localizer["Invoices Not Found!"]);
                }
            //}
            //else
            //{ Invoice
            //    return await Result<string>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}