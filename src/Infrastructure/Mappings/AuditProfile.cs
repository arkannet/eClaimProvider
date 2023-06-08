using AutoMapper;
using eClaimProvider.Infrastructure.Models.Audit;
using eClaimProvider.Application.Responses.Audit;

namespace eClaimProvider.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}