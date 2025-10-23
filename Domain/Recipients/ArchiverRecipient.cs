using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public sealed class ArchiverRecipient : IRecipient
{
    private readonly IArchive _archive;

    public ArchiverRecipient(IArchive archive)
    {
        _archive = archive;
    }

    public ReceiveResult Receive(Message message)
    {
        ArchiveResult result = _archive.Save(message);
        return result switch
        {
            ArchiveResult.Success => new ReceiveResult.Success(),
            ArchiveResult.StorageError err => new ReceiveResult.Failed(err.Error),
            _ => new ReceiveResult.Failed("UnknownArchiveResult"),
        };
    }
}