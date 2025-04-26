namespace AS.FOS.App.Common.Domain.ValueObject;

public sealed class CustomerId : BaseId<Guid>
{
    public CustomerId(Guid value) : base(value)
    {
    }

    public CustomerId()
    {
        
    }

    public static implicit operator Guid(CustomerId id) => id.Value;
    public static implicit operator CustomerId(Guid id) => new(id);
}
