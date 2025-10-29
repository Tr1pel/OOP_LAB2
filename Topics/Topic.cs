using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

// Хранит получателей и публикует им сообщения
public sealed class Topic
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public Topic(Title name, IReadOnlyCollection<IRecipient> recipients)
    {
        Name = name;
        _recipients = recipients;
    }

    public Title Name { get; }

    // публикация в топик
    public IReadOnlyCollection<ReceiveResult> Publish(Message message)
    {
        return _recipients.Select(r => r.Receive(message)).ToArray();
    }
}