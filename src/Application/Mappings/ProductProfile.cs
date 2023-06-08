using AutoMapper;
using eClaimProvider.Application.Features.Products.Commands.AddEdit;
using eClaimProvider.Domain.Entities.Catalog;

namespace eClaimProvider.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}