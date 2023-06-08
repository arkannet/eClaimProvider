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

namespace eClaimProvider.Application.Features.Companies.Queries.GetAll
{
    public class GetAllCompanyQuery : IRequest<Result<List<GetAllCompanyResponse>>>
    {
        public GetAllCompanyQuery()
        {
        }
    }

    internal class GetAllCompanyCachedQueryHandler : IRequestHandler<GetAllCompanyQuery, Result<List<GetAllCompanyResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCompanyCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCompanyResponse>>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Company>>> getAllclaim_form = () => _unitOfWork.Companies.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCompanyCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllCompanyResponse>>(claim_formList);
            return await Result<List<GetAllCompanyResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}