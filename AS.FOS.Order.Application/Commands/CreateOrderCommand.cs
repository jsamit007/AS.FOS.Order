using AS.FOS.Order.Application.DTOs;
using AS.FOS.Order.Application.Response;
using MediatR;

namespace AS.FOS.Order.Application.Commands;

public class CreateOrderCommand : IRequest<CreateOrderResponse>
{
    public Guid CustomerId { get; set; }
    public Guid RestaurantId { get; set; }
    public AddressDto DeliveryAddress { get; set; } = default!;
    public List<OrderItemDto> Items { get; set; } = default!;
}
