using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Interfaces.Common;
using eClaimProvider.Application.Requests.Identity;
using eClaimProvider.Application.Responses.Identity;
using eClaimProvider.Shared.Wrapper;

namespace eClaimProvider.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}