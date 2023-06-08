using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Services.Commands.Delete
{
    public class DeleteServiceCommand : IRequest<Result<string>>
    {
        public string Id { get; set; }
    }

    internal class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Result<string>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteServiceCommandHandler> _localizer;
        private readonly IUnitOfWork<string> _unitOfWork;

        public DeleteServiceCommandHandler(IUnitOfWork<string> unitOfWork,   IStringLocalizer<DeleteServiceCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(DeleteServiceCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.ServiceId);
            //if (!isBrandUsed)
            //{
                var service_invoice = await _unitOfWork.Repository<Service>().GetByIdAsync(command.Id);
                if (service_invoice != null)
                {
                    await _unitOfWork.Repository<Service>().DeleteAsync(service_invoice);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllServiceCacheKey);
                    return await Result<string>.SuccessAsync(service_invoice.Id, _localizer["Service Deleted"]);
                }
                else
                {
                    return await Result<string>.FailAsync(_localizer["Service Not Found!"]);
                }
            //}
            //else
            //{ Invoice
            //    return await Result<string>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}