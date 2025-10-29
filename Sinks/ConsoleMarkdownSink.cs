using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

// Синк архивации в консоль
namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

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