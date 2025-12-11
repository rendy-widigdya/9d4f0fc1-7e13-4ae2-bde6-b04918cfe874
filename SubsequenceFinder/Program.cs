using SubsequenceFinder.Core;

if (args.Length == 0)
{
    return;
}

string input = args[0];

try
{
    var finder = new LongestContiguousIncreasingSubsequenceFinder();
    string result = finder.FindLongestContiguousIncreasingSubsequence(input);

    Console.WriteLine(result);
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid input: {ex.Message}");
}
catch (OverflowException ex)
{
    Console.WriteLine($"Number too large: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}