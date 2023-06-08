using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Patients.Commands.AddEdit;
using eClaimProvider.Application.Features.Patients.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Patient

{
    public class PatientManager : IPatientManager
    {
        private readonly HttpClient _httpClient;

        public PatientManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.PatientEndpoints.Export
                : Routes.PatientEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.PatientEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllPatientResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.PatientEndpoints.GetAll);
            return await response.ToResult<List<GetAllPatientResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditPatientCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}