using OrderManager.Api.Domain.SeedWork;

namespace OrderManager.Api.Domain.AggregateModels.CustomerAggregate;

public class Customer : Entity, IAuditableEntity
{
    public Guid Aci { get; set; }
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
