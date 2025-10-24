using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;

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