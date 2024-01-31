using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Api.Domain.AggregateModels.UserAggregate;

namespace OrderManager.Api.Infra.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("customers", AppDbContext.DefaultSchema);

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .UseHiLo("customerseq", AppDbContext.DefaultSchema);


    }
}
