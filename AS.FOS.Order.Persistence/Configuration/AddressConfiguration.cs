using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS.FOS.Order.Persistence.Configuration;

internal class AddressConfiguration : IEntityTypeConfiguration<Domain.Aggregates.OrderEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.OrderEntity> builder)
    {
        builder.OwnsOne(o => o.DeliveryAddress, address =>
        {
            address.Property(a => a.Street).IsRequired();
            address.Property(a => a.City).IsRequired();
            address.Property(a => a.ZipCode).IsRequired();

        });
    }
}
