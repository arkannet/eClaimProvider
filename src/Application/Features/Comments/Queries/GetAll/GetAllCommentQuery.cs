using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Constants.Application;
using eClaimProvider.Shared.Wrapper;
using LazyCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eClaimProvider.Application.Features.Comments.Queries.GetAll
{
    public class GetAllCommentQuery : IRequest<Result<List<GetAllCommentResponse>>>
    {
        public GetAllCommentQuery()
        {
        }
    }

    internal class GetAllCommentCachedQueryHandler : IRequestHandler<GetAllCommentQuery, Result<List<GetAllCommentResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCommentCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCommentResponse>>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<InvoiceComment>>> getAllclaim_form = () => _unitOfWork.Comments.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCommentCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllCommentResponse>>(claim_formList);
            return await Result<List<GetAllCommentResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}