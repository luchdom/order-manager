using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Api.Domain.AggregateModels.CustomerAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers", AppDbContext.DefaultSchema);

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .UseHiLo("customerseq", AppDbContext.DefaultSchema);

        builder.Property(c => c.Aci)
         .UseHiLo("customerseq", AppDbContext.DefaultSchema);

        builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

    }
}
