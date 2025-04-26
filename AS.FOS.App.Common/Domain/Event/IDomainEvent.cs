using AS.FOS.App.Common.Application.Events;

namespace AS.FOS.App.Common.Domain.Event;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
