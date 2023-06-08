using eClaimProvider.Application.Interfaces.Common;
using eClaimProvider.Application.Requests.Identity;
using eClaimProvider.Application.Responses.Identity;
using eClaimProvider.Shared.Wrapper;
using System.Threading.Tasks;

namespace eClaimProvider.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}