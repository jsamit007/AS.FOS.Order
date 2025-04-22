using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.Order.Domain.ValueObjects;

public class OrderItemId : BaseId<Guid>
{
    public OrderItemId(Guid value) : base(value)
    {
    }

    public static implicit operator Guid(OrderItemId id) => id.Value;
    public static implicit operator OrderItemId(Guid id) => new(id);
}
