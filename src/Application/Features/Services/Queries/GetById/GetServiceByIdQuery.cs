using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Services.Queries.GetById;

namespace eClaimProvider.Application.Features.Services.Queries.GetById
{
    public class GetServiceByIdQuery : IRequest<Result<GetServiceByIdResponse>>
    {
        public string Id { get; set; }
    }

    internal class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Result<GetServiceByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetServiceByIdResponse>> Handle(GetServiceByIdQuery query, CancellationToken cancellationToken)
        {
            var service_invoice = await _unitOfWork.Invoices.GetByIdAsync(query.Id);
            var mappedservice_invoice = _mapper.Map<GetServiceByIdResponse>(service_invoice);
            return await Result<GetServiceByIdResponse>.SuccessAsync(mappedservice_invoice);
        }
    }
}