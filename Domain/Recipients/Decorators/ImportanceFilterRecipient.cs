using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Decorators;

public sealed class ImportanceFilterRecipient : IRecipient
{
    private readonly IRecipient _inner;
    private readonly Importance _minImportance;

    public ImportanceFilterRecipient(IRecipient inner, Importance minImportance)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _minImportance = minImportance;
    }

    public ReceiveResult Receive(Message message)
    {
        if (message.Importance.CompareTo(_minImportance) < 0)
            return new ReceiveResult.FilteredOut();

        return _inner.Receive(message);
    }
}