using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatting;

// Форматтер Markdown
public sealed class MarkdownFormatter : IFormatter
{
    // заголовок как H1
    public string FormatTitle(Message message) => $"# {message.Title.Value}";

    public string FormatBody(Message message)
    {
        // собираем тело
        var sb = new StringBuilder();
        sb.AppendLine($"**Importance:** {message.Importance.Name}");
        sb.AppendLine();
        sb.AppendLine(message.Body.Value);
        return sb.ToString();
    }
}