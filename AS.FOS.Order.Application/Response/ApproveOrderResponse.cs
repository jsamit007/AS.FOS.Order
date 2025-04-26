using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Domain.ValueObjects;

namespace AS.FOS.Order.Application.Response;

public record ApproveOrderResponse
{
    public OrderId OrderId { get; init; }
    public CustomerId CustomerId { get; init; }
    public RestaurantId RestaurantId { get; init; }
    public string Status { get; init; } = string.Empty;
}
