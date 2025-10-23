using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Notifications;

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