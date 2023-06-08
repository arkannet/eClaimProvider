using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll;
using eClaimProvider.Application.Features.Invoice_Details.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.nvoice_Detail
{
    public interface IInvoice_DetailManager : IManager
    {
        Task<IResult<List<GetAllInvoice_DetailResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditInvoice_DetailCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}