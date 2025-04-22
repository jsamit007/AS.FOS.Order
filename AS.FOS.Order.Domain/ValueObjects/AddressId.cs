using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.Order.Domain.ValueObjects;

public class AddressId : BaseId<Guid>
{
    public AddressId(Guid value) : base(value)
    {
    }

}
