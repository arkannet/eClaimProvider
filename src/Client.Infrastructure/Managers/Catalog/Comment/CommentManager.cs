using eClaimProvider.Application.Features.Comments.Commands.AddEdit;
using eClaimProvider.Application.Features.Comments.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Client.Infrastructure.Extensions;
using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Comment

{
    public class CommentManager : ICommentManager
    {
        private readonly HttpClient _httpClient;

        public CommentManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? Routes.CommentEndpoints.Export
                : Routes.CommentEndpoints.ExportFiltered(searchString));
            return await response.ToResult<string>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CommentEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllCommentResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.CommentEndpoints.GetAll);
            return await response.ToResult<List<GetAllCommentResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditCommentCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.CommentEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}