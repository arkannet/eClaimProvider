using AutoMapper;
using eClaimProvider.Application.Features.Brands.Commands.AddEdit;
using eClaimProvider.Application.Features.Brands.Queries.GetAll;
using eClaimProvider.Application.Features.Brands.Queries.GetById;
using eClaimProvider.Domain.Entities.Catalog;

namespace eClaimProvider.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}