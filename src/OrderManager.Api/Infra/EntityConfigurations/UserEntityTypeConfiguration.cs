using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Api.Domain.AggregateModels.UserAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", AppDbContext.DefaultSchema);

        builder.Property(u => u.AnonymousId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.AnonymousId)
            .IsUnique();
    }
}
