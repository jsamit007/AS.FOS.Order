using AS.FOS.App.Common.Domain.Entity;
using AS.FOS.Order.Domain.ValueObjects;

namespace AS.FOS.Order.Domain.Entities;

public class OrderItem : BaseEntity<OrderItemId>
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    public OrderItem(Guid productId, int quantity, decimal price) : base(new OrderItemId(Guid.NewGuid()))
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}
