using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

// Абстракция получателя сообщения
public interface IRecipient
{
    ReceiveResult Receive(Message message);
}