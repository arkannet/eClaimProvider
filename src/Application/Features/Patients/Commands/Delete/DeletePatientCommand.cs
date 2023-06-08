using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Patients.Commands.Delete
{
    public class DeletePatientCommand : IRequest<Result<string>>
    {
        public string Id { get; set; }
    }

    internal class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Result<string>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeletePatientCommandHandler> _localizer;
        private readonly IUnitOfWork<string> _unitOfWork;

        public DeletePatientCommandHandler(IUnitOfWork<string> unitOfWork,   IStringLocalizer<DeletePatientCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.ServiceId);
            //if (!isBrandUsed)
            //{
                var service_invoice = await _unitOfWork.Repository<Patient>().GetByIdAsync(command.Id);
                if (service_invoice != null)
                {
                    await _unitOfWork.Repository<Patient>().DeleteAsync(service_invoice);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllPatientCacheKey);
                    return await Result<string>.SuccessAsync(service_invoice.Id, _localizer["Patients Deleted"]);
                }
                else
                {
                    return await Result<string>.FailAsync(_localizer["Patients Not Found!"]);
                }
            //}
            //else
            //{ Invoice
            //    return await Result<string>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}