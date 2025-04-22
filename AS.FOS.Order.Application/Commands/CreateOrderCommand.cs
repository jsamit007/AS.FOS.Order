

using AS.FOS.Order.Application.DTOs;

namespace AS.FOS.Order.Application.Commands;

public record CreateOrderCommand(
    Guid CustomerId,
    Guid RestaurantId,
    AddressDto DeliveryAddress,
    List<OrderItemDto> Items
);
