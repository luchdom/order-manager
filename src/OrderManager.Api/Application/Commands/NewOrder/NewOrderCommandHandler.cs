using FluentResults;
using MediatR;

namespace OrderManager.Api.Application.Commands.NewOrder;

public class NewOrderCommandHandler : IRequestHandler<NewOrderCommand, Result>
{
    private readonly ILogger<NewOrderCommandHandler> _logger;

    public NewOrderCommandHandler(ILogger<NewOrderCommandHandler> logger)
    {
        _logger = logger;
    }
    public async Task<Result> Handle(NewOrderCommand request, CancellationToken cancellationToken)
    {

        return Result.Ok();
    }
}
