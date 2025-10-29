using Itmo.ObjectOrientedProgramming.Lab2.Abstractions;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Sinks;

public sealed class FileMarkdownSink : IFormattedSink
{
    private readonly IFileWriter _fileWriter;
    private readonly string _path;
    private readonly WriteMode _mode;

    public FileMarkdownSink(IFileWriter fileWriter, string path, WriteMode mode = WriteMode.Append)
    {
        _fileWriter = fileWriter;
        _path = path;
        _mode = mode;
    }

    public void Save(string titleMarkdown, string bodyMarkdown)
    {
        // формируем Markdown блок
        var sb = new StringBuilder();
        sb.AppendLine(titleMarkdown);
        sb.AppendLine();
        sb.AppendLine(bodyMarkdown);
        sb.AppendLine();
        sb.AppendLine("---");
        sb.AppendLine();

        string content = sb.ToString();

        // пишем в файл
        if (_mode == WriteMode.Overwrite)
            _fileWriter.WriteAllText(_path, content);
        else
            _fileWriter.AppendAllText(_path, content);
    }
}