using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.REJECTEDs.Queries.GetById
{
    public class GetREJECTEDByIdQuery : IRequest<Result<GetREJECTEDByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetREJECTEDByIdQueryHandler : IRequestHandler<GetREJECTEDByIdQuery, Result<GetREJECTEDByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetREJECTEDByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetREJECTEDByIdResponse>> Handle(GetREJECTEDByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.REJECTEDs.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetREJECTEDByIdResponse>(claim_form);
            return await Result<GetREJECTEDByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}