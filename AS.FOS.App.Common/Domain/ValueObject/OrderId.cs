using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.Order.Domain.ValueObjects;

public sealed class OrderId : BaseId<Guid>
{
    public OrderId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(OrderId id) => id.Value;
    public static implicit operator OrderId(Guid id) => new(id);
}