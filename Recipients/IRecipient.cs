using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

// Абстракция получателя сообщения
public interface IRecipient
{
    ReceiveResult Receive(Message message);
}