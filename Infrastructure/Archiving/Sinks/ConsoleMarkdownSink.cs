using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

// Синк архивации в консоль
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
        _console.WriteLine(titleMarkdown); // печатаем заголовок
        _console.WriteLine(bodyMarkdown); // печатаем тело
        return new ArchiveResult.Success();
    }
}