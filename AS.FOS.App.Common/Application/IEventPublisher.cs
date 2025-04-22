using AS.FOS.App.Common.Domain.Event;

namespace AS.FOS.App.Common.Application;

public interface IEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent);
}
