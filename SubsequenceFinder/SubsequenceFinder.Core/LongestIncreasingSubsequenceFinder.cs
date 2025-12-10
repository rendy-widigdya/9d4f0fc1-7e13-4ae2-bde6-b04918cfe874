namespace SubsequenceFinder.Core
{
    public class LongestIncreasingSubsequenceFinder
    {
        public string FindLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) {
                return "";
            }

            List<int> longestNumbers = [];
            int currentMaxLength = 0;
            List<int> increasingNumbers = [];
            
            int[] numbers;
            try
            {
                numbers = input.Split(' ').Select(int.Parse).ToArray();
            } catch (FormatException ex)
            {
                throw new FormatException("Input contains invalid value.", ex);
            }
            
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
                longestNumbers = [.. increasingNumbers];
            }

            return string.Join(" ", longestNumbers);
        }
    }
}
