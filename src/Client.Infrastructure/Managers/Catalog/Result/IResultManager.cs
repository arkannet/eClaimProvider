using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll;
using eClaimProvider.Application.Features.Invoice_Details.Commands.AddEdit;
using eClaimProvider.Application.Features.REJECTEDs.Queries.GetAll;
using eClaimProvider.Application.Features.REJECTEDs.Commands.AddEdit;
using eClaimProvider.Application.Features.Results.Queries.GetAll;
using eClaimProvider.Application.Features.Results.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Result
{
    public interface IResultManager : IManager
    {
        Task<IResult<List<GetAllResultResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditResultCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}