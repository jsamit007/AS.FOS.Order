using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Domain.Entities;
using AS.FOS.Order.Persistence.Context;
using AS.FOS.Order.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace AS.FOS.Order.UnitTests.Repository;

public class ResturantRepositoryTests
{
    private readonly IResturantRepository _resturantRepository;
    private readonly OrderDBContext _context;

    public ResturantRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<OrderDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new OrderDBContext(options);
        _resturantRepository = new ResturantRepository(_context);
    }

    [Fact]
    public void IsRestaurantOpen_ShouldReturnTrue_WhenRestaurantExists()
    {
        // Arrange
        var restaurantId = Guid.NewGuid();
        var restaurant = new Resturant(restaurantId);
        _context.Resturants.Add(restaurant);
        _context.SaveChanges();

        // Act
        var result = _resturantRepository.IsRestaurantOpen(restaurantId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsRestaurantOpen_ShouldReturnFalse_WhenRestaurantDoesNotExist()
    {
        // Arrange
        var restaurantId = Guid.NewGuid();

        // Act
        var result = _resturantRepository.IsRestaurantOpen(restaurantId);

        // Assert
        Assert.False(result);
    }
}
