using AutoMapper;
using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetById;

namespace eClaimProvider.Application.Features.Patients.Queries.GetById
{
    public class GetPatientByIdQuery : IRequest<Result<GetPatientByIdResponse>>
    {
        public string Id { get; set; }
    }

    internal class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<GetPatientByIdResponse>>
    {
        private readonly IDapperUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientByIdQueryHandler(IDapperUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetPatientByIdResponse>> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
        {
            var service_invoice = await _unitOfWork.Patients.GetByIdAsync(query.Id);
            var mappedservice_invoice = _mapper.Map<GetPatientByIdResponse>(service_invoice);
            return await Result<GetPatientByIdResponse>.SuccessAsync(mappedservice_invoice);
        }
    }
}