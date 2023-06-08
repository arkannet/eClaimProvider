using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Companies.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_SubDetails.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Invoice_SubDetail
{
    public interface IInvoice_SubDetailManager : IManager
    {
        Task<IResult<List<GetAllInvoice_SubDetailResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditInvoice_SubDetailCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}