using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Revenues.Queries.GetAll;
using eClaimProvider.Application.Features.Revenues.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Revenue
{
    public interface IRevenueManager : IManager
    {
        Task<IResult<List<GetAllRevenueResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditRevenueCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}