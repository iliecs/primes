using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Primes
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "Check for Prime Numbers";

            while (true)
            {
                Console.WriteLine("Enter an integer greater than 2 or q to quit");
                var userInput = Console.ReadLine();
                int value;

                if (userInput == "q")
                    break;
                if (int.TryParse(userInput, out value) && value > 2) Compute(value);
            }
        }

        private static void Compute(int max)
        {
            var i = 2; //start loop at i  //prime number is a whole number greater than 1 
            var stopwatch = new Stopwatch();
            var range = new List<int>(); //list of numbers to check again 
            range.AddRange(Enumerable.Range(i, max - 1)); //from i (OR 2) to the user input

            var primesList = new List<int>(); //adds found prime numbers to this list

            stopwatch.Start();
            
            while (i <= max)
            {
                var counter = 0;
                foreach (var item in range)
                    if (i != item)
                        if (i % item == 0)
                        {
                            counter++;
                            break;
                        }

                if (counter == 0) primesList.Add(i);
                // Console.WriteLine(String.Format("{0:n0}", i) + " done...");
                i++;
            }

            stopwatch.Stop();

            PrintOutput(stopwatch.ElapsedMilliseconds, primesList.Count, max);            
        }

        private static void PrintOutput(long timeTaken, int primesFound, int maxRangeGiven)
        {

            var timeInSeconds = timeTaken / 1000;
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"-- Time elapsed: {string.Format("{0:n0}", timeInSeconds)}s");
            Console.WriteLine($"-- Prime numbers in range: {primesFound}");
            Console.WriteLine($"-- Range 1-{string.Format("{0:n0}", maxRangeGiven)}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}