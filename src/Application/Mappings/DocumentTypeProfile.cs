using AutoMapper;
using eClaimProvider.Application.Features.DocumentTypes.Commands.AddEdit;
using eClaimProvider.Application.Features.DocumentTypes.Queries.GetAll;
using eClaimProvider.Application.Features.DocumentTypes.Queries.GetById;
using eClaimProvider.Domain.Entities.Misc;

namespace eClaimProvider.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}