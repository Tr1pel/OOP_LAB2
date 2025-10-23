using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving;

public interface IArchive
{
    ArchiveResult Save(Message message);
}