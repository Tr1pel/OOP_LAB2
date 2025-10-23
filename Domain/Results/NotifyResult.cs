namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

// Оповещения
public abstract record NotifyResult
{
    private NotifyResult() { }

    public sealed record Success : NotifyResult;

    // канал недоступен
    public sealed record ChannelUnavailable(string ChannelName, string? Reason) : NotifyResult;
}