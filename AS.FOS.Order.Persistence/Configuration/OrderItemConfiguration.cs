using AS.FOS.Order.Domain.Entities;
using AS.FOS.Order.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS.FOS.Order.Persistence.Configuration;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.ProductId).IsRequired();
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.Price).IsRequired();
        builder.Property(i => i.Id)
            .HasConversion(
                id => id.Value,
                value => new OrderItemId(value)
            );
    }
}
