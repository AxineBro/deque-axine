using System.Collections.Generic;

/// <summary>
/// Интерфейс для двусторонней очереди (дека).
/// </summary>
/// <typeparam name="T">Тип элементов в деке.</typeparam>
public interface IDeque<T> : IEnumerable<T>
{
    /// <summary>
    /// Добавляет элемент в начало дека.
    /// </summary>
    /// <param name="item">Элемент для добавления.</param>
    void AddFirst(T item);

    /// <summary>
    /// Добавляет элемент в конец дека.
    /// </summary>
    /// <param name="item">Элемент для добавления.</param>
    void AddLast(T item);

    /// <summary>
    /// Удаляет и возвращает элемент из начала дека.
    /// </summary>
    /// <returns>Элемент, удаленный из начала дека.</returns>
    T RemoveFirst();

    /// <summary>
    /// Удаляет и возвращает элемент из конца дека.
    /// </summary>
    /// <returns>Элемент, удаленный из конца дека.</returns>
    T RemoveLast();

    /// <summary>
    /// Возвращает элемент из начала дека без его удаления.
    /// </summary>
    /// <returns>Элемент в начале дека.</returns>
    T PeekFirst();

    /// <summary>
    /// Возвращает элемент из конца дека без его удаления.
    /// </summary>
    /// <returns>Элемент в конце дека.</returns>
    T PeekLast();

    /// <summary>
    /// Определяет, пуст ли дек.
    /// </summary>
    /// <returns>true, если дек пуст; иначе false.</returns>
    bool IsEmpty();

    /// <summary>
    /// Получает количество элементов в деке.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Удаляет все элементы из дека.
    /// </summary>
    void Clear();

    /// <summary>
    /// Определяет, содержит ли дек указанный элемент.
    /// </summary>
    /// <param name="item">Элемент для поиска.</param>
    /// <returns>true, если элемент найден; иначе false.</returns>
    bool Contains(T item);

    // Методы для стека и очереди
    /// <summary>
    /// Добавляет элемент на вершину стека (AddFirst).
    /// </summary>
    void Push(T item);

    /// <summary>
    /// Удаляет и возвращает элемент с вершины стека (RemoveFirst).
    /// </summary>
    T Pop();

    /// <summary>
    /// Добавляет элемент в конец очереди (AddLast).
    /// </summary>
    void Enqueue(T item);

    /// <summary>
    /// Удаляет и возвращает элемент из начала очереди (RemoveFirst).
    /// </summary>
    T Dequeue();
}