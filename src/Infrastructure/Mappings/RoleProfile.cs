using AutoMapper;
using eClaimProvider.Infrastructure.Models.Identity;
using eClaimProvider.Application.Responses.Identity;

namespace eClaimProvider.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}