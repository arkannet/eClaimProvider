using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Revenues.Commands.AddEdit;
using eClaimProvider.Application.Features.Revenues.Queries.GetById;
using eClaimProvider.Application.Features.Revenues.Queries.GetAll;

namespace eClaimProvider.Application.Mappings
{
    public class RevenueProfile : Profile
    {
        public RevenueProfile()
        {
            CreateMap<AddEditRevenueCommand, Revenue>().ReverseMap();
            CreateMap<GetRevenueByIdResponse, Revenue>().ReverseMap();
            CreateMap<GetAllRevenueResponse, Revenue>().ReverseMap();
        }
    }
}