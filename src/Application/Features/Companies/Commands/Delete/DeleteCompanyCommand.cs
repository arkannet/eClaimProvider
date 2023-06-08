using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using eClaimProvider.Shared.Constants.Application;

namespace eClaimProvider.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Result<int>>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IStringLocalizer<DeleteCompanyCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteCompanyCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            //_productRepository = productRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            //var isBrandUsed = await _productRepository.IsBrandUsed(command.Id);
            //if (!isBrandUsed)
            //{
                var claim_form = await _unitOfWork.Repository<Company>().GetByIdAsync(command.Id);
                if (claim_form != null)
                {
                    await _unitOfWork.Repository<Company>().DeleteAsync(claim_form);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCompanyCacheKey);
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