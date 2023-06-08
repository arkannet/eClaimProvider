using AutoMapper;
using eClaimProvider.Domain.Entities.Catalog;
using eClaimProvider.Application.Features.Patients.Queries.GetById;
using eClaimProvider.Application.Features.Patients.Queries.GetAll;
using eClaimProvider.Application.Features.Patients.Commands.AddEdit;
using eClaimProvider.Application.Features.Results.Commands.AddEdit;
using eClaimProvider.Application.Features.Results.Queries.GetById;
using eClaimProvider.Application.Features.Results.Queries.GetAll;

namespace eClaimProvider.Application.Mappings
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<AddEditResultCommand, Result>().ReverseMap();
            CreateMap<GetResultByIdResponse, Result>().ReverseMap();
            CreateMap<GetAllResultResponse, Result>().ReverseMap();
        }
    }
}