using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Invoice

{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly HttpClient _httpClient;

        public InvoiceManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.InvoiceEndpoints.Export
                : Routes.InvoiceEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.InvoiceEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllInvoiceResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.InvoiceEndpoints.GetAll);
            return await response.ToResult<List<GetAllInvoiceResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditInvoiceCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.InvoiceEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}