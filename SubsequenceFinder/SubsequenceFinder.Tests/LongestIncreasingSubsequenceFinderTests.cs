using SubsequenceFinder.Core;

namespace SubsequenceFinder.Tests
{
    public class LongestIncreasingSubsequenceFinderTests
    {
        private const string TestDataFolder = "TestData";

        public static IEnumerable<object[]> AllTestData =>
            Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), TestDataFolder))
                .Select(testCaseDir => new
                {
                    InputPath = Path.Combine(testCaseDir, "Input.txt"),
                    OutputPath = Path.Combine(testCaseDir, "Output.txt"),
                })
                .Where(fileData => File.Exists(fileData.InputPath) && File.Exists(fileData.OutputPath))
                .Select(fileData => new object[]
                {
                File.ReadAllText(fileData.InputPath).Trim(),
                File.ReadAllText(fileData.OutputPath).Trim(),
                });

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
            var finder = new Core.LongestIncreasingSubsequenceFinder();
            var output = finder.FindLongestIncreasingSubsequence(input);

            Assert.Equal(expected, output);
        }
    }
}
