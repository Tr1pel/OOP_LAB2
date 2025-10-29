using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

// Получатель, который архивирует сообщение
public sealed class ArchiverRecipient : IRecipient
{
    private readonly IArchive _archive;

    public ArchiverRecipient(IArchive archive)
    {
        _archive = archive;
    }

    public ReceiveResult Receive(Message message)
    {
        _archive.Save(message);
        return new ReceiveResult.Success();
    }
}