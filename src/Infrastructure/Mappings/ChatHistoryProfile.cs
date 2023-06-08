using AutoMapper;
using eClaimProvider.Application.Interfaces.Chat;
using eClaimProvider.Application.Models.Chat;
using eClaimProvider.Infrastructure.Models.Identity;

namespace eClaimProvider.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}