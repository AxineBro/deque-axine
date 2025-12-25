\# Contributing to deque-axine



Thank you for considering contributing! This is a student project for exploring data structures and algorithms in C#.



\## How to Contribute



1\. \*\*Fork the repository\*\*.

2\. \*\*Create a new branch\*\*: `git checkout -b feature/your-feature`.

3\. \*\*Make your changes and commit\*\*: `git commit -m "Add some feature"`.

4\. \*\*Push to the branch\*\*: `git push origin feature/your-feature`.

5\. \*\*Open a Pull Request\*\*.



\## Code Style



\- Use \*\*C# 9.0+\*\* features where appropriate

\- Follow \*\*C# naming conventions\*\* (PascalCase for classes, camelCase for parameters)

\- Add \*\*XML documentation comments\*\* for public members (in Russian)

\- Keep methods focused and small

\- Add \*\*unit tests\*\* for new functionality



\## Reporting Issues



\- Use \*\*GitHub Issues\*\* to report bugs or suggest features

\- Include steps to reproduce for bug reports

\- Specify which deque implementation is affected (ArrayDeque or LinkedDeque)



\## Development Guidelines



\### For Data Structure Changes

\- Ensure O(1) complexity for core deque operations

\- Maintain backward compatibility for the `IDeque<T>` interface

\- Add performance benchmarks if changing algorithms



\### For Text Processing Features

\- Handle different text encodings (UTF-8 by default)

\- Consider large file performance

\- Preserve word order as specified in requirements



\## Testing

\- All new features should include tests in the `deque-axine.Tests` project

\- Test edge cases (empty deque, single element, full capacity)

\- Test both ArrayDeque and LinkedDeque implementations



\## Pull Request Process

1\. Ensure all tests pass

2\. Update documentation if needed

3\. Link related issues

4\. Describe the changes in the PR description

