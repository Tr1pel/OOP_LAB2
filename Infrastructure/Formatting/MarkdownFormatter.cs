using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messages;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Formatting;

// Форматтер Markdown
public sealed class MarkdownFormatter : IFormatter
{
    // заголовок как H1
    public string FormatTitle(Message message) => $"# {message.Title}";

    public string FormatBody(Message message)
    {
        // собираем тело
        var sb = new StringBuilder();
        sb.AppendLine($"**Importance:** {message.Importance}");
        sb.AppendLine();
        sb.AppendLine(message.Body.ToString()); // само содержимое
        return sb.ToString();
    }
}