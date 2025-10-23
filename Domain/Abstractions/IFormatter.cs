using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;

public interface IFormatter
{
    string FormatTitle(Message message);

    string FormatBody(Message message);
}