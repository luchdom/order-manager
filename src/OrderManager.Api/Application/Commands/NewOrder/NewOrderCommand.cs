using FluentResults;
using MediatR;
namespace OrderManager.Api.Application.Commands.NewOrder;

public class NewOrderCommand : IRequest<Result>
{
    public NewOrderCommand(string customerId, List<OrderItemRequest> orderItems)
    {
        CustomerId = customerId;
        OrderItems = orderItems;
    }

    public string CustomerId { get; }
    public List<OrderItemRequest> OrderItems { get; }
}

public class OrderItemRequest
{
    public OrderItemRequest(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public int ProductId { get; }
    public int Quantity { get; }
}
