using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

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

        // если хотя бы один успех, то считаем доставленным
        // иначе возвращаем первый результат
        return results.Any(r => r is ReceiveResult.Success)
            ? new ReceiveResult.Success()
            : results.FirstOrDefault() ?? new ReceiveResult.LoggedOnly();
    }
}