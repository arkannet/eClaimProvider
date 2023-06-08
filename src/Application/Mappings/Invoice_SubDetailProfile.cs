using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Invoice_SubDetails.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetById;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll;

namespace eClaimProvider.Application.Mappings
{
    public class Invoice_SubDetailProfile : Profile
    {
        public Invoice_SubDetailProfile()
        {
            CreateMap<AddEditInvoice_SubDetailCommand, Invoice_SubDetail>().ReverseMap();
            CreateMap<GetInvoice_SubDetailByIdResponse, Invoice_SubDetail>().ReverseMap();
            CreateMap<GetAllInvoice_SubDetailResponse, Invoice_SubDetail>().ReverseMap();
        }
    }
}//