using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Domain.ValueObjects;
using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Domain.Entities;

namespace AS.FOS.Order.Persistence.Configuration;

internal class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.HasOne<Resturant>()
            .WithMany()
            .HasForeignKey(o => o.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(o => o.Id)
               .HasConversion(
                   id => id.Value,
                   value => new OrderId(value)
               );

        builder.Property(o => o.RestaurantId)
            .HasConversion(
                     id => id.Value,
                     value => new RestaurantId(value)
                );

        builder.Property(o => o.CustomerId)
            .HasConversion(
                     id => id.Value,
                     value => new CustomerId(value)
                );

        builder.OwnsOne(o => o.DeliveryAddress);

        builder.Property(o => o.Status).HasConversion<string>();
        builder.HasMany(o => o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);


        builder.Navigation(o => o.Items).Metadata.SetField("_items");
        builder.Navigation(o => o.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
