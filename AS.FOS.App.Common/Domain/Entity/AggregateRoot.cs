using AS.FOS.App.Common.Domain.Event;
using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.App.Common.Domain.Entity;

public abstract class AggregateRoot<T> where T : BaseId<Guid>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
