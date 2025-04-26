using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Domain.ValueObjects;

namespace AS.FOS.Order.Application.Response;

public class PayOrderResponse
{
    public OrderId OrderId { get; set; }
    public CustomerId CustomerId { get; set; }
    public RestaurantId RestaurantId { get; set; }
    public string Status { get; set; }
}
