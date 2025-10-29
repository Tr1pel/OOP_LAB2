using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

public interface IFormatter
{
    void WriteTitle(Message message);

    void WriteBody(Message message);
}