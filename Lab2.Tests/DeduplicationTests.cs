using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class DeduplicationTests
{
    // примерные примитивные адресаты для теста
    private interface IRecipient { void Deliver(Message message); }

    private sealed class UserRecipient : IRecipient
    {
        private readonly User _user;

        public UserRecipient(User user)
        {
            _user = user;
        }

        public void Deliver(Message message) => _user.Receive(message);
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
            // простая композиция: сообщение передаётся всем адресатам
            if (message.Importance >= _minImportance)
            {
                _inner.Deliver(message);
            }
        }
    }

    private sealed class GroupRecipient : IRecipient
    {
        private readonly IReadOnlyCollection<IRecipient> _recipients;

        public GroupRecipient(params IRecipient[] recipients)
        {
            _recipients = recipients;
        }

        public void Deliver(Message message)
        {
            foreach (IRecipient r in _recipients) r.Deliver(message);
        }
    }

    [Fact]
    public void TwoRecipientsOneUser_WithFilter_ShouldDeliverOnceForLowImportance()
    {
        var user = new User();
        var userRecipient = new UserRecipient(user);
        var filteredUserRecipient = new ImportanceFilteringRecipient(userRecipient, Importance.High);
        var group = new GroupRecipient(userRecipient, filteredUserRecipient);
        Message messageLow = MessageFactory.Create(importance: 1); // Normal

        group.Deliver(messageLow);

        // размер
        KeyValuePair<MessageId, UserMessageState> entry = Assert.Single(user.Inbox);

        Assert.Equal(messageLow.Id, entry.Key);
        Assert.Equal(UserMessageState.Unread, entry.Value);
    }
}