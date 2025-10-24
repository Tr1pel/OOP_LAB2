using Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Console;

// Инфраструктурный писатель
public sealed class FileSystemWriter : IFileWriter
{
    public void WriteAllText(string path, string contents)
    {
        EnsureDirectory(path); // гарантируем что папка существует
        File.WriteAllText(path, contents);
    }

    public void AppendAllText(string path, string contents)
    {
        EnsureDirectory(path);
        File.AppendAllText(path, contents);
    }

    private static void EnsureDirectory(string path)
    {
        string? directory = Path.GetDirectoryName(path);

        if (string.IsNullOrWhiteSpace(directory))
        {
            return;
        }

        if (Directory.Exists(directory))
        {
            return;
        }

        // создаём недостающие папки
        Directory.CreateDirectory(directory);
    }
}