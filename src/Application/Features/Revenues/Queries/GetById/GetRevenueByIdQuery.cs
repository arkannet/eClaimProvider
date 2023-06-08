using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.Revenues.Queries.GetById
{
    public class GetRevenueByIdQuery : IRequest<Result<GetRevenueByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetRevenueByIdQueryHandler : IRequestHandler<GetRevenueByIdQuery, Result<GetRevenueByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRevenueByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetRevenueByIdResponse>> Handle(GetRevenueByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.Revenues.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetRevenueByIdResponse>(claim_form);
            return await Result<GetRevenueByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}