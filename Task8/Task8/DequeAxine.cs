using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Представляет двустороннюю очередь (дек), реализованную на двусвязном списке.
/// </summary>
/// <typeparam name="T">Тип элементов в деке.</typeparam>
/// <remarks>
/// <para>
/// <see cref="DequeAxine{T}"/> предоставляет эффективные O(1) операции добавления 
/// и удаления элементов как с начала, так и с конца коллекции. Структура данных 
/// реализована с использованием внутреннего двусвязного списка.
/// </para>
/// <para>
/// Класс реализует интерфейсы <see cref="IEnumerable{T}"/>, позволяя использовать 
/// циклы foreach для итерации по элементам.
/// </para>
/// <para>
/// Кроме основных операций дека, предоставляет методы для использования структуры 
/// как стека (LIFO) и очереди (FIFO).
/// </para>
/// </remarks>
public class DequeAxine<T> : IDeque<T>
{
    private Node head;
    private Node tail;
    private int size;

    /// <summary>
    /// Внутренний класс, представляющий узел двусвязного списка.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Значение, хранящееся в узле.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Ссылка на следующий узел в списке.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Ссылка на предыдущий узел в списке.
        /// </summary>
        public Node Prev { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Node"/>.
        /// </summary>
        /// <param name="value">Значение для хранения в узле.</param>
        /// <param name="prev">Ссылка на предыдущий узел.</param>
        /// <param name="next">Ссылка на следующий узел.</param>
        public Node(T value, Node prev, Node next)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="DequeAxine{T}"/>.
    /// </summary>
    public DequeAxine()
    {
        head = tail = null;
        size = 0;
    }

    /// <summary>
    /// Добавляет элемент в начало дека.
    /// </summary>
    /// <param name="value">Элемент для добавления.</param>
    /// <remarks>
    /// Время выполнения: O(1).
    /// </remarks>
    /// <example>
    /// <code>
    /// var deque = new DequeAxine&lt;int&gt;();
    /// deque.AddFirst(1); // [1]
    /// deque.AddFirst(2); // [2, 1]
    /// </code>
    /// </example>
    public void AddFirst(T value)
    {
        Node newNode = new Node(value, null, head);

        if (IsEmpty())
        {
            tail = newNode;
        }
        else
        {
            head.Prev = newNode;
        }

        head = newNode;
        size++;
    }

    /// <summary>
    /// Добавляет элемент в конец дека.
    /// </summary>
    /// <param name="value">Элемент для добавления.</param>
    /// <remarks>
    /// Время выполнения: O(1).
    /// </remarks>
    /// <example>
    /// <code>
    /// var deque = new DequeAxine&lt;int&gt;();
    /// deque.AddLast(1); // [1]
    /// deque.AddLast(2); // [1, 2]
    /// </code>
    /// </example>
    public void AddLast(T value)
    {
        Node newNode = new Node(value, tail, null);

        if (IsEmpty())
        {
            head = newNode;
        }
        else
        {
            tail.Next = newNode;
        }

        tail = newNode;
        size++;
    }

    /// <summary>
    /// Удаляет и возвращает элемент из начала дека.
    /// </summary>
    /// <returns>Элемент, удаленный из начала дека.</returns>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если дек пуст.
    /// </exception>
    /// <remarks>
    /// Время выполнения: O(1).
    /// </remarks>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// int first = deque.RemoveFirst(); // Возвращает 1, дек содержит [2]
    /// </code>
    /// </example>
    public T RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T value = head.Value;
        head = head.Next;

        if (head != null)
        {
            head.Prev = null;
        }
        else
        {
            tail = null;
        }

        size--;
        return value;
    }

    /// <summary>
    /// Удаляет и возвращает элемент из конца дека.
    /// </summary>
    /// <returns>Элемент, удаленный из конца дека.</returns>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если дек пуст.
    /// </exception>
    /// <remarks>
    /// Время выполнения: O(1).
    /// </remarks>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// int last = deque.RemoveLast(); // Возвращает 2, дек содержит [1]
    /// </code>
    /// </example>
    public T RemoveLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T value = tail.Value;
        tail = tail.Prev;

        if (tail != null)
        {
            tail.Next = null;
        }
        else
        {
            head = null;
        }

        size--;
        return value;
    }

    /// <summary>
    /// Возвращает элемент из начала дека без его удаления.
    /// </summary>
    /// <returns>Элемент в начале дека.</returns>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если дек пуст.
    /// </exception>
    /// <remarks>
    /// Время выполнения: O(1).
    /// </remarks>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// int first = deque.PeekFirst(); // Возвращает 1, дек остается [1, 2]
    /// </code>
    /// </example>
    public T PeekFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }
        return head.Value;
    }

    /// <summary>
    /// Возвращает элемент из конца дека без его удаления.
    /// </summary>
    /// <returns>Элемент в конце дека.</returns>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если дек пуст.
    /// </exception>
    /// <remarks>
    /// Время выполнения: O(1).
    /// </remarks>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// int last = deque.PeekLast(); // Возвращает 2, дек остается [1, 2]
    /// </code>
    /// </example>
    public T PeekLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }
        return tail.Value;
    }

    /// <summary>
    /// Определяет, пуст ли дек.
    /// </summary>
    /// <returns>
    /// <see langword="true"/>, если дек не содержит элементов; 
    /// в противном случае — <see langword="false"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// var deque = new DequeAxine&lt;int&gt;();
    /// bool isEmpty = deque.IsEmpty(); // true
    /// deque.AddLast(1);
    /// isEmpty = deque.IsEmpty(); // false
    /// </code>
    /// </example>
    public bool IsEmpty()
    {
        return size == 0;
    }

    /// <summary>
    /// Получает количество элементов, содержащихся в деке.
    /// </summary>
    /// <value>
    /// Количество элементов в деке.
    /// </value>
    /// <example>
    /// <code>
    /// var deque = new DequeAxine&lt;int&gt;();
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// int count = deque.Count; // 2
    /// </code>
    /// </example>
    public int Count
    {
        get { return size; }
    }

    /// <summary>
    /// Удаляет все элементы из дека.
    /// </summary>
    /// <remarks>
    /// Время выполнения: O(1). Сборщик мусора впоследствии освободит память узлов.
    /// </remarks>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// deque.Clear(); // Дек пуст
    /// int count = deque.Count; // 0
    /// </code>
    /// </example>
    public void Clear()
    {
        head = tail = null;
        size = 0;
    }

    /// <summary>
    /// Определяет, содержит ли дек указанное значение.
    /// </summary>
    /// <param name="value">Значение для поиска в деке.</param>
    /// <returns>
    /// <see langword="true"/>, если элемент найден в деке; 
    /// в противном случае — <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// Время выполнения: O(n), где n — количество элементов в деке.
    /// Для сравнения значений используется <see cref="EqualityComparer{T}.Default"/>.
    /// </remarks>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// bool contains = deque.Contains(2); // true
    /// contains = deque.Contains(3); // false
    /// </code>
    /// </example>
    public bool Contains(T value)
    {
        Node current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    /// <summary>
    /// Возвращает перечислитель, который осуществляет итерацию по элементам дека.
    /// </summary>
    /// <returns>
    /// Перечислитель <see cref="IEnumerator{T}"/>, который можно использовать 
    /// для перебора элементов дека в порядке от начала к концу.
    /// </returns>
    /// <remarks>
    /// Перечисление является потокобезопасным, если коллекция не изменяется 
    /// во время перечисления.
    /// </remarks>
    /// <example>
    /// <code>
    /// var deque = new DequeAxine&lt;int&gt;();
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// deque.AddLast(3);
    /// 
    /// foreach (var item in deque)
    /// {
    ///     Console.WriteLine(item); // Выводит 1, затем 2, затем 3
    /// }
    /// </code>
    /// </example>
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Возвращает перечислитель, который осуществляет итерацию по коллекции.
    /// </summary>
    /// <returns>
    /// Объект <see cref="IEnumerator"/>, который можно использовать 
    /// для перебора коллекции.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Добавляет элемент на вершину стека (псевдоним для <see cref="AddFirst(T)"/>).
    /// </summary>
    /// <param name="value">Элемент для добавления.</param>
    /// <remarks>
    /// Используется для реализации поведения стека (LIFO).
    /// </remarks>
    public void Push(T value) => AddFirst(value);

    /// <summary>
    /// Удаляет и возвращает элемент с вершины стека (псевдоним для <see cref="RemoveFirst()"/>).
    /// </summary>
    /// <returns>Элемент, удаленный с вершины стека.</returns>
    /// <remarks>
    /// Используется для реализации поведения стека (LIFO).
    /// </remarks>
    public T Pop() => RemoveFirst();

    /// <summary>
    /// Добавляет элемент в конец очереди (псевдоним для <see cref="AddLast(T)"/>).
    /// </summary>
    /// <param name="value">Элемент для добавления.</param>
    /// <remarks>
    /// Используется для реализации поведения очереди (FIFO).
    /// </remarks>
    public void Enqueue(T value) => AddLast(value);

    /// <summary>
    /// Удаляет и возвращает элемент из начала очереди (псевдоним для <see cref="RemoveFirst()"/>).
    /// </summary>
    /// <returns>Элемент, удаленный из начала очереди.</returns>
    /// <remarks>
    /// Используется для реализации поведения очереди (FIFO).
    /// </remarks>
    public T Dequeue() => RemoveFirst();
}