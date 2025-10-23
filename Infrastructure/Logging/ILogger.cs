namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Logging;

public interface ILogger
{
    void Info(string message);

    void Warn(string message);

    void Err(string message);
}