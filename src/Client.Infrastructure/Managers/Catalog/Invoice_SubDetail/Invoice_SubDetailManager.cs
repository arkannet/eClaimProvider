using eClaimProvider.Application.Features.Companies.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Invoice_SubDetails.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Invoice_SubDetail

{
    public class Invoice_SubDetailManager : IInvoice_SubDetailManager
    {
        private readonly HttpClient _httpClient;

        public Invoice_SubDetailManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.Invoice_SubDetailEndpoints.Export
                : Routes.Invoice_SubDetailEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.Invoice_SubDetailEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllInvoice_SubDetailResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.Invoice_SubDetailEndpoints.GetAll);
            return await response.ToResult<List<GetAllInvoice_SubDetailResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditInvoice_SubDetailCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.Invoice_SubDetailEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}