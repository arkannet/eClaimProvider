using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Queries.GetById;

namespace eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetById
{
    public class GetInvoice_SubDetailByIdQuery : IRequest<Result<GetInvoice_SubDetailByIdResponse>>
    {
        public int Id { get; set; }
    }

    internal class GetInvoice_SubDetailByIdQueryHandler : IRequestHandler<GetInvoice_SubDetailByIdQuery, Result<GetInvoice_SubDetailByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInvoice_SubDetailByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetInvoice_SubDetailByIdResponse>> Handle(GetInvoice_SubDetailByIdQuery query, CancellationToken cancellationToken)
        {
            var claim_form = await _unitOfWork.Invoice_SubDetails.GetByIdAsync(query.Id);
            var mappedclaim_form = _mapper.Map<GetInvoice_SubDetailByIdResponse>(claim_form);
            return await Result<GetInvoice_SubDetailByIdResponse>.SuccessAsync(mappedclaim_form);
        }
    }
}