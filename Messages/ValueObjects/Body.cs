namespace Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;

// Тело сообщения
public readonly record struct Body
{
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
        body = new Body(normalized);
        return true;
    }
}