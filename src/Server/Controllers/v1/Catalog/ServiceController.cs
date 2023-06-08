using eClaimProvider.Application.Features.Invoices.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoices.Commands.Delete;
using eClaimProvider.Application.Features.Invoices.Queries.GetAll;
using eClaimProvider.Application.Features.Invoices.Queries.GetById;
using eClaimProvider.Application.Features.Services.Commands.AddEdit;
using eClaimProvider.Application.Features.Services.Commands.Delete;
using eClaimProvider.Application.Features.Services.Queries.GetAll;
using eClaimProvider.Application.Features.Services.Queries.GetById;
using eClaimProvider.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eClaimProvider.Server.Controllers.v1.Catalog
{
    public class ServiceController : BaseApiController<ServiceController>
    {
        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Brands.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetAllServiceQuery());
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
            var brand = await _mediator.Send(new GetServiceByIdQuery() { Id = id });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a Brand
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        
        [HttpPost]
        public async Task<IActionResult> Post(AddEditServiceCommand command)
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
            return Ok(await _mediator.Send(new DeleteServiceCommand { Id = id }));
        }

        
    }
}