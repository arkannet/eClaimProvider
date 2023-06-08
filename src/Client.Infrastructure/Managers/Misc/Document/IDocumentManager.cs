using eClaimProvider.Application.Features.Documents.Commands.AddEdit;
using eClaimProvider.Application.Features.Documents.Queries.GetAll;
using eClaimProvider.Application.Requests.Documents;
using eClaimProvider.Shared.Wrapper;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Documents.Queries.GetById;

namespace eClaimProvider.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}