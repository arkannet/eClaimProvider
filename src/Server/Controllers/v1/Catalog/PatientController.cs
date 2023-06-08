using eClaimProvider.Application.Features.Patients.Commands.AddEdit;
using eClaimProvider.Application.Features.Patients.Commands.Delete;
using eClaimProvider.Application.Features.Patients.Queries.GetAll;
using eClaimProvider.Application.Features.Patients.Queries.GetById;
using eClaimProvider.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eClaimProvider.Server.Controllers.v1.Catalog
{
    public class PatientController : BaseApiController<PatientController>
    {
        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Brands.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetAllPatientQuery());
            return Ok(brands);
        }

        /// <summary>
        /// Get a Brand By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        //[Authorize(Policy = Permissions.Brands.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var brand = await _mediator.Send(new GetPatientByIdQuery() { Id = id });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a Brand
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        
        [HttpPost]
        public async Task<IActionResult> Post(AddEditPatientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeletePatientCommand { Id = id }));
        }

        
    }
}