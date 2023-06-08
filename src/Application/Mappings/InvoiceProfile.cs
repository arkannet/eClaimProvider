using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Queries.GetById;
using eClaimProvider.Domain.Entities.Catalog;

namespace eClaimProvider.Application.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<AddEditInvoiceCommand, Invoice>().ReverseMap();
            CreateMap<GetInvoiceByIdResponse, Invoice>().ReverseMap();
            CreateMap<GetAllInvoiceResponse, Invoice>().ReverseMap();
        }
    }
}//Invoice_SubDetail