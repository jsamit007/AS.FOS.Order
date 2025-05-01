using AS.FOS.App.Common.Application.Events;
using AS.FOS.App.Common.Domain.Event;
using MassTransit;

namespace AS.FOS.Order.Infrastructure.Messaging.Publisher;

internal class MassTransitEventPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _endpoint;

    public MassTransitEventPublisher(IPublishEndpoint endpoint)
    {
        _endpoint = endpoint;
    }

    public async Task PublishAsync(IDomainEvent domainEvent)
    {
       await _endpoint.Publish(domainEvent);
    }
}
