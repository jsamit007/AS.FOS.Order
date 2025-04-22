
namespace AS.FOS.Order.Application.Interfaces;

public interface IResturantRepository
{
    bool IsRestaurantOpen(Guid restaurantId);
}
