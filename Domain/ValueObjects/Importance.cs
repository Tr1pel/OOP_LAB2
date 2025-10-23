namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

// Уровень важности сообщения
public readonly record struct Importance
{
    public static readonly Importance Low = new Importance(0, "Low");
    public static readonly Importance Normal = new Importance(1, "Normal");
    public static readonly Importance High = new Importance(2, "High");
    public static readonly Importance Critical = new Importance(3, "Critical");

    public int Code { get; }

    public string Name { get; }

    private Importance(int code, string name)
    {
        Code = code;
        Name = name;
    }

    // --- сравнение VO (по Code) ---
    public int CompareTo(Importance other) => Code.CompareTo(other.Code);

    public static bool operator <(Importance left, Importance right) => left.CompareTo(right) < 0;

    public static bool operator >(Importance left, Importance right) => left.CompareTo(right) > 0;

    public static bool operator <=(Importance left, Importance right) => left.CompareTo(right) <= 0;

    public static bool operator >=(Importance left, Importance right) => left.CompareTo(right) >= 0;

    // Создание по коду (0..3)
    public static bool TryCreate(int code, out Importance importance)
    {
        switch (code)
        {
            case 0: importance = Low; return true;
            case 1: importance = Normal; return true;
            case 2: importance = High; return true;
            case 3: importance = Critical; return true;
            default:
                importance = default;
                return false;
        }
    }

    // Создание по имени
    public static bool TryCreate(string? name, out Importance importance)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            importance = default;
            return false;
        }

        switch (name.Trim().ToLowerInvariant())
        {
            case "low": importance = Low; return true;
            case "normal": importance = Normal; return true;
            case "high": importance = High; return true;
            case "critical": importance = Critical; return true;
            default:
                importance = default;
                return false;
        }
    }

    public override string ToString() => Name;
}