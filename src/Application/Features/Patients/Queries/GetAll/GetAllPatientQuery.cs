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

namespace eClaimProvider.Application.Features.Patients.Queries.GetAll
{
    public class GetAllPatientQuery : IRequest<Result<List<GetAllPatientResponse>>>
    {
        public GetAllPatientQuery()
        {
        }
    }

    internal class GetAllPatientCachedQueryHandler : IRequestHandler<GetAllPatientQuery, Result<List<GetAllPatientResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllPatientCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllPatientResponse>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Patient>>> getAllBrands = () => _unitOfWork.Patients.GetAllAsync();
            var service_invoiceList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllPatientCacheKey, getAllBrands);
            var mappedservice_invoice = _mapper.Map<List<GetAllPatientResponse>>(service_invoiceList);
            return await Result<List<GetAllPatientResponse>>.SuccessAsync(mappedservice_invoice);
        }
    }
}