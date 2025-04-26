using AS.FOS.App.Common.Domain.Entity;
using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.Order.Domain.Entities;

public class Customer : BaseEntity<CustomerId>
{
    public string Name { get; }
    public string Email { get; }
    public string PhoneNumber { get; }
    public bool IsActive { get; } = true;

    public Customer(string name, string email, string phoneNumber, bool isActive) : base(new CustomerId(Guid.NewGuid()))
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
    }

    public Customer()
    {
        
    }
}
