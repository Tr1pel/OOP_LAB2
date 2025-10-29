namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

public interface IFormattedSink
{
    void Save(string titleMarkdown, string bodyMarkdown);
}