namespace SubsequenceFinder.Tests
{
    public class LongestIncreasingSubsequenceFinderTests
    {
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
