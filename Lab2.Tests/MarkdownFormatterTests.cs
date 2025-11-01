using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Formatting;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Sinks;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class MarkdownFormatterTests
{
    private sealed class SpyConsoleWriter : IConsoleWriter
    {
        public List<string> Lines { get; } = new();

        public void WriteLine(string value)
        {
            Lines.Add(value);
        }
    }

    private sealed class SpyFileWriter : IFileWriter
    {
        public List<(string Path, string Content, bool Overwrite)> Writes { get; } = new();

        void IFileWriter.AppendAllText(string path, string contents)
        {
            Writes.Add((path, contents, false));
        }

        void IFileWriter.WriteAllText(string path, string contents)
        {
            Writes.Add((path, contents, true));
        }
    }

    [Fact]
    public void WriteTitle_WritesH1_ToConsoleAndFile_WithOverwriteMode()
    {
        var console = new SpyConsoleWriter();
        var file = new SpyFileWriter();
        var formatter = new MarkdownFormatter(console, file, "out.md", WriteMode.Overwrite);

        Message message = MessageFactory.Create(title: "T", body: "B", importance: 2);
        formatter.WriteTitle(message);

        Assert.Contains(console.Lines, l => l.StartsWith("# T"));
        Assert.Contains(file.Writes, w => w.Path == "out.md" && w.Overwrite == true && w.Content.StartsWith("# T"));
    }

    [Fact]
    public void WriteBody_WritesImportanceAndBody_ToConsoleAndAppendsToFile()
    {
        var console = new SpyConsoleWriter();
        var file = new SpyFileWriter();
        var formatter = new MarkdownFormatter(console, file, "out.md", WriteMode.Append);

        Message message = MessageFactory.Create(title: "T", body: "BodyX", importance: 3);
        formatter.WriteBody(message);

        Assert.Contains(console.Lines, l => l.Contains("**Importance:**", StringComparison.Ordinal));
        Assert.Contains(file.Writes, w => w.Path == "out.md" && w.Overwrite == false && w.Content.Contains("BodyX", StringComparison.Ordinal));
    }
}