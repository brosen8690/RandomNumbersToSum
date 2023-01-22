using System.Globalization;

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

        public static double GetBaseNumber(int remainder)
        {
            Console.WriteLine($"Scientific notation: 1.1E-{(remainder / 500)}");
            double parsedDouble = Double.Parse($".1E-{(remainder / 500)}", System.Globalization.NumberStyles.Float);
            Console.WriteLine("Parsed double: " + (1 + parsedDouble));
            //return Math.Pow(1.1, 1/((double)remainder / 500));
            return double.Parse($@"1.{new string('0', (remainder / 500))}1", CultureInfo.InvariantCulture);
        }

        //private static int GetExponent(int remainder)
        //{
        //    return int.Parse($@"1.{Math.Pow(10, remainder / 500).ToString().Substring(1)}1");
        //}
    }
}