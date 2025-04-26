

using AS.FOS.App.Common.Domain.Entity;
using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.Order.Domain.Entities;

public class Resturant : BaseEntity<RestaurantId>
{
    public Resturant(RestaurantId id) : base(id)
    {
    }

    public Resturant()
    {
        
    }

    public RestaurantId RestaurantId { get; }
    public bool IsOpen { get; } 
}
