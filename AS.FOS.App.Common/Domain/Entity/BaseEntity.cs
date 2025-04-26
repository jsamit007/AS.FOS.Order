using AS.FOS.App.Common.Domain.ValueObject;

namespace AS.FOS.App.Common.Domain.Entity;

public abstract class BaseEntity<T> where T: BaseId<Guid>
{
    public T Id { get; }

    protected BaseEntity(T id)
    {
        Id = id;
    }
    protected BaseEntity()
    {
        
    }
}
