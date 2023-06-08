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

namespace eClaimProvider.Application.Features.Revenues.Queries.GetAll
{
    public class GetAllRevenueQuery : IRequest<Result<List<GetAllRevenueResponse>>>
    {
        public GetAllRevenueQuery()
        {
        }
    }

    internal class GetAllRevenueCachedQueryHandler : IRequestHandler<GetAllRevenueQuery, Result<List<GetAllRevenueResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllRevenueCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllRevenueResponse>>> Handle(GetAllRevenueQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Revenue>>> getAllclaim_form = () => _unitOfWork.Revenues.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllRevenueCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllRevenueResponse>>(claim_formList);
            return await Result<List<GetAllRevenueResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}