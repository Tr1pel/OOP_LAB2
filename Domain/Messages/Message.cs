using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;

// Неизменяемое доменное сообщение
public sealed class Message
{
    public Message(MessageId id, Title title, Body body, Importance importance, Timestamp timestamp)
    {
        Id = id;
        Title = title;
        Body = body;
        Importance = importance; // Важность
        Timestamp = timestamp; // Момент создания или приема
    }

    public MessageId Id { get; }

    public Title Title { get; }

    public Body Body { get; }

    public Importance Importance { get; }

    public Timestamp Timestamp { get; }
}