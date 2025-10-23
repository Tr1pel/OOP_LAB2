using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving.Sinks;

public sealed class ConsoleMarkdownSink : IFormattedSink
{
    private readonly IConsoleWriter _console;

    public ConsoleMarkdownSink(IConsoleWriter console)
    {
        _console = console;
    }

    public ArchiveResult Save(string titleMarkdown, string bodyMarkdown)
    {
        _console.WriteLine(titleMarkdown);
        _console.WriteLine(bodyMarkdown);
        return new ArchiveResult.Success();
    }
}