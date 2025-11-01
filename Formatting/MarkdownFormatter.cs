using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Sinks;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

// Форматтер Markdown
public sealed class MarkdownFormatter : IFormatter
{
    private readonly IConsoleWriter? _console;
    private readonly IFileWriter? _fileWriter;
    private readonly string? _filePath;
    private readonly WriteMode _fileMode;

    public MarkdownFormatter(
        IConsoleWriter? console = null,
        IFileWriter? fileWriter = null,
        string? filePath = null,
        WriteMode fileMode = WriteMode.Append)
    {
        _console = console;
        _fileWriter = fileWriter;
        _filePath = filePath;
        _fileMode = fileMode;
    }

    // заголовок как H1
    public void WriteTitle(Message message)
    {
        string titleLine = $"# {message.Title.Value}";

        _console?.WriteLine(titleLine);

        if (_fileWriter is not null && _filePath is not null)
        {
            string content = titleLine + Environment.NewLine;
            if (_fileMode == WriteMode.Overwrite)
            {
                _fileWriter.WriteAllText(_filePath, content);
            }
            else
            {
                _fileWriter.AppendAllText(_filePath, content);
            }
        }
    }

    public void WriteBody(Message message)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"**Importance:** {message.Importance.Name}");
        sb.AppendLine();
        sb.AppendLine(message.Body.Value);
        string bodyBlock = sb.ToString();

        _console?.WriteLine(bodyBlock);

        if (_fileWriter is not null && _filePath is not null)
        {
            _fileWriter.AppendAllText(_filePath, bodyBlock);
        }
    }
}