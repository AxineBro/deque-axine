using System;
using System.IO;
using System.Text;

/// <summary>
/// Утилита для поиска слов максимальной длины в текстовом файле с использованием дека.
/// </summary>
public static class TextFileProcessor
{
    /// <summary>
    /// Находит и возвращает слова максимальной длины из текстового файла.
    /// </summary>
    /// <param name="filePath">Путь к текстовому файлу.</param>
    /// <param name="useArrayDeque">true - использовать ArrayDeque, false - использовать LinkedDeque.</param>
    /// <returns>Дек, содержащий слова максимальной длины в порядке их появления.</returns>
    /// <exception cref="FileNotFoundException">Выбрасывается, если файл не существует.</exception>
    /// <exception cref="IOException">Выбрасывается при ошибках чтения файла.</exception>
    public static IDeque<string> FindLongestWords(string filePath, bool useArrayDeque = true)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл не найден: {filePath}");

        IDeque<string> longestWords = useArrayDeque ?
            new ArrayDequeAxine<string>() :
            new DequeAxine<string>();

        IDeque<string> allWords = useArrayDeque ?
            new ArrayDequeAxine<string>() :
            new DequeAxine<string>();

        int maxLength = 0;

        using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var words = SplitIntoWords(line);
                foreach (var word in words)
                {
                    if (string.IsNullOrWhiteSpace(word))
                        continue;

                    allWords.AddLast(word);

                    int wordLength = word.Length;

                    if (wordLength > maxLength)
                    {
                        maxLength = wordLength;
                        longestWords.Clear();
                        longestWords.AddLast(word);
                    }
                    else if (wordLength == maxLength)
                    {
                        if (!longestWords.Contains(word))
                        {
                            longestWords.AddLast(word);
                        }
                    }
                }
            }
        }

        return longestWords;
    }

    /// <summary>
    /// Находит и возвращает слова максимальной длины из текстового файла,
    /// сохраняя исходный порядок слов.
    /// </summary>
    /// <param name="filePath">Путь к текстовому файлу.</param>
    /// <param name="useArrayDeque">true - использовать ArrayDeque, false - использовать LinkedDeque.</param>
    /// <returns>Дек, содержащий слова максимальной длины в порядке их появления.</returns>
    public static IDeque<string> FindLongestWordsPreserveOrder(string filePath, bool useArrayDeque = true)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл не найден: {filePath}");

        IDeque<string> allWords = useArrayDeque ?
            new ArrayDequeAxine<string>() :
            new DequeAxine<string>();

        int maxLength = 0;

        using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var words = SplitIntoWords(line);
                foreach (var word in words)
                {
                    if (string.IsNullOrWhiteSpace(word))
                        continue;

                    allWords.AddLast(word);

                    if (word.Length > maxLength)
                    {
                        maxLength = word.Length;
                    }
                }
            }
        }

        IDeque<string> longestWords = useArrayDeque ?
            new ArrayDequeAxine<string>() :
            new DequeAxine<string>();

        foreach (var word in allWords)
        {
            if (word.Length == maxLength && !longestWords.Contains(word))
            {
                longestWords.AddLast(word);
            }
        }

        return longestWords;
    }

    /// <summary>
    /// Разделяет строку на слова.
    /// </summary>
    /// <param name="text">Текст для разделения.</param>
    /// <returns>Массив слов.</returns>
    private static string[] SplitIntoWords(string text)
    {
        char[] separators = new char[]
        {
            ' ', '\t', '\n', '\r',
            '.', ',', '!', '?', ';', ':',
            '(', ')', '[', ']', '{', '}',
            '"', '\'', '-', '_', '=', '+',
            '*', '/', '\\', '|', '<', '>',
            '~', '`', '@', '#', '$', '%',
            '^', '&', '0', '1', '2', '3',
            '4', '5', '6', '7', '8', '9'
        };

        return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Печатает слова из дека.
    /// </summary>
    /// <param name="deque">Дек со словами для печати.</param>
    public static void PrintWords(IDeque<string> deque)
    {
        if (deque.IsEmpty())
        {
            Console.WriteLine("Слова не найдены.");
            return;
        }

        Console.WriteLine($"Найдено {deque.Count} слов(а):");
        Console.WriteLine(new string('-', 40));

        foreach (var word in deque)
        {
            Console.WriteLine($"Слово: \"{word}\", Длина: {word.Length}");
        }

        Console.WriteLine(new string('-', 40));
    }
}