using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.Companies.Queries.GetById
{
    public class GetCompanyByIdQuery : IRequest<Result<GetCompanyByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Result<GetCompanyByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCompanyByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCompanyByIdResponse>> Handle(GetCompanyByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.Companies.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetCompanyByIdResponse>(claim_form);
            return await Result<GetCompanyByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}