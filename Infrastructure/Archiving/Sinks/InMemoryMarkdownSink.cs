using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving.Sinks;

public sealed class InMemoryMarkdownSink : IFormattedSink
{
    private readonly List<FormattedMarkdown> _storage = new();

    public IReadOnlyCollection<FormattedMarkdown> Storage => _storage.AsReadOnly();

    public ArchiveResult Save(string titleMarkdown, string bodyMarkdown)
    {
        _storage.Add(new FormattedMarkdown(titleMarkdown, bodyMarkdown));
        return new ArchiveResult.Success();
    }
}