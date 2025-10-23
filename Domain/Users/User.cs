using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

public sealed class User
{
    private readonly Dictionary<MessageId, UserMessageState> _inbox = new();

    public IReadOnlyDictionary<MessageId, UserMessageState> Inbox => _inbox;

    public ReceiveResult Receive(Message message)
    {
        // guard: дубликаты не принимаем повторно
        if (_inbox.ContainsKey(message.Id))
        {
            return new ReceiveResult.Duplicate();
        }

        // кладём новое сообщение в статусе "не прочитано"
        _inbox[message.Id] = UserMessageState.Unread;

        return new ReceiveResult.Success();
    }

    public MarkAsReadResult MarkAsRead(MessageId id)
    {
        if (_inbox.TryGetValue(id, out UserMessageState state) is false)
            return new MarkAsReadResult.NotFound();

        if (state.Equals(UserMessageState.Read))
            return new MarkAsReadResult.AlreadyRead();

        _inbox[id] = UserMessageState.Read;
        return new MarkAsReadResult.Success();
    }
}