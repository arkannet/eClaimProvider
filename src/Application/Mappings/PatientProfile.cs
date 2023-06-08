using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Patients.Queries.GetById;
using eClaimProvider.Application.Features.Patients.Queries.GetAll;
using eClaimProvider.Application.Features.Patients.Commands.AddEdit;

namespace eClaimProvider.Application.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<AddEditPatientCommand, Patient>().ReverseMap();
            CreateMap<GetPatientByIdResponse, Patient>().ReverseMap();
            CreateMap<GetAllPatientResponse, Patient>().ReverseMap();
        }
    }
}