using OrderManager.Api.Domain.AggregateModels.CustomerAggregate;
using OrderManager.Api.Domain.AggregateModels.ProductAggregate;
using OrderManager.Api.Domain.SeedWork;

namespace OrderManager.Api.Domain.AggregateModels.OrderAggregate;

public class Order : Entity, IAuditableEntity
{
    private readonly List<OrderItem> _orderItems = [];
    private Order() { }
    public Order(Guid requestId, Customer customer, IEnumerable<OrderItem> items)
    {
        RequestId = requestId;
        Customer = customer;
        Items = items;
    }

    public Guid RequestId { get; set; }
    public Customer Customer { get; set; }
    public IEnumerable<OrderItem> Items { get; set; }
    public OrderStatus OrderStatus { get; private set; }
    private int _orderStatusId;

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public decimal TotalCost()
    {
        return Items.Sum(item => item.Product.Price * item.Quantity);
    }

    public void AddOrdemItem(Product product, decimal quantity)
    {
        var orderItem = new OrderItem(product, quantity);
        var productAlreadyRegistered = _orderItems.SingleOrDefault(x => x.Product.Id.Equals(orderItem.Product.Id));

        if (productAlreadyRegistered != null)
            return;

        _orderItems.Add(orderItem);
    }
}
