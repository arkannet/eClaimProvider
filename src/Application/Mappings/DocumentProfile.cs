using AutoMapper;
using eClaimProvider.Application.Features.Documents.Commands.AddEdit;
using eClaimProvider.Application.Features.Documents.Queries.GetById;
using eClaimProvider.Domain.Entities.Misc;

namespace eClaimProvider.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}