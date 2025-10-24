using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Decorators;

// Декоратор получателя
public sealed class LoggingRecipient : IRecipient
{
    private readonly IRecipient _inner;
    private readonly ILogger _logger;

    public LoggingRecipient(IRecipient inner, ILogger logger)
    {
        // обязательный декорируемый и логгер
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            case ReceiveResult.FilteredOut:
                _logger.Warn($"Receive <- {message.Id}: FilteredOut");
                break;
            case ReceiveResult.Duplicate:
                _logger.Warn($"Receive <- {message.Id}: Duplicate");
                break;
            case ReceiveResult.LoggedOnly:
                _logger.Info($"Receive <- {message.Id}: LoggedOnly");
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