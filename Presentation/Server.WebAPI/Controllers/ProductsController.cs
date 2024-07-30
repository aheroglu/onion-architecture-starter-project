using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Products.Create;
using Server.Application.Features.Products.Delete;
using Server.Application.Features.Products.GetAll;
using Server.Application.Features.Products.GetById;
using Server.Application.Features.Products.Update;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var request = await mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var request = await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Ok(new { message = "Product created successfully" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteProductCommand(id), cancellationToken);
            return Ok(new { message = "Product deleted successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Ok(new { message = "Product updated successfully" });
        }
    }
}
