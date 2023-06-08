using eClaimProvider.Application.Interfaces.Common;

namespace eClaimProvider.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}