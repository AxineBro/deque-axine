using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Представляет двустороннюю очередь (дек), реализованную на циклическом массиве.
/// </summary>
/// <typeparam name="T">Тип элементов в деке.</typeparam>
/// <remarks>
/// <para>
/// <see cref="ArrayDeque{T}"/> предоставляет эффективные O(1) операции добавления 
/// и удаления элементов как с начала, так и с конца коллекции. Структура данных 
/// реализована с использованием циклического массива (кольцевого буфера).
/// </para>
/// <para>
/// При заполнении внутреннего массива происходит его автоматическое увеличение 
/// в два раза. Класс реализует интерфейсы <see cref="IEnumerable{T}"/>, позволяя 
/// использовать циклы foreach для итерации по элементам.
/// </para>
/// <para>
/// Кроме основных операций дека, предоставляет методы для использования структуры 
/// как стека (LIFO) и очереди (FIFO).
/// </para>
/// </remarks>
public class ArrayDequeAxine<T> : IDeque<T>
{
    private T[] items;
    private int head;
    private int tail;
    private int size;
    private const int DefaultCapacity = 4;

    /// <summary>
    /// Инициализирует новый пустой экземпляр класса <see cref="ArrayDeque{T}"/> 
    /// с начальной емкостью по умолчанию.
    /// </summary>
    public ArrayDequeAxine()
    {
        items = new T[DefaultCapacity];
        head = 0;
        tail = 0;
        size = 0;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ArrayDeque{T}"/> 
    /// с указанной начальной емкостью.
    /// </summary>
    /// <param name="capacity">Начальная емкость дека.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если <paramref name="capacity"/> меньше или равно 0.
    /// </exception>
    public ArrayDequeAxine(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0.");

        items = new T[capacity];
        head = 0;
        tail = 0;
        size = 0;
    }

    /// <summary>
    /// Добавляет элемент в начало дека.
    /// </summary>
    /// <param name="item">Элемент для добавления.</param>
    /// <remarks>
    /// <para>
    /// Время выполнения: O(1) в среднем, O(n) при расширении массива.
    /// </para>
    /// <para>
    /// Если дек заполнен, внутренний массив увеличивается в два раза.
    /// </para>
    /// </remarks>
    /// <example>
    /// <code>
    /// var deque = new ArrayDeque&lt;int&gt;();
    /// deque.AddFirst(1); // [1]
    /// deque.AddFirst(2); // [2, 1]
    /// </code>
    /// </example>
    public void AddFirst(T item)
    {
        if (size == items.Length)
        {
            Resize(items.Length * 2);
        }

        head = (head - 1 + items.Length) % items.Length;
        items[head] = item;
        size++;

        if (size == 1)
        {
            tail = head;
        }
    }

    /// <summary>
    /// Добавляет элемент в конец дека.
    /// </summary>
    /// <param name="item">Элемент для добавления.</param>
    /// <remarks>
    /// <para>
    /// Время выполнения: O(1) в среднем, O(n) при расширении массива.
    /// </para>
    /// <para>
    /// Если дек заполнен, внутренний массив увеличивается в два раза.
    /// </para>
    /// </remarks>
    /// <example>
    /// <code>
    /// var deque = new ArrayDeque&lt;int&gt;();
    /// deque.AddLast(1); // [1]
    /// deque.AddLast(2); // [1, 2]
    /// </code>
    /// </example>
    public void AddLast(T item)
    {
        if (size == items.Length)
        {
            Resize(items.Length * 2);
        }

        if (size == 0)
        {
            items[tail] = item;
        }
        else
        {
            tail = (tail + 1) % items.Length;
            items[tail] = item;
        }

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
        if (size == 0)
            throw new InvalidOperationException("Deque is empty.");

        T item = items[head];
        items[head] = default!;

        if (size > 1)
        {
            head = (head + 1) % items.Length;
        }

        size--;

        if (size > 0 && size == items.Length / 4)
        {
            Resize(items.Length / 2);
        }

        return item;
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
        if (size == 0)
            throw new InvalidOperationException("Deque is empty.");

        T item = items[tail];
        items[tail] = default!;

        if (size > 1)
        {
            tail = (tail - 1 + items.Length) % items.Length;
        }

        size--;

        if (size > 0 && size == items.Length / 4)
        {
            Resize(items.Length / 2);
        }

        return item;
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
        if (size == 0)
            throw new InvalidOperationException("Deque is empty.");

        return items[head];
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
        if (size == 0)
            throw new InvalidOperationException("Deque is empty.");

        return items[tail];
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
    /// var deque = new ArrayDeque&lt;int&gt;();
    /// bool isEmpty = deque.IsEmpty(); // true
    /// deque.AddLast(1);
    /// isEmpty = deque.IsEmpty(); // false
    /// </code>
    /// </example>
    public bool IsEmpty() => size == 0;

    /// <summary>
    /// Получает количество элементов, содержащихся в деке.
    /// </summary>
    /// <value>
    /// Количество элементов в деке.
    /// </value>
    /// <example>
    /// <code>
    /// var deque = new ArrayDeque&lt;int&gt;();
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// int count = deque.Count; // 2
    /// </code>
    /// </example>
    public int Count => size;

    /// <summary>
    /// Получает текущую емкость внутреннего массива.
    /// </summary>
    /// <value>
    /// Емкость внутреннего массива.
    /// </value>
    public int Capacity => items.Length;

    /// <summary>
    /// Удаляет все элементы из дека и сбрасывает емкость до значения по умолчанию.
    /// </summary>
    /// <remarks>
    /// Время выполнения: O(1).
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
        if (head <= tail)
        {
            Array.Clear(items, head, size);
        }
        else
        {
            Array.Clear(items, head, items.Length - head);
            Array.Clear(items, 0, tail + 1);
        }

        items = new T[DefaultCapacity];
        head = 0;
        tail = 0;
        size = 0;
    }

    /// <summary>
    /// Определяет, содержит ли дек указанное значение.
    /// </summary>
    /// <param name="item">Значение для поиска в деке.</param>
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
    public bool Contains(T item)
    {
        if (size == 0)
            return false;

        var comparer = EqualityComparer<T>.Default;

        if (head <= tail)
        {
            for (int i = head; i <= tail; i++)
            {
                if (comparer.Equals(items[i], item))
                    return true;
            }
        }
        else
        {
            for (int i = head; i < items.Length; i++)
            {
                if (comparer.Equals(items[i], item))
                    return true;
            }

            for (int i = 0; i <= tail; i++)
            {
                if (comparer.Equals(items[i], item))
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Изменяет емкость внутреннего массива.
    /// </summary>
    /// <param name="newCapacity">Новая емкость массива.</param>
    /// <remarks>
    /// Если новая емкость меньше текущего количества элементов, 
    /// выбрасывается исключение <see cref="InvalidOperationException"/>.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если <paramref name="newCapacity"/> меньше текущего размера дека.
    /// </exception>
    private void Resize(int newCapacity)
    {
        if (newCapacity < size)
            throw new InvalidOperationException("New capacity cannot be less than current size.");

        T[] newItems = new T[newCapacity];

        if (size > 0)
        {
            if (head <= tail)
            {
                Array.Copy(items, head, newItems, 0, size);
            }
            else
            {
                int firstPart = items.Length - head;
                Array.Copy(items, head, newItems, 0, firstPart);
                Array.Copy(items, 0, newItems, firstPart, tail + 1);
            }
        }

        items = newItems;
        head = 0;
        tail = size > 0 ? size - 1 : 0;
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
    /// var deque = new ArrayDeque&lt;int&gt;();
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
        if (size == 0)
            yield break;

        if (head <= tail)
        {
            for (int i = head; i <= tail; i++)
            {
                yield return items[i];
            }
        }
        else
        {
            for (int i = head; i < items.Length; i++)
            {
                yield return items[i];
            }

            for (int i = 0; i <= tail; i++)
            {
                yield return items[i];
            }
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
    /// <param name="item">Элемент для добавления.</param>
    /// <remarks>
    /// Используется для реализации поведения стека (LIFO).
    /// </remarks>
    public void Push(T item) => AddFirst(item);

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
    /// <param name="item">Элемент для добавления.</param>
    /// <remarks>
    /// Используется для реализации поведения очереди (FIFO).
    /// </remarks>
    public void Enqueue(T item) => AddLast(item);

    /// <summary>
    /// Удаляет и возвращает элемент из начала очереди (псевдоним для <see cref="RemoveFirst()"/>).
    /// </summary>
    /// <returns>Элемент, удаленный из начала очереди.</returns>
    /// <remarks>
    /// Используется для реализации поведения очереди (FIFO).
    /// </remarks>
    public T Dequeue() => RemoveFirst();

    /// <summary>
    /// Возвращает массив, содержащий элементы дека в правильном порядке.
    /// </summary>
    /// <returns>Новый массив, содержащий элементы дека.</returns>
    /// <example>
    /// <code>
    /// deque.AddLast(1);
    /// deque.AddLast(2);
    /// deque.AddFirst(3);
    /// int[] array = deque.ToArray(); // [3, 1, 2]
    /// </code>
    /// </example>
    public T[] ToArray()
    {
        T[] result = new T[size];

        if (size == 0)
            return result;

        if (head <= tail)
        {
            Array.Copy(items, head, result, 0, size);
        }
        else
        {
            int firstPart = items.Length - head;
            Array.Copy(items, head, result, 0, firstPart);
            Array.Copy(items, 0, result, firstPart, tail + 1);
        }

        return result;
    }
}