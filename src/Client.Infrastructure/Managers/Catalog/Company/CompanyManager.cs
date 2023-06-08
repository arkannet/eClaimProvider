using eClaimProvider.Application.Features.Companies.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Company

{
    public class CompanyManager : ICompanyManager
    {
        private readonly HttpClient _httpClient;

        public CompanyManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.CompanyEndpoints.Export
                : Routes.CompanyEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CompanyEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllCompanyResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.CompanyEndpoints.GetAll);
            return await response.ToResult<List<GetAllCompanyResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditCompanyCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.CompanyEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}