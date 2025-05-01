using FluentAssertions;
using AS.FOS.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using AS.FOS.Order.Persistence.Repository;
using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Domain.ValueObjects;
using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Domain.Entities;
using AS.FOS.App.Common.Domain.Enums;

namespace AS.FOS.Order.UnitTests.Repository;

public class OrderRepositoryTests
{
    private OrderDBContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<OrderDBContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new OrderDBContext(options);
    }

    [Fact]
    public async Task AddAsync_ShouldAddOrderToDatabase()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var repository = new OrderRepository(context);

        var order = new OrderEntity(
            new CustomerId(Guid.NewGuid()),
            new RestaurantId(Guid.NewGuid()),
            new DeliveryAddress("123 Street", "City", "State", "12345")
        );

        // Act
        await repository.AddAsync(order);

        // Assert
        var savedOrder = await context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
        savedOrder.Should().NotBeNull();
        savedOrder!.CustomerId.Should().Be(order.CustomerId);
        savedOrder.RestaurantId.Should().Be(order.RestaurantId);
        savedOrder.DeliveryAddress.Should().Be(order.DeliveryAddress);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOrder_WhenOrderExists()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var repository = new OrderRepository(context);

        var order = new OrderEntity(
            new CustomerId(Guid.NewGuid()),
            new RestaurantId(Guid.NewGuid()),
            new DeliveryAddress("123 Street", "City", "State", "12345")
        );
        order.AddItem(new OrderItem(Guid.NewGuid(), 2, 10.5m));
        context.Orders.Add(order);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(order.Id.Value, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(order.Id);
        result.Items.Should().HaveCount(1);
        result.Items.First().Quantity.Should().Be(2);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenOrderDoesNotExist()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var repository = new OrderRepository(context);

        // Act
        var result = await repository.GetByIdAsync(Guid.NewGuid(), CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateOrderInDatabase()
    {
        // Arrange
        var context = CreateInMemoryDbContext();
        var repository = new OrderRepository(context);

        var order = new OrderEntity(
            new CustomerId(Guid.NewGuid()),
            new RestaurantId(Guid.NewGuid()),
            new DeliveryAddress("123 Street", "City", "State", "12345")
        );
        context.Orders.Add(order);
        await context.SaveChangesAsync();

        order.Pay();
        await repository.UpdateAsync(order);
        await context.SaveChangesAsync();

        // Assert
        var updatedOrder = await context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
        updatedOrder.Should().NotBeNull();
        updatedOrder!.Status.Should().Be(OrderStatus.Paid);
    }
}
