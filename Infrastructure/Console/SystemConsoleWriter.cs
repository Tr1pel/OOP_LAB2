using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Console;

public sealed class SystemConsoleWriter : IConsoleWriter
{
    public void WriteLine(string value)
    {
        System.Console.WriteLine(value);
    }
}