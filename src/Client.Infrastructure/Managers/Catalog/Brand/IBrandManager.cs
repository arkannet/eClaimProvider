using eClaimProvider.Application.Features.Brands.Queries.GetAll;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Brands.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Brand
{
    public interface IBrandManager : IManager
    {
        Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditBrandCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}