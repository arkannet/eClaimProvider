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

namespace eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll
{
    public class GetAllInvoice_SubDetailQuery : IRequest<Result<List<GetAllInvoice_SubDetailResponse>>>
    {
        public GetAllInvoice_SubDetailQuery()
        {
        }
    }

    internal class GetAllInvoice_SubDetailCachedQueryHandler : IRequestHandler<GetAllInvoice_SubDetailQuery, Result<List<GetAllInvoice_SubDetailResponse>>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllInvoice_SubDetailCachedQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllInvoice_SubDetailResponse>>> Handle(GetAllInvoice_SubDetailQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Invoice_SubDetail>>> getAllclaim_form = () => _unitOfWork.Invoice_SubDetails.GetAllAsync();
            var claim_formList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllInvoice_SubDetailCacheKey, getAllclaim_form);
            var mappedclaim_form = _mapper.Map<List<GetAllInvoice_SubDetailResponse>>(claim_formList);
            return await Result<List<GetAllInvoice_SubDetailResponse>>.SuccessAsync(mappedclaim_form);
        }
    }
}