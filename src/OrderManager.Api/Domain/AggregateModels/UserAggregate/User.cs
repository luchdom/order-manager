using Microsoft.AspNetCore.Identity;
using OrderManager.Api.Domain.SeedWork;

namespace OrderManager.Api.Domain.AggregateModels.UserAggregate;

public class User : IdentityUser, IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
