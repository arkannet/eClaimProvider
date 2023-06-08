using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Companies.Commands.AddEdit;
using eClaimProvider.Application.Features.Companies.Commands.Delete;
using eClaimProvider.Application.Features.Companies.Queries.GetAll;
using eClaimProvider.Application.Features.Companies.Queries.GetById;
using eClaimProvider.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetAll;
using eClaimProvider.Application.Features.Invoice_SubDetails.Queries.GetById;
using eClaimProvider.Application.Features.Invoice_SubDetails.Commands.AddEdit;
using eClaimProvider.Application.Features.Invoice_SubDetails.Commands.Delete;

namespace eClaimProvider.Server.Controllers.v1.Catalog
{
    public class Invoice_SubDetailController : BaseApiController<Invoice_SubDetailController>
    {
        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Brands.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetAllInvoice_SubDetailQuery());
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
            var brand = await _mediator.Send(new GetInvoice_SubDetailByIdQuery() { Id = id });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a Brand
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        
        [HttpPost]
        public async Task<IActionResult> Post(AddEditInvoice_SubDetailCommand command)
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
            return Ok(await _mediator.Send(new DeleteInvoice_SubDetailCommand { Id = id }));
        }

        
    }
}