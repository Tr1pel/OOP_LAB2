using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving;

public sealed class InMemoryArchive : IArchive
{
    private readonly List<Message> _storage = new();

    public IReadOnlyCollection<Message> Storage => _storage.AsReadOnly();

    public ArchiveResult Save(Message message)
    {
        _storage.Add(message);
        return new ArchiveResult.Success();
    }
}