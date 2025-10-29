using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

public interface INotifier
{
    // Запустить оповещение и вернуть результат без исключений
    NotifyResult Notify();
}