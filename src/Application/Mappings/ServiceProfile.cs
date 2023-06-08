using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Patients.Queries.GetById;
using eClaimProvider.Application.Features.Patients.Queries.GetAll;
using eClaimProvider.Application.Features.Patients.Commands.AddEdit;
using eClaimProvider.Application.Features.Services.Commands.AddEdit;
using eClaimProvider.Application.Features.Services.Queries.GetById;
using eClaimProvider.Application.Features.Services.Queries.GetAll;

namespace eClaimProvider.Application.Mappings
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<AddEditServiceCommand, Service>().ReverseMap();
            CreateMap<GetServiceByIdResponse, Service>().ReverseMap();
            CreateMap<GetAllServiceResponse, Service>().ReverseMap();
        }
    }
}