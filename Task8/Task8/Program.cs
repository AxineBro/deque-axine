using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Поиск слов максимальной длины в текстовом файле ===\n");

        try
        {
            string filePath = "test.txt";

            CreateTestFile(filePath);

            Console.WriteLine($"Обрабатываем файл: {filePath}\n");

            Console.WriteLine("1. Использование ArrayDeque:");
            Console.WriteLine(new string('-', 30));

            var longestWordsArray = TextFileProcessor.FindLongestWords(filePath, useArrayDeque: true);
            TextFileProcessor.PrintWords(longestWordsArray);

            Console.WriteLine("\n2. Использование LinkedDeque:");
            Console.WriteLine(new string('-', 30));

            var longestWordsLinked = TextFileProcessor.FindLongestWords(filePath, useArrayDeque: false);
            TextFileProcessor.PrintWords(longestWordsLinked);

            Console.WriteLine("\n3. Сохранение порядка (только уникальные слова):");
            Console.WriteLine(new string('-', 30));

            var longestWordsOrdered = TextFileProcessor.FindLongestWordsPreserveOrder(filePath);
            TextFileProcessor.PrintWords(longestWordsOrdered);

            Console.WriteLine("\n4. Демонстрация работы дека:");
            Console.WriteLine(new string('-', 30));

            DemonstrateDequeOperations();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    /// <summary>
    /// Создает тестовый файл с текстом.
    /// </summary>
    private static void CreateTestFile(string filePath)
    {
        if (!System.IO.File.Exists(filePath))
        {
            string testText = @"Программирование - это искусство создания программ.
Код должен быть чистым и понятным.
Самое длинное слово в этом тексте: 'программирование'.
Также есть слова: алгоритм, структура, данные, интерфейс.
Повторяющиеся слова: программирование, программирование, программирование.
Короткие слова: я, мы, он, она, оно.
Еще одно длинное слово: 'интерфейс'.";

            System.IO.File.WriteAllText(filePath, testText, System.Text.Encoding.UTF8);
            Console.WriteLine($"Создан тестовый файл: {filePath}");
        }
    }

    /// <summary>
    /// Демонстрирует основные операции с деком.
    /// </summary>
    private static void DemonstrateDequeOperations()
    {
        Console.WriteLine("\nДемонстрация ArrayDeque:");
        IDeque<string> arrayDeque = new ArrayDequeAxine<string>();
        DemonstrateDeque(arrayDeque);

        Console.WriteLine("\nДемонстрация LinkedDeque:");
        IDeque<string> linkedDeque = new DequeAxine<string>();
        DemonstrateDeque(linkedDeque);
    }

    private static void DemonstrateDeque(IDeque<string> deque)
    {
        deque.AddFirst("первый");
        deque.AddLast("второй");
        deque.AddLast("третий");
        deque.AddFirst("нулевой");

        Console.WriteLine($"Количество элементов: {deque.Count}");
        Console.WriteLine($"Первый элемент: {deque.PeekFirst()}");
        Console.WriteLine($"Последний элемент: {deque.PeekLast()}");

        Console.WriteLine($"Удален с начала: {deque.RemoveFirst()}");
        Console.WriteLine($"Удален с конца: {deque.RemoveLast()}");

        Console.WriteLine($"Осталось элементов: {deque.Count}");
        Console.WriteLine($"Содержит 'второй': {deque.Contains("второй")}");

        deque.Push("новый");
        Console.WriteLine($"Верхушка стека: {deque.Pop()}");

        deque.Enqueue("в очереди");
        Console.WriteLine($"Из очереди: {deque.Dequeue()}");

        deque.Clear();
        Console.WriteLine($"После очистки: {deque.Count} элементов");
    }
}