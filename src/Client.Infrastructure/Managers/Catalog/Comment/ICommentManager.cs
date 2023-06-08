using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Comments.Queries.GetAll;
using eClaimProvider.Application.Features.Comments.Commands.AddEdit;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Comment
{
    public interface ICommentManager : IManager
    {
        Task<IResult<List<GetAllCommentResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditCommentCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}