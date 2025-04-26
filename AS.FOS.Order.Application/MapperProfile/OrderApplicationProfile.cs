using AS.FOS.Order.Application.DTOs;
using AS.FOS.Order.Application.Messages;
using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Domain.ValueObjects;
using AutoMapper;
namespace AS.FOS.Order.Application.MapperProfile;

public class OrderApplicationProfile : Profile
{
    public OrderApplicationProfile()
    {
        CreateMap<AddressDto, DeliveryAddress>();

        CreateMap<OrderEntity, OrderCreatedMessage>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Money, OrderId => OrderId.MapFrom(src => src.Items.Sum(item => item.Price * item.Quantity)));
    }
}
