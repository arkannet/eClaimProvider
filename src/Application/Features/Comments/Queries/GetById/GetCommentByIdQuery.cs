using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.Comments.Queries.GetById
{
    public class GetCommentByIdQuery : IRequest<Result<GetCommentByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Result<GetCommentByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCommentByIdResponse>> Handle(GetCommentByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.Comments.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetCommentByIdResponse>(claim_form);
            return await Result<GetCommentByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}