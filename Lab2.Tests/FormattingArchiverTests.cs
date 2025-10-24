using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

// Тесты для форматирующего архиватора
public class FormattingArchiverTests
{
    private interface IMessageFormatter { string Format(Message message); }

    private interface IArchiveStorage { void Save(string formattedMessage); }

    private sealed class FakeFormatter : IMessageFormatter
    {
        public int Calls { get; private set; }

        public Message? LastMessage { get; private set; }

        public string Format(Message message)
        {
            Calls++;
            LastMessage = message;
            return $"# {message.Title}\n\n{message.Body}";
        }
    }

    private sealed class SpyArchiveStorage : IArchiveStorage
    {
        public int SaveCalls { get; private set; }

        public List<string> Saved { get; } = new();

        public void Save(string formattedMessage)
        {
            SaveCalls++;
            Saved.Add(formattedMessage);
        }
    }

    private sealed class FormattingArchiver
    {
        private readonly IMessageFormatter _formatter;
        private readonly IArchiveStorage _storage;

        public FormattingArchiver(IMessageFormatter formatter, IArchiveStorage storage)
        {
            _formatter = formatter;
            _storage = storage;
        }

        public void Archive(Message message)
        {
            string formatted = _formatter.Format(message);
            _storage.Save(formatted);
        }
    }

    [Fact]
    public void FormattingArchiver_ShouldFormatAndSave()
    {
        var formatter = new FakeFormatter();
        var storage = new SpyArchiveStorage();
        var archiver = new FormattingArchiver(formatter, storage);
        Message message = MessageFactory.Create(title: "Hello", body: "World", importance: 2);

        archiver.Archive(message);

        Assert.Equal(1, formatter.Calls);
        Assert.Equal(1, storage.SaveCalls);
        Assert.Single(storage.Saved);
        Assert.Equal("# Hello\n\nWorld", storage.Saved[0]);
    }
}