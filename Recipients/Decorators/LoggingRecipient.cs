using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients.Decorators;

// Декоратор получателя
public sealed class LoggingRecipient : IRecipient
{
    private readonly IRecipient _inner;
    private readonly ILogger _logger;

    public LoggingRecipient(IRecipient inner, ILogger logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public ReceiveResult Receive(Message message)
    {
        _logger.Info($"Receive -> {message.Id}: {message.Title}"); // вход в операцию

        ReceiveResult result = _inner.Receive(message);

        // маршрутизация по результатам
        switch (result)
        {
            case ReceiveResult.Success:
                _logger.Info($"Receive <- {message.Id}: Success");
                break;
            case ReceiveResult.Failed failed:
                _logger.Err($"Receive <- {message.Id}: Failed: {failed.Reason}");
                break;
            default:
                _logger.Info($"Receive <- {message.Id}: {result.GetType().Name}");
                break;
        }

        return result;
    }
}