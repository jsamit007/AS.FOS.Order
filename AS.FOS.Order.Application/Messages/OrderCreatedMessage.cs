using AS.FOS.App.Common.Domain.Enums;

namespace AS.FOS.Order.Application.Messages;

internal record OrderCreatedMessage 
{
    public Guid OrderId { get; init; }
    public OrderStatus Status { get; init; }
    public double Money { get; init; }
}
