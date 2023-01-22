namespace RandomNumbersToSum
{
    public static class RandomizerExtensions
    {
        /// <summary>
        /// Gets {count} numbers that, when summed, equal {sum}
        /// </summary>
        /// <param name="sum">The desired sum</param>
        /// <param name="count">The number of random numbers to return</param>
        /// <returns></returns>
        public static List<int> ToRandomNumbers(this int sum, int count)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            int numberToAdd;
            int remainder = sum;

            for (int j = 1; j <= count; j++)
            {
                if (j == count)
                {
                    numbers.Add(remainder);
                    break;
                }
                else
                {
                    numberToAdd = rand.Next(0, remainder);

                }
                remainder -= numberToAdd;
                numbers.Add(numberToAdd);
            }

            return numbers;
        }

        private static int GetBaseNumber(int remainder)
        {
            return int.Parse($@"1.{Math.Pow(10, remainder / 500).ToString().Substring(1)}1");
        }
    }
}