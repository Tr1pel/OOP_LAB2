using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Notifications;

public interface INotifier
{
    NotifyResult Notify();
}