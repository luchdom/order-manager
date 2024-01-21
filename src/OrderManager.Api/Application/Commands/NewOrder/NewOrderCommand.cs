using FluentResults;
using MediatR;

namespace OrderManager.Api.Application.Commands.NewOrder;

public struct NewOrderCommand : IRequest<Result>
{
    public NewOrderCommand(string customerId, List<OrderItemRequest> orderItems)
    {
        CustomerId = customerId;
        OrderItems = orderItems;
    }

    public string CustomerId { get; }
    public List<OrderItemRequest> OrderItems { get; }
}

public struct OrderItemRequest
{
    public OrderItemRequest(int productId, decimal quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public int ProductId { get; }
    public decimal Quantity { get; }
}
