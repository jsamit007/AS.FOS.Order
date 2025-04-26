namespace AS.FOS.App.Common.Domain.ValueObject;

public sealed class RestaurantId : BaseId<Guid>
{
    public RestaurantId(Guid value) : base(value)
    {
    }

    public RestaurantId()
    {
        
    }

    public static implicit operator Guid(RestaurantId id) => id.Value;
    public static implicit operator RestaurantId(Guid id) => new(id);
}
