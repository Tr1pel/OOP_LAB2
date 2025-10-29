namespace Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

public interface ILogger
{
    void Info(string message);

    void Warn(string message);

    void Err(string message);
}