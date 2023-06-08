using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Revenues.Commands.AddEdit;
using eClaimProvider.Application.Features.Revenues.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Revenue

{
    public class RevenueManager : IRevenueManager
    {
        private readonly HttpClient _httpClient;

        public RevenueManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.RevenueEndpoints.Export
                : Routes.RevenueEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.RevenueEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllRevenueResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.RevenueEndpoints.GetAll);
            return await response.ToResult<List<GetAllRevenueResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditRevenueCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.RevenueEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}