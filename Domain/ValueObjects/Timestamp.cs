namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

public readonly record struct Timestamp : IComparable<Timestamp>
{
    public DateTimeOffset Value { get; }

    private Timestamp(DateTimeOffset valueUtc)
    {
        Value = valueUtc;
    }

    public static bool TryCreate(DateTimeOffset value, out Timestamp ts)
    {
        // Не допускаем default(DateTimeOffset). Остальные значения валидны.
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

    public int CompareTo(Timestamp other) => Value.CompareTo(other.Value);

    public override string ToString() => Value.ToString("O"); // ISO 8601
}