using OrderManager.Api.Domain.AggregateModels.ProductAggregate;
using OrderManager.Api.Domain.SeedWork;

namespace OrderManager.Api.Domain.AggregateModels.OrderAggregate;

public class OrderItem : Entity, IAuditableEntity
{
    public OrderItem(Product product, decimal quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    public int Id { get; set; }
    public Product Product { get; set; }
    public decimal Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

}
