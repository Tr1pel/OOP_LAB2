namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Abstractions;

public interface IFileWriter
{
    // перезапись файла целиком
    void WriteAllText(string path, string contents);

    // добавление текста в конец файла
    void AppendAllText(string path, string contents);
}