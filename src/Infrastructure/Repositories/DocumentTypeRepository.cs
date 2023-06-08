using eClaimProvider.Application.Interfaces.Repositories;
using eClaimProvider.Domain.Entities.Misc;

namespace eClaimProvider.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IRepositoryAsync<DocumentType, int> _repository;

        public DocumentTypeRepository(IRepositoryAsync<DocumentType, int> repository)
        {
            _repository = repository;
        }
    }
}