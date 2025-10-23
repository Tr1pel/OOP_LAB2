using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Formatting;

public sealed class MarkdownFormatter : IFormatter
{
    public string FormatTitle(Message message) => $"# {message.Title}";

    public string FormatBody(Message message)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"**Importance:** {message.Importance}");
        sb.AppendLine();
        sb.AppendLine(message.Body.ToString());
        return sb.ToString();
    }
}