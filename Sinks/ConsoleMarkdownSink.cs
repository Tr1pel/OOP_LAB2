using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

// Синк архивации в консоль
namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

public sealed class ConsoleMarkdownSink : IFormattedSink
{
    private readonly IConsoleWriter _console;

    public ConsoleMarkdownSink(IConsoleWriter console)
    {
        _console = console;
    }

    public void Save(string titleMarkdown, string bodyMarkdown)
    {
        _console.WriteLine(titleMarkdown);
        _console.WriteLine(bodyMarkdown);
    }
}