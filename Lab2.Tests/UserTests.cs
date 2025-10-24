using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.TestHelpers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

// Кейс 1, 2, 3 по поведению пользователя
public class UserTests
{
    [Fact(DisplayName = "При получении сообщения пользователем, оно сохраняется в статусе 'не прочитано'")]
    public void Receive_ShouldStoreMessageAsUnread()
    {
        // Arrange
        var user = new User();
        Message message = MessageFactory.Create();

        // Act
        ReceiveResult result = user.Receive(message);

        // Assert
        Assert.IsType<ReceiveResult.Success>(result);
        Assert.True(user.Inbox.TryGetValue(message.Id, out UserMessageState state));
        Assert.Equal(UserMessageState.Unread, state);
    }

    [Fact(DisplayName = "Отметить сообщение в статусе 'не прочитано' как прочитанное — статус меняется на 'прочитано'")]
    public void MarkAsRead_WhenUnread_ShouldSucceedAndSetRead()
    {
        // Arrange
        var user = new User();
        Message message = MessageFactory.Create();
        _ = user.Receive(message);

        // Act
        MarkAsReadResult markResult = user.MarkAsRead(message.Id);

        // Assert
        Assert.IsType<MarkAsReadResult.Success>(markResult);
        Assert.Equal(UserMessageState.Read, user.Inbox[message.Id]);
    }

    [Fact(DisplayName = "Отметить сообщение в статусе 'прочитано' как прочитанное — возвращает ошибку")]
    public void MarkAsRead_WhenAlreadyRead_ShouldReturnAlreadyReadError()
    {
        // Arrange
        var user = new User();
        Message message = MessageFactory.Create();
        _ = user.Receive(message);
        _ = user.MarkAsRead(message.Id);

        // Act
        MarkAsReadResult second = user.MarkAsRead(message.Id);

        // Assert
        Assert.IsType<MarkAsReadResult.AlreadyRead>(second);
    }
}