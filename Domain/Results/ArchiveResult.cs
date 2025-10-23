namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

// Сохранение и архивация сообщения
public abstract record ArchiveResult
{
    private ArchiveResult() { }

    public sealed record Success : ArchiveResult;

    // ошибка хранилища или инфраструктуры
    public sealed record StorageError(string Error) : ArchiveResult;
}