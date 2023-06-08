using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.Results.Queries.GetById
{
    public class GetResultByIdQuery : IRequest<Result<GetResultByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetResultByIdQueryHandler : IRequestHandler<GetResultByIdQuery, Result<GetResultByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetResultByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetResultByIdResponse>> Handle(GetResultByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.Results.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetResultByIdResponse>(claim_form);
            return await Result<GetResultByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}