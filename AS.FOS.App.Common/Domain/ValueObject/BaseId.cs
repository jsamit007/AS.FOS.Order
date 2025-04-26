namespace AS.FOS.App.Common.Domain.ValueObject;

public abstract class BaseId<T> : BaseValueObject<T>
{
    public T Value { get; }

    protected BaseId(T value)
    {
        Value = value;
    }

    protected BaseId()
    {
        
    }

    protected override IEnumerable<T> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value!.ToString()!;
}
