using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adapters.Console;

// Инфраструктурный писатель в консоль
public sealed class SystemConsoleWriter : IConsoleWriter
{
    public void WriteLine(string value)
    {
        System.Console.WriteLine(value);
    }
}