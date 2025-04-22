
using AS.FOS.App.Common.Domain.Entity;
using AS.FOS.App.Common.Domain.Enums;
using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Domain.Entities;
using AS.FOS.Order.Domain.Events;
using AS.FOS.Order.Domain.ValueObjects;

namespace AS.FOS.Order.Domain.Aggregates;

public class OrderEntity : AggregateRoot<OrderId>
{
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public RestaurantId RestaurantId { get; private set; }
    public ValueObjects.OrderEntity DeliveryAddress { get; private set; }
    public OrderStatus Status { get; private set; }
    private readonly List<OrderItem> _items;

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public OrderEntity(CustomerId customerId, RestaurantId restaurantId, ValueObjects.OrderEntity deliveryAddress)
    {
        Id = new OrderId(Guid.NewGuid());
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
        RestaurantId = restaurantId ?? throw new ArgumentNullException(nameof(restaurantId));
        DeliveryAddress = deliveryAddress ?? throw new ArgumentNullException(nameof(deliveryAddress));
        Status = OrderStatus.Pending;
        _items = new List<OrderItem>();
    }

    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }

    public void Create()
    {
        if (Status != OrderStatus.Initiated)
            throw new InvalidOperationException("Only pending orders can be initiated.");

        Status = OrderStatus.Pending;
        AddDomainEvent(new OrderCreatedDomainEvent(this));
    }

    public void Approve()
    {
        if (Status != OrderStatus.Paid)
            throw new InvalidOperationException("Only initiated orders can be approved.");

        Status = OrderStatus.Approved;
        AddDomainEvent(new OrderApprovedDomainEvent(this));
    }

    public void Pay()
    {
        if (Status != OrderStatus.Approved)
            throw new InvalidOperationException("Only approved orders can be paid.");

        Status = OrderStatus.Paid;
        AddDomainEvent(new OrderPaidDomainEvent(this));
    }
}

