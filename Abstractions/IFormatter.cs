using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

public interface IFormatter
{
    // отформатировать заголовок сообщения
    string FormatTitle(Message message);

    string FormatBody(Message message);
}