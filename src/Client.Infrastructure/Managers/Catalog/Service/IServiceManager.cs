using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Comments.Queries.GetAll;
using eClaimProvider.Application.Features.Comments.Commands.AddEdit;
using eClaimProvider.Application.Features.Services.Queries.GetAll;
using eClaimProvider.Application.Features.Services.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Service
{
    public interface IServiceManager : IManager
    {
        Task<IResult<List<GetAllServiceResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditServiceCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}