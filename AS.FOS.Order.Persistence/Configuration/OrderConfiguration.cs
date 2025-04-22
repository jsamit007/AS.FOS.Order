using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AS.FOS.Order.Domain.Aggregates;

namespace AS.FOS.Order.Persistence.Configuration;

internal class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder.OwnsOne(o => o.DeliveryAddress);
        builder.Property(o => o.Status).HasConversion<string>();
        builder.HasMany(o => o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(o => o.Items).Metadata.SetField("_items");
        builder.Navigation(o => o.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
