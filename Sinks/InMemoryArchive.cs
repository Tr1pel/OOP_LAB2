using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

// Памятный архив
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