using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Notifications;

// Выводит строку через консоль
public sealed class TextNotifier : INotifier
{
    private readonly IConsoleWriter _console;
    private readonly string _message;

    public TextNotifier(IConsoleWriter console, string message)
    {
        _console = console;
        _message = message;
    }

    public NotifyResult Notify()
    {
        _console.WriteLine(_message);
        return new NotifyResult.Success();
    }
}