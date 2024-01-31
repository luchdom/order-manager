using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Api.Domain.AggregateModels.OrderAggregate;
using OrderManager.Api.Domain.AggregateModels.UserAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders", AppDbContext.DefaultSchema);

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .UseHiLo("orderseq", AppDbContext.DefaultSchema);

        builder.Property(o => o.CreatedAt)
            .IsRequired();

        builder.Property(o => o.ModifiedAt)
          .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(o=>o.BuyerId);


        builder.HasOne(o => o.OrderStatus)
            .WithMany()
            .HasForeignKey("_orderStatusId");
    }
}
