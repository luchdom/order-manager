using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Api.Application.Commands.NewOrder;

namespace OrderManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private const string ApiVersion = "1";

    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status201Created)]
    public async Task<IActionResult> NewOrder(NewOrderCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Errors);

        return Created($"{Request.Scheme}://{Request.Host}/v{ApiVersion}/orders/{1}", result);
    }
}
