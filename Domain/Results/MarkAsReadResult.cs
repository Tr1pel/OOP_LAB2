namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

// Отметка сообщения прочитанным в контексте конкретного пользователя
public abstract record MarkAsReadResult
{
    private MarkAsReadResult() { }

    public sealed record Success : MarkAsReadResult;

    // повторная отметка прочитанного
    public sealed record AlreadyRead : MarkAsReadResult;

    // сообщение не найдено в почтовом ящике пользователя
    public sealed record NotFound : MarkAsReadResult;
}