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

namespace eClaimProvider.Application.Features.REJECTEDs.Queries.GetAll
{
    public class GetAllREJECTEDQuery : IRequest<Result<List<GetAllREJECTEDResponse>>>
    {
        public GetAllREJECTEDQuery()
        {
        }
    }

    internal class GetAllREJECTEDCachedQueryHandler : IRequestHandler<GetAllREJECTEDQuery, Result<List<GetAllREJECTEDResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllREJECTEDCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllREJECTEDResponse>>> Handle(GetAllREJECTEDQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<REJECTED>>> getAllclaim_form = () => _unitOfWork.REJECTEDs.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllREJECTEDCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllREJECTEDResponse>>(claim_formList);
            return await Result<List<GetAllREJECTEDResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}