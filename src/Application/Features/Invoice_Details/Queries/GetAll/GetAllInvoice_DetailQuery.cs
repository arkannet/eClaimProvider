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

namespace eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll
{
    public class GetAllInvoice_DetailQuery : IRequest<Result<List<GetAllInvoice_DetailResponse>>>
    {
        public GetAllInvoice_DetailQuery()
        {
        }
    }

    internal class GetAllInvoice_DetailCachedQueryHandler : IRequestHandler<GetAllInvoice_DetailQuery, Result<List<GetAllInvoice_DetailResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllInvoice_DetailCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllInvoice_DetailResponse>>> Handle(GetAllInvoice_DetailQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Invoice_Detail>>> getAllclaim_form = () => _unitOfWork.Invoice_Details.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllInvoice_DetailCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllInvoice_DetailResponse>>(claim_formList);
            return await Result<List<GetAllInvoice_DetailResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}