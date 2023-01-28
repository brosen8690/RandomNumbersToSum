using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RandomNumbersToSum
{
    public static class RandomizerExtensions
    {
        private static double nextNextGaussian;
        private static bool haveNextNextGaussian = false;

        public static double NextGaussian()
        {
            if (haveNextNextGaussian)
            {
                haveNextNextGaussian = false;
                return nextNextGaussian;
            }
            else
            {
                Random random = new Random();

                double v1, v2, s;
                do
                {
                    v1 = 2 * random.NextDouble() - 1;   // between -1.0 and 1.0
                    v2 = 2 * random.NextDouble() - 1;   // between -1.0 and 1.0
                    s = v1 * v1 + v2 * v2;
                } while (s >= 1 || s == 0);
                double multiplier = Math.Sqrt(-2 * Math.Log(s) / s);
                nextNextGaussian = v2 * multiplier;
                haveNextNextGaussian = true;
                return v1 * multiplier;
            }
        }
        /// <summary>
        /// Gets {count} numbers that, when summed, equal {sum}
        /// </summary>
        /// <param name="sum">The desired sum</param>
        /// <param name="count">The number of random numbers to return</param>
        /// <returns></returns>
        public static int[] ToRandomNumbers(this int sum, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count should be greater than 0.");
            }
            Random random = new Random();
            int[] integers = new int[count];
            int remainingTotal = sum;

            for (int i = 0; i < count - 1; i++)
            {
                double gaussianRandom = NextGaussian() + sum / count;
                int randomValue = Convert.ToInt32(gaussianRandom);
                if (randomValue < 1)
                {
                    randomValue = 1;
                }

                integers[i] = randomValue;
                remainingTotal -= integers[i];
            }
            integers[count - 1] = remainingTotal;
            return integers;
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