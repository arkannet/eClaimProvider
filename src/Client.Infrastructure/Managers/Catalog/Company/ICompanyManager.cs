using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Companies.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Company
{
    public interface ICompanyManager : IManager
    {
        Task<IResult<List<GetAllCompanyResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditCompanyCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}