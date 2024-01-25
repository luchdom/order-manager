using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Api.Domain.AggregateModels.ProductAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products", AppDbContext.DefaultSchema);

        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id)
            .UseHiLo("productseq", AppDbContext.DefaultSchema);

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasPrecision(12, 2)
            .IsRequired();

    }
}
