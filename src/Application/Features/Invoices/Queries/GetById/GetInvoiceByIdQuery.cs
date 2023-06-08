using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetById;

namespace eClaimProvider.Application.Features.Invoices.Queries.GetById
{
    public class GetInvoiceByIdQuery : IRequest<Result<GetInvoiceByIdResponse>>
    {
        public string Id { get; set; }
    }

    internal class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Result<GetInvoiceByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetInvoiceByIdResponse>> Handle(GetInvoiceByIdQuery query, CancellationToken cancellationToken)
        {
            var service_invoice = await _unitOfWork.Invoices.GetByIdAsync(query.Id);
            var mappedservice_invoice = _mapper.Map<GetInvoiceByIdResponse>(service_invoice);
            return await Result<GetInvoiceByIdResponse>.SuccessAsync(mappedservice_invoice);
        }
    }
}