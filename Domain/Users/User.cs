using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

// Хранит входящие и меняет их состояние
public sealed class User
{
    private readonly Dictionary<MessageId, UserMessageState> _inbox = new();

    public IReadOnlyDictionary<MessageId, UserMessageState> Inbox => _inbox;

    public ReceiveResult Receive(Message message)
    {
        // дубликаты не принимаем повторно
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
        // есть ли сообщение в инбоксе
        if (_inbox.TryGetValue(id, out UserMessageState state) is false)
        {
            return new MarkAsReadResult.NotFound();
        }

        // отметка "прочитано"
        if (state.Equals(UserMessageState.Read))
        {
            return new MarkAsReadResult.AlreadyRead();
        }

        // меняем статус и подтверждаем успех
        _inbox[id] = UserMessageState.Read;
        return new MarkAsReadResult.Success();
    }
}