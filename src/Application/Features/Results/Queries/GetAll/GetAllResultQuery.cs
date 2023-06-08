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

namespace eClaimProvider.Application.Features.Results.Queries.GetAll
{
    public class GetAllResultQuery : IRequest<Result<List<GetAllResultResponse>>>
    {
        public GetAllResultQuery()
        {
        }
    }

    internal class GetAllResultCachedQueryHandler : IRequestHandler<GetAllResultQuery, Result<List<GetAllResultResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllResultCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllResultResponse>>> Handle(GetAllResultQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Domain.Entities.Catalog.Result>>> getAllclaim_form = () => _unitOfWork.Results.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllResultCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllResultResponse>>(claim_formList);
            return await Result<List<GetAllResultResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}