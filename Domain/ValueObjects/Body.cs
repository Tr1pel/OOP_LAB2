namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

// Тело сообщения
public readonly record struct Body
{
    public const int MaxLength = 4000; // граница длины тела

    public string Value { get; }

    private Body(string value)
    {
        Value = value;
    }

    public static bool TryCreate(string? value, out Body body)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            body = default;
            return false;
        }

        string normalized = value.Trim();
        if (normalized.Length > MaxLength)
        {
            body = default;
            return false;
        }

        body = new Body(normalized);
        return true;
    }
}