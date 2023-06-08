using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Companies.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Commands.Delete;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Companies.Queries.GetById;
using eClaimProvider.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.REJECTEDs.Queries.GetAll;
using eClaimProvider.Application.Features.REJECTEDs.Queries.GetById;
using eClaimProvider.Application.Features.REJECTEDs.Commands.AddEdit;
using eClaimProvider.Application.Features.REJECTEDs.Commands.Delete;

namespace eClaimProvider.Server.Controllers.v1.Catalog
{
    public class REJECTEDController : BaseApiController<REJECTEDController>
    {
        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Brands.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetAllREJECTEDQuery());
            return Ok(brands);
        }

        /// <summary>
        /// Get a Brand By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        //[Authorize(Policy = Permissions.Brands.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _mediator.Send(new GetREJECTEDByIdQuery() { Id = id });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a Brand
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        
        [HttpPost]
        public async Task<IActionResult> Post(AddEditREJECTEDCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteREJECTEDCommand { Id = id }));
        }

        
    }
}