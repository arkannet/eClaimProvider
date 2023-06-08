using AutoMapper;
using eClaimProvider.Application.Requests.Identity;
using eClaimProvider.Application.Responses.Identity;

namespace eClaimProvider.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}