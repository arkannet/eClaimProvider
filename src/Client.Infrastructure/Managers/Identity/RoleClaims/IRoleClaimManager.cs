using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Requests.Identity;
using eClaimProvider.Application.Responses.Identity;
using eClaimProvider.Shared.Wrapper;

namespace eClaimProvider.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}