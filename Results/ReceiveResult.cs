namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

// Получение и доставка сообщения до адресата
public abstract record ReceiveResult
{
    private ReceiveResult() { }

    public sealed record Success : ReceiveResult;

    // технический сбой в процессе доставки
    public sealed record Failed(string Reason) : ReceiveResult;
}