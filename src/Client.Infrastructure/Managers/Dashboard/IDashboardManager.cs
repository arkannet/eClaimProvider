using eClaimProvider.Shared.Wrapper;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Dashboards.Queries.GetData;

namespace eClaimProvider.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}