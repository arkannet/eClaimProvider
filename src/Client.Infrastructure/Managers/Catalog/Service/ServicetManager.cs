using eClaimProvider.Application.Features.Comments.Commands.AddEdit;
using eClaimProvider.Application.Features.Comments.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Services.Commands.AddEdit;
using eClaimProvider.Application.Features.Services.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Service

{
    public class ServicetManager : IServiceManager
    {
        private readonly HttpClient _httpClient;

        public ServicetManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.ServiceEndpoints.Export
                : Routes.ServiceEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.ServiceEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllServiceResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.ServiceEndpoints.GetAll);
            return await response.ToResult<List<GetAllServiceResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditServiceCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.ServiceEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}