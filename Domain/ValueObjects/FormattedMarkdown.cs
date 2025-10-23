namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

public readonly record struct FormattedMarkdown
{
    public FormattedMarkdown(string title, string body)
    {
        Title = title;
        Body = body;
    }

    public string Title { get; }

    public string Body { get; }

    public override string ToString() => $"{Title}\n\n{Body}";
}