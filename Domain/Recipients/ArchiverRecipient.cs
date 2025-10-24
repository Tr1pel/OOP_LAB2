using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

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
        // пытаемся сохранить в архив
        ArchiveResult result = _archive.Save(message);
        return result switch
        {
            ArchiveResult.Success => new ReceiveResult.Success(), // сообщение доставлено
            ArchiveResult.StorageError err => new ReceiveResult.Failed(err.Error), // проблема хранилища
            _ => new ReceiveResult.Failed("UnknownArchiveResult"),
        };
    }
}