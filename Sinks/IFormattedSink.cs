using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

public interface IFormattedSink
{
    ArchiveResult Save(string titleMarkdown, string bodyMarkdown);
}