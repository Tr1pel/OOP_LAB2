using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients.Decorators;
using Itmo.ObjectOrientedProgramming.Lab2.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class RecipientFiltersAndLoggingTests
{
    private sealed class SpyRecipient : IRecipient
    {
        public int ReceiveCallCount { get; private set; }

        public List<Message> Received { get; } = new();

        public ReceiveResult Receive(Message message)
        {
            ReceiveCallCount++;
            Received.Add(message);
            return new ReceiveResult.Success();
        }
    }

    private sealed class SpyLogger : ILogger
    {
        public int InfoCount { get; private set; }

        public int ErrCount { get; private set; }

        public List<string> Entries { get; } = new();

        public void Info(string message)
        {
            InfoCount++;
            Entries.Add(message);
        }

        public void Warn(string message) { /* _ */ }

        public void Err(string message)
        {
            ErrCount++;
            Entries.Add(message);
        }
    }

    [Fact]
    public void Recipient_WithFilter_ShouldBlockLowImportance()
    {
        var inner = new SpyRecipient();
        #pragma warning disable CA1859
        IRecipient filtered = new ImportanceFilterRecipient(inner, Importance.High);
        Message msg = MessageFactory.Create(importance: 1);

        ReceiveResult res = filtered.Receive(msg);

        Assert.Equal(0, inner.ReceiveCallCount);
    }

    [Fact]
    public void Recipient_WithLogging_ShouldWriteLogOnDeliver()
    {
        var inner = new SpyRecipient();
        var logger = new SpyLogger();
        IRecipient logging = new LoggingRecipient(inner, logger);

        Message msg = MessageFactory.Create(importance: 3);
        ReceiveResult result = logging.Receive(msg);

        Assert.IsType<ReceiveResult.Success>(result);
        Assert.Equal(1, inner.ReceiveCallCount);
        Assert.True(logger.InfoCount >= 1);
        Assert.Contains(logger.Entries, s => s.Contains(msg.Id.Value.ToString("D"), StringComparison.Ordinal));
    }
}