using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving.Sinks;

public sealed class InMemoryMarkdownSink : IFormattedSink
{
    private readonly List<(string Title, string Body)> _storage = new();

    public IReadOnlyCollection<(string Title, string Body)> Storage => _storage;

    public ArchiveResult Save(string titleMarkdown, string bodyMarkdown)
    {
        _storage.Add((titleMarkdown, bodyMarkdown));
        return new ArchiveResult.Success();
    }
}