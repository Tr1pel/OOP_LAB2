using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

public interface IArchive
{
    void Save(Message message);
}