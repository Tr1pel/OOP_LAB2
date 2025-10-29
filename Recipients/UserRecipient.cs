using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

// Получатель, доставляющий сообщение конкретному пользователю
public sealed class UserRecipient : IRecipient
{
    private readonly User _user; // кому

    public UserRecipient(User user)
    {
        _user = user;
    }

    public ReceiveResult Receive(Message message) => _user.Receive(message);
}