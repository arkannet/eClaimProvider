using eClaimProvider.Application.Interfaces.Common;
using eClaimProvider.Application.Requests.Identity;
using eClaimProvider.Shared.Wrapper;
using System.Threading.Tasks;

namespace eClaimProvider.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}