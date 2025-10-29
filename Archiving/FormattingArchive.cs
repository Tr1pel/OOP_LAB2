using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiving;

// Форматирует и отправляет в синк
public sealed class FormattingArchive : IArchive
{
    private readonly IFormatter _formatter;

    public FormattingArchive(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Save(Message message)
    {
        _formatter.WriteTitle(message);
        _formatter.WriteBody(message);
    }
}