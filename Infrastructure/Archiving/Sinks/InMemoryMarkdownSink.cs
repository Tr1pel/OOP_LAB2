using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving.Sinks;

// Хранит Markdown
public sealed class InMemoryMarkdownSink : IFormattedSink
{
    private readonly List<FormattedMarkdown> _storage = new(); // буфер в памяти

    public IReadOnlyCollection<FormattedMarkdown> Storage => _storage.AsReadOnly();

    public ArchiveResult Save(string titleMarkdown, string bodyMarkdown)
    {
        _storage.Add(new FormattedMarkdown(titleMarkdown, bodyMarkdown)); // кладём запись
        return new ArchiveResult.Success();
    }
}