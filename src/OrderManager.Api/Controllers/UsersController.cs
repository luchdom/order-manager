using Asp.Versioning;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Api.Application.Commands.RegisterUser;

namespace OrderManager.Api.Controllers;

[Route("/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion(ApiVersion)]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private const string ApiVersion = "1";

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsFailed)
            return result;

        return Created($"{Request.Scheme}://{Request.Host}/v{ApiVersion}/users/{result.Value}", result);
    }
}
