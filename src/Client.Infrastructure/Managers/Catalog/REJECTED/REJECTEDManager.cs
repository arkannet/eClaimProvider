using eClaimProvider.Application.Features.Invoice_Details.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_Details.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.REJECTEDs.Commands.AddEdit;
using eClaimProvider.Application.Features.REJECTEDs.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Client.Infrastructure.Managers.Catalog.nvoice_Detail;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.REJECTED

{
    public class REJECTEDManager : IREJECTEDManager
    {
        private readonly HttpClient _httpClient;

        public REJECTEDManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.REJECTEDEndpoints.Export
                : Routes.REJECTEDEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.REJECTEDEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllREJECTEDResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.REJECTEDEndpoints.GetAll);
            return await response.ToResult<List<GetAllREJECTEDResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditREJECTEDCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.REJECTEDEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}