using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public sealed class CompositeRecipient : IRecipient
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public CompositeRecipient(IReadOnlyCollection<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public ReceiveResult Receive(Message message)
    {
        ReceiveResult[] results = _recipients.Select(r => r.Receive(message)).ToArray();

        return results.Any(r => r is ReceiveResult.Success)
            ? new ReceiveResult.Success()
            : results.FirstOrDefault() ?? new ReceiveResult.LoggedOnly();
    }
}