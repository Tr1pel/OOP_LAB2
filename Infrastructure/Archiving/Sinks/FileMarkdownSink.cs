using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Results;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Archiving.Sinks;

public sealed class FileMarkdownSink : IFormattedSink
{
    private readonly IFileWriter _fileWriter;
    private readonly string _path;
    private readonly WriteMode _mode;

    public enum WriteMode
    {
        Append,
        Overwrite,
    }

    public FileMarkdownSink(IFileWriter fileWriter, string path, WriteMode mode = WriteMode.Append)
    {
        _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _mode = mode;
    }

    public ArchiveResult Save(string titleMarkdown, string bodyMarkdown)
    {
        try
        {
            var sb = new StringBuilder();
            sb.AppendLine(titleMarkdown);
            sb.AppendLine();
            sb.AppendLine(bodyMarkdown);
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();

            string content = sb.ToString();

            if (_mode == WriteMode.Overwrite)
                _fileWriter.WriteAllText(_path, content);
            else
                _fileWriter.AppendAllText(_path, content);

            return new ArchiveResult.Success();
        }
        catch (Exception ex)
        {
            // Инфраструктурная ошибка сохраняется в Result-тип
            return new ArchiveResult.StorageError(ex.Message);
        }
    }
}