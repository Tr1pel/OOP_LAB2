using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

// Компоновщик получателей
public sealed class CompositeRecipient : IRecipient
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public CompositeRecipient(IReadOnlyCollection<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public ReceiveResult Receive(Message message)
    {
        // собираем результаты от всех получателей
        ReceiveResult[] results = _recipients.Select(r => r.Receive(message)).ToArray();

        return new ReceiveResult.Success();
    }
}