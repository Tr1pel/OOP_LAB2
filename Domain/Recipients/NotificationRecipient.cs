using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public sealed class NotificationRecipient : IRecipient
{
    private readonly INotifier _notifier;
    private readonly string[] _keywords;

    public NotificationRecipient(INotifier notifier, params string[] keywords)
    {
        _notifier = notifier;
        _keywords = keywords ?? [];
    }

    public ReceiveResult Receive(Message message)
    {
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
            NotifyResult.Success => new ReceiveResult.Success(),
            NotifyResult.ChannelUnavailable err => new ReceiveResult.Failed(err.ChannelName),
            _ => new ReceiveResult.Failed("ChannelUnavailable"),
        };
    }
}