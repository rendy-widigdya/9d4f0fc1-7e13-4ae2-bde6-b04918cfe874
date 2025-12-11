using SubsequenceFinder.Core;

namespace SubsequenceFinder.Tests
{
    public class LongestContiguousIncreasingSubsequenceFinderTests
    {
        private const string TestDataFolder = "TestData";
        private readonly LongestContiguousIncreasingSubsequenceFinder _finder = new();


        public static TheoryData<string, string, string> AllTestData()
        {
            var testCases = new TheoryData<string, string, string>();

            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), TestDataFolder);

            if (!Directory.Exists(baseDirectory))
            {
                return testCases;
            }

            var testCaseDirectories = Directory.EnumerateDirectories(baseDirectory);

            foreach (var testCaseDir in testCaseDirectories.OrderBy(d => d))
            {
                string inputPath = Path.Combine(testCaseDir, "Input.txt");
                string outputPath = Path.Combine(testCaseDir, "Output.txt");
                string testName = Path.GetFileName(testCaseDir);

                if (File.Exists(inputPath) && File.Exists(outputPath))
                {
                    string input = File.ReadAllText(inputPath).Trim();
                    string expectedOutput = File.ReadAllText(outputPath).Trim();

                    testCases.Add(input, expectedOutput, testName);
                }
            }

            return testCases;
        }

        [Theory]
        [MemberData(nameof(AllTestData))]
        public void FindLongestContiguousIncreasingSubsequence_ShouldHandleLargeInputs(string input, string expected, string testName)
        {
            var output = _finder.FindLongestContiguousIncreasingSubsequence(input);

            Assert.True(expected == output, $"Test {testName} failed");
        }


        [Theory]
        [InlineData("6 1 5 9 2", "1 5 9")]
        [InlineData("6 2 4 6 1 5 9 2", "2 4 6")]
        [InlineData("6 2 4 3 1 5 9", "1 5 9")]
        public void FindLongestContiguousIncreasingSubsequence_ShouldHandleSmallInputs(string input, string expected)
        {
            var output = _finder.FindLongestContiguousIncreasingSubsequence(input);

            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData("", "")] // empty string
        [InlineData("1", "1")] // single element
        [InlineData("6 5 4 3 2 1", "6")] // decreasing sequence
        [InlineData("1 2 3 4 5 6", "1 2 3 4 5 6")] // increasing sequence
        [InlineData("1  2  3  1", "1 2 3")] // multiple spaces between numbers
        [InlineData("   1 2 3", "1 2 3")] // leading spaces
        [InlineData("1 2 3   ", "1 2 3")] // trailing spaces
        public void FindLongestContiguousIncreasingSubsequence_ShouldHandleEdgeCases(string input, string expected)
        {
            var output = _finder.FindLongestContiguousIncreasingSubsequence(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void FindLongestContiguousIncreasingSubsequence_ShouldThrowWhenInputIsInvalid()
        {
            var finder = new LongestContiguousIncreasingSubsequenceFinder();
            var input = "1 2 3 bla 4 5";
            Assert.Throws<FormatException>(() => finder.FindLongestContiguousIncreasingSubsequence(input));
        }

        [Fact]
        public void FindLongestContiguousIncreasingSubsequence_ShouldThrowWhenNumberIsTooBig()
        {
            var input = "1 9999999999999999999 2";
            Assert.Throws<OverflowException>(() => _finder.FindLongestContiguousIncreasingSubsequence(input));
        }
    }
}
