namespace SubsequenceFinder.Core
{
    public class LongestIncreasingSubsequenceFinder
    {
        public string FindLongestIncreasingSubsequence(string input)
        {
            List<int> longestNumbers = [];
            int currentMaxLength = 0;
            List<int> increasingNumbers = [];
            
            var numbers = input.Split(' ').Select(int.Parse).ToArray();
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if(increasingNumbers.Count == 0 || numbers[i] > increasingNumbers.Last())
                {
                    increasingNumbers.Add(numbers[i]);
                }
                else
                {
                    if(increasingNumbers.Count > currentMaxLength)
                    {
                        currentMaxLength = increasingNumbers.Count;
                        longestNumbers = [.. increasingNumbers];
                    }
                    increasingNumbers = [numbers[i]];
                }
            }

            if (increasingNumbers.Count > currentMaxLength)
            {
                currentMaxLength = increasingNumbers.Count;
                longestNumbers = increasingNumbers;
            }

            return string.Join(" ", longestNumbers);
        }
    }
}
