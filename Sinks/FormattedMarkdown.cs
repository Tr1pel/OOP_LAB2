namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

// Структура отформатированного Markdown
public readonly record struct FormattedMarkdown
{
    public FormattedMarkdown(string title, string body)
    {
        Title = title;
        Body = body;
    }

    public string Title { get; }

    public string Body { get; }
}