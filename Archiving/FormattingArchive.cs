using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Sinks;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiving;

// Форматирует и отправляет в синк
public sealed class FormattingArchive : IArchive
{
    private readonly IFormatter _formatter;
    private readonly IFormattedSink _sink;

    public FormattingArchive(IFormatter formatter, IFormattedSink sink)
    {
        _formatter = formatter;
        _sink = sink;
    }

    public void Save(Message message)
    {
        string title = _formatter.FormatTitle(message);
        string body = _formatter.FormatBody(message);
        _sink.Save(title, body);
    }
}