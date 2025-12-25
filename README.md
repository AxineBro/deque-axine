# deque-axine

## Description

This repository contains implementations of a double-ended queue (deque) data structure in C# with two different backing stores: circular array and doubly-linked list. It includes practical examples for finding the longest words in text files while maintaining word order.

The project demonstrates modern C# features, clean architecture with interfaces, and practical applications of data structures.

## Project Structure

- **IDeque.cs** - Interface defining deque operations
- **ArrayDequeAxine.cs** - Deque implementation using circular array
- **DequeAxine.cs** - Deque implementation using doubly-linked list
- **TextFileProcessor.cs** - Utility for finding longest words in text files
- **Program.cs** - Examples and demonstration

## Features by Implementation

### ArrayDequeAxine (Circular Array)

* Uses **circular buffer** for O(1) amortized operations
* **Automatic resizing** when capacity is reached
* **Memory efficient** for random access patterns

```csharp
// ArrayDeque example
IDeque<string> deque = new ArrayDequeAxine<string>();
deque.AddFirst("first");
deque.AddLast("last");
string item = deque.RemoveFirst(); // "first"
```

### DequeAxine (Doubly-Linked List)

* **Node-based structure** using private Node class
* **True O(1)** for all operations (no resizing overhead)
* **Dynamic sizing** - only allocates memory as needed

```csharp
// LinkedDeque example
IDeque<int> deque = new DequeAxine<int>();
deque.Push(1);     // Stack-like behavior
deque.Enqueue(2);  // Queue-like behavior
int value = deque.Pop(); // 1
```

## Practical Application: Finding Longest Words

### TextFileProcessor Class
* **FindLongestWords()** - Finds all words with maximum length
* **FindLongestWordsPreserveOrder()** - Preserves original word order
* **PrintWords()** - Displays results formatted

```csharp
// Find and display longest words
var longestWords = TextFileProcessor.FindLongestWords("document.txt");
TextFileProcessor.PrintWords(longestWords);
```

### Word Processing Features
* **Unicode support** via UTF-8 encoding
* **Smart word splitting** using multiple delimiters
* **Order preservation** as specified in requirements
* **Duplicate handling** with configurable behavior

## Performance Characteristics

| Operation | ArrayDeque | LinkedDeque |
|-----------|------------|-------------|
| AddFirst  | O(1)*      | O(1)        |
| AddLast   | O(1)*      | O(1)        |
| RemoveFirst | O(1)    | O(1)        |
| RemoveLast  | O(1)    | O(1)        |
| PeekFirst  | O(1)    | O(1)        |
| PeekLast   | O(1)    | O(1)        |
| Contains   | O(n)    | O(n)        |
| Memory     | Contiguous | Fragmented  |

*Amortized complexity for ArrayDeque

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022+ or VS Code with C# extension
- For testing: xUnit (included)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/AxineBro/deque-axine.git
   ```
2. Open the solution in Visual Studio
3. Build the project (Ctrl+Shift+B)
4. Run the examples (F5)

### Basic Usage
```csharp
// Create deque (choose implementation)
IDeque<string> deque = new ArrayDequeAxine<string>();

// Add elements
deque.AddFirst("Hello");
deque.AddLast("World");

// Remove elements
string first = deque.RemoveFirst();  // "Hello"
string last = deque.RemoveLast();    // "World"

// Check status
bool isEmpty = deque.IsEmpty();      // true
int count = deque.Count;             // 0

// Use as stack
deque.Push("top");
string top = deque.Pop();            // "top"

// Use as queue
deque.Enqueue("first");
string firstInLine = deque.Dequeue(); // "first"
```

## Design Decisions

### Interface Design
* **Unified API** through `IDeque<T>` interface
* **Stack and queue semantics** via Push/Pop/Enqueue/Dequeue methods
* **IEnumerable<T> implementation** for LINQ compatibility

### Text Processing
* **Stream-based reading** for large file support
* **Configurable word delimiters** for different languages
* **Order preservation** option for different use cases

### Error Handling
* **Custom exceptions** for empty deque operations
* **Argument validation** for public methods
* **Graceful degradation** for file operations

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for details.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

Axine
