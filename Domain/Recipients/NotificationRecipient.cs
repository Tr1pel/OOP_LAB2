using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

// Получатель-нотификатор
public sealed class NotificationRecipient : IRecipient
{
    private readonly INotifier _notifier; // канала уведомлений
    private readonly string[] _keywords; // триггеры для отправки

    public NotificationRecipient(INotifier notifier, params string[] keywords)
    {
        _notifier = notifier;
        _keywords = keywords ?? []; // пустой список (ничего не триггерит)
    }

    public ReceiveResult Receive(Message message)
    {
        // содержит ли заголовок/тело хотя бы одно ключевое слово
        bool hasKeyword = _keywords.Any(k =>
            message.Title.ToString().Contains(k, System.StringComparison.OrdinalIgnoreCase) ||
            message.Body.ToString().Contains(k, System.StringComparison.OrdinalIgnoreCase));

        if (!hasKeyword)
        {
            return new ReceiveResult.FilteredOut();
        }

        NotifyResult result = _notifier.Notify();
        return result switch
        {
            NotifyResult.Success => new ReceiveResult.Success(), // оповещение ушло
            NotifyResult.ChannelUnavailable err => new ReceiveResult.Failed(err.ChannelName), // канал недоступен
            _ => new ReceiveResult.Failed("ChannelUnavailable"),
        };
    }
}