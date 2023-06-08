using eClaimProvider.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Patients.Commands.AddEdit;
using eClaimProvider.Application.Features.Patients.Queries.GetAll;

namespace eClaimProvider.Client.Infrastructure.Managers.Catalog.Patient
{
    public interface IPatientManager : IManager
    {
        Task<IResult<List<GetAllPatientResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditPatientCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}