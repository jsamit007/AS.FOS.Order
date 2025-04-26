namespace AS.FOS.Order.Application.DTOs;

public record OrderItemDto(Guid ProductId, int Quantity, decimal Price);

public record AddressDto(string Street, string City, string State, string ZipCode);



