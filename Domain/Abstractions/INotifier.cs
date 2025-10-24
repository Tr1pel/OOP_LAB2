using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;

public interface INotifier
{
    // Запустить оповещение и вернуть результат без исключений
    NotifyResult Notify();
}