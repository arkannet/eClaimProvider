using eClaimProvider.Application.Features.Invoice_Details.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Client.Infrastructure.Managers.Catalog.nvoice_Detail;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Invoice_Detail

{
    public class Invoice_DetailManager : IInvoice_DetailManager
    {
        private readonly HttpClient _httpClient;

        public Invoice_DetailManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.Invoice_DetailEndpoints.Export
                : Routes.Invoice_DetailEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.Invoice_DetailEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllInvoice_DetailResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.Invoice_DetailEndpoints.GetAll);
            return await response.ToResult<List<GetAllInvoice_DetailResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditInvoice_DetailCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.Invoice_DetailEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}