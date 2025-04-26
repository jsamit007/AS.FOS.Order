using AS.FOS.Order.Application.Response;
using AS.FOS.Order.Domain.ValueObjects;
using MediatR;

namespace AS.FOS.Order.Application.Queries;

public record TrackOrderQuery(OrderId orderId) : IRequest<TrackOrderResponse>
{
    public OrderId OrderId { get; } = orderId;
}
