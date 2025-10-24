namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

// Заголовок сообщения
public readonly record struct Title
{
    private const int MaxLength = 200;

    public string Value { get; }

    private Title(string value)
    {
        Value = value;
    }

    public static bool TryCreate(string? value, out Title title)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            title = default;
            return false;
        }

        string trimmed = value.Trim(); // убираем лишние пробелы
        if (trimmed.Length > MaxLength)
        {
            title = default;
            return false;
        }

        title = new Title(trimmed);
        return true;
    }
}