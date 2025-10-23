using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Decorators;

public sealed class LoggingRecipient : IRecipient
{
    private readonly IRecipient _inner;
    private readonly ILogger _logger;

    public LoggingRecipient(IRecipient inner, ILogger logger)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public ReceiveResult Receive(Message message)
    {
        _logger.Info($"Receive -> {message.Id}: {message.Title}");
        ReceiveResult result = _inner.Receive(message);
        _logger.Info($"Receive <- {message.Id}: {result.GetType().Name}");
        return result is ReceiveResult.Failed f
            ? new ReceiveResult.LoggedOnly()
            : result;
    }
}