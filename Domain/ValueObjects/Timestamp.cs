namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

// Метки времени
public readonly record struct Timestamp : IComparable<Timestamp>
{
    private readonly DateTimeOffset _value;

    private Timestamp(DateTimeOffset valueUtc)
    {
        _value = valueUtc;
    }

    public static bool TryCreate(DateTimeOffset value, out Timestamp ts)
    {
        // не допускаем default(DateTimeOffset) остальные значения валидны
        if (value == default)
        {
            ts = default;
            return false;
        }

        ts = new Timestamp(value.ToUniversalTime());
        return true;
    }

    // Текущее время
    public static Timestamp Now() => new Timestamp(DateTimeOffset.UtcNow);

    public int CompareTo(Timestamp other) => _value.CompareTo(other._value);
}