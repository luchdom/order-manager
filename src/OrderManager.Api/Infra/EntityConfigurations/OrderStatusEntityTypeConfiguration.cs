using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderManager.Api.Domain.AggregateModels.OrderAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class OrderStatusEntityTypeConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.ToTable("orderstatus", AppDbContext.DefaultSchema);

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(o => o.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
