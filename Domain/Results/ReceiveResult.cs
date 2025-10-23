namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;

// Получение и доставка сообщения до адресата
public abstract record ReceiveResult
{
    private ReceiveResult() { }

    public sealed record Success : ReceiveResult;

    // сообщение отфильтровано по уровню важности — не доставлено адресату
    public sealed record FilteredOut : ReceiveResult;

    // только залогировано
    public sealed record LoggedOnly : ReceiveResult;

    // доменная ситуация: такое сообщение уже есть у адресата
    public sealed record Duplicate : ReceiveResult;

    // технический сбой в процессе доставки
    public sealed record Failed(string Reason) : ReceiveResult;
}