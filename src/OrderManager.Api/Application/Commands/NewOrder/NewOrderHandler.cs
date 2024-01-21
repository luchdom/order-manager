using FluentResults;
using MediatR;

namespace OrderManager.Api.Application.Commands.NewOrder;

public class NewOrderHandler : IRequestHandler<NewOrderCommand, Result>
{
    private readonly ILogger<NewOrderHandler> _logger;

    public NewOrderHandler(ILogger<NewOrderHandler> logger)
    {
        _logger = logger;
    }
    public async Task<Result> Handle(NewOrderCommand request, CancellationToken cancellationToken)
    {

        return Result.Ok();
    }
}
