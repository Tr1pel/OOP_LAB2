namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

// Идентификатор пользователя
public readonly record struct UserId
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static bool TryCreate(Guid value, out UserId id)
    {
        if (value == Guid.Empty)
        {
            id = default;
            return false;
        }

        id = new UserId(value);
        return true;
    }

    public static UserId New() => new UserId(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}