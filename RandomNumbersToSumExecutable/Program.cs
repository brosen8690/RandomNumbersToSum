// See https://aka.ms/new-console-template for more information
using RandomNumbersToSum;
using System.Linq;

//Console.WriteLine(RandomizerExtensions.GetBaseNumber(remainder));
//Console.WriteLine(Math.Pow(RandomizerExtensions.GetBaseNumber(remainder), remainder));
for (int i = 0; i < 1000; i++)
{
    10000.ToRandomNumbers(3).ToList().ForEach(x => Console.Write(x + " "));
    Console.WriteLine();
}
var answer = 100.ToRandomNumbers(3);
Console.ReadKey();
