using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

// Эти тесты покрывают кейсы про фильтры и логирование адресата
public class RecipientFiltersAndLoggingTests
{
    public interface IRecipient { void Deliver(Message message); }

    public interface ILogger { void Log(string message); }

    private sealed class SpyLogger : ILogger
    {
        public int CallCount { get; private set; }

        public List<string> Entries { get; } = new();

        public void Log(string message)
        {
            CallCount++;
            Entries.Add(message);
        }
    }

    private sealed class SpyRecipient : IRecipient
    {
        public int DeliverCallCount { get; private set; }

        public List<Message> Received { get; } = new();

        public void Deliver(Message message)
        {
            DeliverCallCount++;
            Received.Add(message);
        }
    }

    private sealed class ImportanceFilteringRecipient : IRecipient
    {
        private readonly IRecipient _inner;
        private readonly Importance _minImportance;

        public ImportanceFilteringRecipient(IRecipient inner, Importance minImportance)
        {
            _inner = inner;
            _minImportance = minImportance;
        }

        public void Deliver(Message message)
        {
            if (message.Importance >= _minImportance)
                _inner.Deliver(message);
        }
    }

    private sealed class LoggingRecipient : IRecipient
    {
        private readonly IRecipient _inner;
        private readonly ILogger _logger;

        public LoggingRecipient(IRecipient inner, ILogger logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public void Deliver(Message message)
        {
            _logger.Log($"Received {message.Id} with {message.Importance}");
            _inner.Deliver(message);
        }
    }

    [Fact]
    public void Recipient_WithFilter_ShouldBlockLowImportance()
    {
        var inner = new SpyRecipient();
        var filtered = new ImportanceFilteringRecipient(inner, Importance.High);
        Message msg = MessageFactory.Create(importance: 1); // Normal

        filtered.Deliver(msg);

        Assert.Equal(0, inner.DeliverCallCount);
        Assert.Empty(inner.Received);
    }

    [Fact]
    public void Recipient_WithLogging_ShouldWriteLogOnDeliver()
    {
        var inner = new SpyRecipient();
        var logger = new SpyLogger();
        var logging = new LoggingRecipient(inner, logger);
        Message msg = MessageFactory.Create(importance: 3); // Critical

        logging.Deliver(msg);

        Assert.Equal(1, logger.CallCount);
        Assert.Single(inner.Received, msg);
        Assert.Contains(logger.Entries, s => s.Contains(msg.Id.Value.ToString("D"), StringComparison.Ordinal));
    }
}