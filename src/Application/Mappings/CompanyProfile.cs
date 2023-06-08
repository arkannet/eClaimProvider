using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Companies.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Queries.GetById;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;

namespace eClaimProvider.Application.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<AddEditCompanyCommand, Company>().ReverseMap();
            CreateMap<GetCompanyByIdResponse, Company>().ReverseMap();
            CreateMap<GetAllCompanyResponse, Company>().ReverseMap();
        }
    }
}