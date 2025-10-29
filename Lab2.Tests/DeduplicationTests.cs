using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Messages.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients.Decorators;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class DeduplicationTests
{
    [Fact]
    public void TwoRecipientsOneUser_WithFilter_ShouldDeliverOnceForLowImportance()
    {
        var user = new User();

        // доменная реализация получателя пользователя
        IRecipient userRecipient = new UserRecipient(user);

        // доменный декоратор фильтрации важности
        IRecipient filteredUserRecipient = new ImportanceFilterRecipient(userRecipient, Importance.High);

        // доменный компоновщик вместо тестового GroupRecipient
        var group = new CompositeRecipient(new IRecipient[] { userRecipient, filteredUserRecipient });

        Message messageLow = MessageFactory.Create(importance: 1); // Normal

        group.Receive(messageLow);

        // у пользователя должна появиться одна запись, без дубликатов
        KeyValuePair<MessageId, UserMessageState> entry = Assert.Single(user.Inbox);

        Assert.Equal(messageLow.Id, entry.Key);
        Assert.Equal(UserMessageState.Unread, entry.Value);
    }
}