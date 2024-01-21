using OrderManager.Api.Domain.SeedWork;

namespace OrderManager.Api.Domain.AggregateModels.ProductAggregate;

public class Product : Entity, IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
