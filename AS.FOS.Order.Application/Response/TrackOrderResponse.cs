using AS.FOS.Order.Application.DTOs;

namespace AS.FOS.Order.Application.Response;

public record TrackOrderResponse(
    Guid OrderId,
    Guid CustomerId,
    Guid RestaurantId,
    AddressDto DeliveryAddress,
    List<OrderItemDto> Items,
    string Status
);