using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public sealed class UserRecipient : IRecipient
{
    private readonly User _user;

    public UserRecipient(User user)
    {
        _user = user;
    }

    public ReceiveResult Receive(Message message) => _user.Receive(message);
}