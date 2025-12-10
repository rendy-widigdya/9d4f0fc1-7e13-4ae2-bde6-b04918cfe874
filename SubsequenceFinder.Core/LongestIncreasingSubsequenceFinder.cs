namespace SubsequenceFinder.Core
{
    public class LongestIncreasingSubsequenceFinder
    {
        /// <summary>
        /// Finds the longest increasing subsequence in a string.
        /// </summary>
        /// <param name="input">string with numbers separated by white space</param>
        /// <returns>The longest sequence</returns>
        public string FindLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) {
                return "";
            }

            List<int> longestSequence = [];
            List<int> currentSequence = [];
            
            int[] numbers = ParseInput(input);
            
            foreach (int number in numbers)
            {
                // if it is the first number or it is greater than the last number in the current increasing sequence
                if (currentSequence.Count == 0 || number > currentSequence[^1])
                {
                    currentSequence.Add(number);
                }
                // else start a new increasing sequence
                else
                {
                    // check if the current increasing sequence is longer than the longest found so far
                    UpdateLongestIfNeeded(ref longestSequence, currentSequence);

                    currentSequence = [number];
                }
            }

            // final check for the last increasing sequence
            UpdateLongestIfNeeded(ref longestSequence, currentSequence);

            return string.Join(" ", longestSequence);
        }

        /// <summary>
        /// Updates the longest sequence if the new sequence is longer.
        /// </summary>
        /// <param name="longestSequence">Longest sequence</param>
        /// <param name="currentSequence">New sequence</param>
        private static void UpdateLongestIfNeeded(ref List<int> longestSequence, List<int> currentSequence)
        {
            if (currentSequence.Count > longestSequence.Count)
            {
                longestSequence = [.. currentSequence];
            }
        }

        /// <summary>
        /// Parses the input string into an array of integers.
        /// </summary>
        /// <param name="input">string with numbers separated by white space</param>
        /// <returns>Array of parsed integers</returns>
        /// <exception cref="FormatException">Non integer error</exception>
        /// <exception cref="OverflowException">Value too big for integer</exception>
        private static int[] ParseInput(string input)
        {
            try
            {
                return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Input contains an invalid value.", ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException($"Input contains a value that is too large", ex);
            }
        }
    }
}
