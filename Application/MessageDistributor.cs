using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Application;

public sealed class MessageDistributor
{
    public IReadOnlyCollection<ReceiveResult> Distribute(Topic topic, Message message)
    {
        return topic.Publish(message);
    }
}