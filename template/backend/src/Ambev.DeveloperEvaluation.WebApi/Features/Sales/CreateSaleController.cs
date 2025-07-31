using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using Ambev.DeveloperEvaluation.Application.Sales.Queries;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISender _mediator;

        public SalesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleRequest request)
        {
            CreateSaleCommand command = new CreateSaleCommand(
                 saleNumber: request.SaleNumber,
                 date: request.Date,
                 customerId: request.CustomerId,
                 customerName: request.CustomerName,
                 branchId: request.BranchId,
                 branchName: request.BranchName,
                 items: request.Items.Select(i => new CreateSaleItemCommand(
                     i.ProductId,
                     i.ProductName,
                     i.Quantity,
                     i.UnitPrice
                 )).ToList()
             );

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSaleByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSalesQuery());
            return Ok(result);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _mediator.Send(new CancelSaleCommand(id));
            return NoContent();
        }

        [HttpPut("{saleId}/items/{itemId}/cancel")]
        public async Task<IActionResult> CancelItem(Guid saleId, Guid itemId)
        {
            await _mediator.Send(new CancelSaleItemCommand(saleId, itemId));
            return NoContent();
        }
    }

}
