using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Formatting;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving;

public sealed class FormattingArchive : IArchive
{
    private readonly IFormatter _formatter;
    private readonly IFormattedSink _sink;

    public FormattingArchive(IFormatter formatter, IFormattedSink sink)
    {
        _formatter = formatter;
        _sink = sink;
    }

    public ArchiveResult Save(Message message)
    {
        string title = _formatter.FormatTitle(message);
        string body = _formatter.FormatBody(message);
        return _sink.Save(title, body);
    }
}

public interface IFormattedSink
{
    ArchiveResult Save(string titleMarkdown, string bodyMarkdown);
}