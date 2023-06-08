using eClaimProvider.Application.Features.Products.Commands.AddEdit;
using eClaimProvider.Application.Features.Products.Queries.GetAllPaged;
using eClaimProvider.Application.Requests.Catalog;
using eClaimProvider.Shared.Wrapper;
using System.Threading.Tasks;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}