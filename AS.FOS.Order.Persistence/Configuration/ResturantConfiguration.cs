using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS.FOS.Order.Persistence.Configuration;

internal class ResturantConfiguration : IEntityTypeConfiguration<Resturant>
{
    public void Configure(EntityTypeBuilder<Resturant> builder)
    {
        builder.HasKey(r => r.RestaurantId);
        builder.Property(r => r.RestaurantId)
            .HasConversion(
                id => id.Value,
                value => new RestaurantId(value)
            );
        builder.Property(r => r.IsOpen).IsRequired();
    }
}
