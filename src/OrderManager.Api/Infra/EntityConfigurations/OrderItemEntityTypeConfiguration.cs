using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Api.Domain.AggregateModels.OrderAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items", AppDbContext.DefaultSchema);

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .UseHiLo("orderitemseq");

        builder.Property<int>("OrderId")
          .IsRequired();

        builder.HasOne(o => o.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(o => o.Quantity)
            .IsRequired();

    }
}
