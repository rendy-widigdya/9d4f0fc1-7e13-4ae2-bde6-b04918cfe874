# SubsequenceFinder

A .NET library for finding the longest contiguous increasing subsequence in a string of integers separated by white space.

## Overview

This project provides functionality to find the longest contiguous increasing subsequence in a string of integers separated by white space with built in exception handling. The implementation runs in O(n) time and is fully tested.

## Features

- Parses space separated integer strings
- Finds the longest contiguous increasing subsequence
- Handles edge cases including empty strings, single elements, and invalid input
- Comprehensive unit test coverage
- GitHub Actions continuous integration
- Code formatting with dotnet format
- Test coverage reporting
- Dockerfile for containerised execution

## Requirements

- .NET 10.0 or later

## Project Structure

The solution consists of three projects:

- **SubsequenceFinder.Core**: Contains the core logic for finding longest increasing subsequences
- **SubsequenceFinder.Tests**: Unit tests using xUnit
- **SubsequenceFinder**: Console application (placeholder)

## Usage

```csharp
using SubsequenceFinder.Core;

var finder = new LongestIncreasingContiguousSubsequenceFinder();
string input = "6 1 5 9 2";
string result = finder.FindLongestIncreasingSubsequence(input);
// result: "1 5 9"
```

## Building

To build the solution:

```bash
dotnet restore
dotnet build
```

To run the console application:

```bash
dotnet run --project SubsequenceFinder "6 1 5 9 2"
```

## Testing

To run the unit tests:

```bash
dotnet test
```

The test suite includes:

- Large input test cases loaded from TestData files
- Small input test cases with inline data
- Edge case handling (empty strings, single elements, decreasing sequences)
- Error handling for invalid input

## Error Handling

The library throws exceptions for invalid input:

- `FormatException`: When input contains non-integer values
- `OverflowException`: When input contains values outside the integer range
