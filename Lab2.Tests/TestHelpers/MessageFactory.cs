using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;

public static class MessageFactory
{
    public static Message Create(
        string title = "Test Title",
        string body = "Test Body",
        int importance = 1,
        DateTimeOffset? timestampUtc = null)
    {
        var id = MessageId.New();

        // через TryCreate
        if (!Title.TryCreate(title, out Title t))
        {
            throw new ArgumentException("Invalid Title for test data", nameof(title));
        }

        if (!Body.TryCreate(body, out Body b))
        {
            throw new ArgumentException("Invalid Body for test data", nameof(body));
        }

        if (!Importance.TryCreate(importance, out Importance imp))
        {
            throw new ArgumentException("Invalid Importance code (allowed 0..3)", nameof(importance));
        }

        Timestamp ts = timestampUtc is null
            ? Timestamp.Now()
            : (Timestamp.TryCreate(timestampUtc.Value, out Timestamp createdTs)
                ? createdTs
                : throw new ArgumentException("Invalid Timestamp for test data", nameof(timestampUtc)));

        return new Message(id, t, b, imp, ts);
    }
}