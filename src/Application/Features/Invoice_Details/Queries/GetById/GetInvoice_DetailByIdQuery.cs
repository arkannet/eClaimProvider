using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.Invoice_Details.Queries.GetById
{
    public class GetInvoice_DetailByIdQuery : IRequest<Result<GetInvoice_DetailByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetInvoice_DetailByIdQueryHandler : IRequestHandler<GetInvoice_DetailByIdQuery, Result<GetInvoice_DetailByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInvoice_DetailByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetInvoice_DetailByIdResponse>> Handle(GetInvoice_DetailByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.Invoice_Details.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetInvoice_DetailByIdResponse>(claim_form);
            return await Result<GetInvoice_DetailByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}