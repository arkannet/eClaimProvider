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

namespace eClaimProvider.Application.Features.Invoices.Queries.GetAll
{
    public class GetAllInvoiceQuery : IRequest<Result<List<GetAllInvoiceResponse>>>
    {
        public GetAllInvoiceQuery()
        {
        }
    }

    internal class GetAllInvoiceCachedQueryHandler : IRequestHandler<GetAllInvoiceQuery, Result<List<GetAllInvoiceResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllInvoiceCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllInvoiceResponse>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Invoice>>> getAllBrands = () => _unitOfWork.Invoices.GetAllAsync();
            var service_invoiceList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllInvoiceCacheKey, getAllBrands);
            var mappedservice_invoice = _mapper.Map<List<GetAllInvoiceResponse>>(service_invoiceList);
            return await Result<List<GetAllInvoiceResponse>>.SuccessAsync(mappedservice_invoice);
        }
    }
}