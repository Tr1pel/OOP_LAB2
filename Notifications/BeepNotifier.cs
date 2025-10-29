using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Notifications;

// Даёт звуковой сигнал
public sealed class BeepNotifier : INotifier
{
    private readonly IBeepDevice _beep;

    public BeepNotifier(IBeepDevice beep)
    {
        _beep = beep;
    }

    public NotifyResult Notify()
    {
        _beep.Beep();
        return new NotifyResult.Success();
    }
}