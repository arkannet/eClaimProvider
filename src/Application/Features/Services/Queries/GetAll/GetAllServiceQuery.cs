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

namespace eClaimProvider.Application.Features.Services.Queries.GetAll
{
    public class GetAllServiceQuery : IRequest<Result<List<GetAllServiceResponse>>>
    {
        public GetAllServiceQuery()
        {
        }
    }

    internal class GetAllServiceCachedQueryHandler : IRequestHandler<GetAllServiceQuery, Result<List<GetAllServiceResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllServiceCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllServiceResponse>>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Service>>> getAllBrands = () => _unitOfWork.Services.GetAllAsync();
            var service_invoiceList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllServiceCacheKey, getAllBrands);
            var mappedservice_invoice = _mapper.Map<List<GetAllServiceResponse>>(service_invoiceList);
            return await Result<List<GetAllServiceResponse>>.SuccessAsync(mappedservice_invoice);
        }
    }
}