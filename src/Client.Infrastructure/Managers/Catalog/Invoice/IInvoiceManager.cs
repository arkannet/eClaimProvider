using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Invoice
{
    public interface IInvoiceManager : IManager
    {
        Task<IResult<List<GetAllInvoiceResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditInvoiceCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}