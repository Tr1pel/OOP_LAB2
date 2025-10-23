using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;

public sealed class Message
{
    public Message(MessageId id, Title title, Body body, Importance importance, Timestamp timestamp)
    {
        Id = id;
        Title = title;
        Body = body;
        Importance = importance;
        Timestamp = timestamp;
    }

    public MessageId Id { get; }

    public Title Title { get; }

    public Body Body { get; }

    public Importance Importance { get; }

    public Timestamp Timestamp { get; }
}