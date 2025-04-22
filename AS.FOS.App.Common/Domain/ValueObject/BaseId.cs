namespace AS.FOS.App.Common.Domain.ValueObject;

public abstract class BaseId<T> : BaseValueObject<T>
{
    public T Value { get; }

    public BaseId(T value)
    {
        if (EqualityComparer<T>.Default.Equals(value,default(T)))
            throw new ArgumentException("ID cannot be empty.", nameof(value));

        Value = value;
    }

    protected override IEnumerable<T> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value!.ToString()!;
}
