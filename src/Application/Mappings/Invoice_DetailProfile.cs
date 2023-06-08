using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Invoice_SubDetails.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetById;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll;
using eClaimProvider.Application.Features.Invoice_Details.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_Details.Queries.GetById;
using eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll;

namespace eClaimProvider.Application.Mappings
{
    public class Invoice_DetailProfile : Profile
    {
        public Invoice_DetailProfile()
        {
            CreateMap<AddEditInvoice_DetailCommand, Invoice_Detail>().ReverseMap();
            CreateMap<GetInvoice_DetailByIdResponse, Invoice_Detail>().ReverseMap();
            CreateMap<GetAllInvoice_DetailResponse, Invoice_Detail>().ReverseMap();
        }
    }
}//