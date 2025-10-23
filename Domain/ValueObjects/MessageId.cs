namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

// Идентификатор сообщения
public readonly record struct MessageId
{
    public Guid Value { get; }

    private MessageId(Guid value)
    {
        Value = value;
    }

    public static bool TryCreate(Guid value, out MessageId id)
    {
        if (value == Guid.Empty)
        {
            id = default;
            return false;
        }

        id = new MessageId(value);
        return true;
    }

    // Создать новый идентификатор
    public static MessageId New() => new MessageId(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}