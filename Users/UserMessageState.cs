namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

// состояния сообщения
public readonly record struct UserMessageState
{
    private UserMessageState(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static readonly UserMessageState Unread = new("Unread");

    public static readonly UserMessageState Read = new("Read");
}