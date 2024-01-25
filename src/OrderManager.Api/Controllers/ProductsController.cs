using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Api.Application.Commands.NewOrder;
using OrderManager.Api.Application.Models;
using OrderManager.Api.Application.Queries.GetProducts;

namespace OrderManager.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(List<ProductItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts(GetProductsQuery command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }

}
