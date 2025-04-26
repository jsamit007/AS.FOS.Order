
using AS.FOS.Order.Application.DTOs;
using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Application.Queries;
using AS.FOS.Order.Application.Response;
using MediatR;

namespace AS.FOS.Order.Application.Handlers;

internal class TrackOrderQueryHandler : IRequestHandler<TrackOrderQuery, TrackOrderResponse>
{
    private readonly IOrderRepository _orderRepository;

    public TrackOrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<TrackOrderResponse> Handle(TrackOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.orderId.Value, cancellationToken);
        if (order == null)
        {
            throw new Exception($"Order with ID {request.orderId.Value} not found.");
        }

        return new TrackOrderResponse
        (
            order.Id.Value,
            order.CustomerId.Value,
            order.RestaurantId.Value,
            new AddressDto(order.DeliveryAddress.Street, order.DeliveryAddress.City, order.DeliveryAddress.State, order.DeliveryAddress.ZipCode),
            order.Items.Select(item => new OrderItemDto(item.ProductId, item.Quantity, item.Price)).ToList(),
            order.Status.ToString()
        ); // Convert it into Mapper
    }
}
