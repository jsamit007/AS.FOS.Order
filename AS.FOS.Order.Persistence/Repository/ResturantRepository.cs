using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AS.FOS.Order.Persistence.Repository;

internal class ResturantRepository : IResturantRepository
{
    private readonly OrderDBContext _context;

    public ResturantRepository(OrderDBContext context)
    {
        _context = context;
    }

    public bool IsRestaurantOpen(Guid restaurantId)
    {
        return _context.Resturants
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == restaurantId) != null;
    }
}
