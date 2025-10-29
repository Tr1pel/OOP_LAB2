using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Sinks;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiving;

// Форматирует и отправляет в синк
public sealed class FormattingArchive : IArchive
{
    private readonly IFormatter _formatter; // кто форматирует
    private readonly IFormattedSink _sink; // куда сохраняем

    public FormattingArchive(IFormatter formatter, IFormattedSink sink)
    {
        _formatter = formatter;
        _sink = sink;
    }

    public ArchiveResult Save(Message message)
    {
        string title = _formatter.FormatTitle(message); // рендерим заголовок
        string body = _formatter.FormatBody(message); // рендерим тело
        return _sink.Save(title, body); // сохраняем
    }
}