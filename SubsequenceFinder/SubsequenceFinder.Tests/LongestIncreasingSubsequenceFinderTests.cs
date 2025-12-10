using SubsequenceFinder.Core;

namespace SubsequenceFinder.Tests
{
    public class LongestIncreasingSubsequenceFinderTests
    {
        private const string TestDataFolder = "TestData";

        public static TheoryData<string, string> AllTestData()
        {
            var testCases = new TheoryData<string, string>();

            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), TestDataFolder);

            if (!Directory.Exists(baseDirectory))
            {
                return testCases;
            }

            var testCaseDirectories = Directory.EnumerateDirectories(baseDirectory);

            foreach (var testCaseDir in testCaseDirectories)
            {
                string inputPath = Path.Combine(testCaseDir, "Input.txt");
                string outputPath = Path.Combine(testCaseDir, "Output.txt");

                if (File.Exists(inputPath) && File.Exists(outputPath))
                {
                    string input = File.ReadAllText(inputPath).Trim();
                    string expectedOutput = File.ReadAllText(outputPath).Trim();

                    testCases.Add(input, expectedOutput);
                }
            }

            return testCases;
        }

        [Theory]
        [MemberData(nameof(AllTestData))]
        public void FindLongestIncreasingSubsequence_ShouldHandleLargeInputs(string input, string expected)
        {
            var finder = new LongestIncreasingSubsequenceFinder();
            var output = finder.FindLongestIncreasingSubsequence(input);

            Assert.Equal(expected, output);
        }


        [Theory]
        [InlineData("6 1 5 9 2", "1 5 9")]
        [InlineData("6 2 4 6 1 5 9 2", "2 4 6")]
        [InlineData("6 2 4 3 1 5 9", "1 5 9")]
        public void FindLongestIncreasingSubsequence_ShouldHandleSmallInputs(string input, string expected)
        {
            var finder = new LongestIncreasingSubsequenceFinder();
            var output = finder.FindLongestIncreasingSubsequence(input);

            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData("", "")] // empty string
        [InlineData("1", "1")] // single element
        [InlineData("6 5 4 3 2 1", "6")] // decreasing sequence
        [InlineData("1 2 3 4 5 6", "1 2 3 4 5 6")] // increasing sequence
        [InlineData("1  2  3  1", "1 2 3")] // multiple spaces between numbers
        public void FindLongestIncreasingSubsequence_ShouldHandleEdgeCases(string input, string expected)
        {
            var finder = new LongestIncreasingSubsequenceFinder();
            var output = finder.FindLongestIncreasingSubsequence(input);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void FindLongestIncreasingSubsequence_ShouldThrowWhenInputIsInvalid()
        {
            var finder = new LongestIncreasingSubsequenceFinder();
            var input = "1 2 3 bla 4 5";
            Assert.Throws<FormatException>(() => finder.FindLongestIncreasingSubsequence(input));
        }

        [Fact]
        public void FindLongestIncreasingSubsequence_ShouldThrowWhenNumberIsTooBig()
        {
            var finder = new LongestIncreasingSubsequenceFinder();
            var input = "1 9999999999999999999 2";
            Assert.Throws<OverflowException>(() => finder.FindLongestIncreasingSubsequence(input));
        }
    }
}
