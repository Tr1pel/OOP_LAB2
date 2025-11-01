using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FormattingArchiverTests
{
    private sealed class SpyFormatter : IFormatter
    {
        public int WriteTitleCount { get; private set; }

        public int WriteBodyCount { get; private set; }

        public Message? LastMessage { get; private set; }

        void IFormatter.WriteTitle(Message message)
        {
            WriteTitleCount++;
            LastMessage = message;
        }

        void IFormatter.WriteBody(Message message)
        {
            WriteBodyCount++;
            LastMessage = message;
        }
    }

    [Fact]
    public void FormattingArchive_ShouldCallFormatterWriteMethods()
    {
        var spy = new SpyFormatter();
        var archiver = new FormattingArchive(spy);
        Message message = MessageFactory.Create(title: "Hello", body: "World", importance: 2);

        archiver.Save(message);

        Assert.Equal(1, spy.WriteTitleCount);
        Assert.Equal(1, spy.WriteBodyCount);
        Assert.Equal(message, spy.LastMessage);
    }
}