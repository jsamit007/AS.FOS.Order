using AS.FOS.App.Common.Domain.Event;

namespace AS.FOS.App.Common.Application.Events;

public interface IEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent);
}
