using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;

public interface IFormatter
{
    // отформатировать заголовок сообщения
    string FormatTitle(Message message);

    string FormatBody(Message message);
}