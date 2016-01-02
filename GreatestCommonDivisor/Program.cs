using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatestCommonDivisor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var entries = new Dictionary<Tuple<int, int>, int>()
            {
               {Tuple.Create(8,6), 0},
               {Tuple.Create(15,7), 0},
               {Tuple.Create(98,53), 0},
               {Tuple.Create(84,56), 0},
               {Tuple.Create(213,47), 0},
               {Tuple.Create(45,23), 0},
               {Tuple.Create(79,6), 0},
               {Tuple.Create(12,3), 0},
               {Tuple.Create(68,40), 0},
               {Tuple.Create(255,128), 0},
               {Tuple.Create(4096,128), 0}
            };

            var keys = entries.Keys.ToArray();
            foreach(var key in keys)
            {
                entries[key] = GreatestCommonDivisor(key.Item1, key.Item2);
            }

            foreach(var entry in entries)
            {
                Console.WriteLine(" GreatestCommonDivisor( {0}, {1} ) = {2} ", entry.Key.Item1, entry.Key.Item2, entry.Value);
            }

            Console.WriteLine("Press Enter key to exit");
            Console.ReadLine();
        }

        private static int GreatestCommonDivisor(int numArg1, int numArg2)
        {
            var max = Math.Max(numArg1, numArg2);
            var min = Math.Min(numArg1, numArg2);

            var reminder = 0;

            reminder = max % min;
            if (reminder == 0)
                return min;
            else if (reminder == 1)
                return 1;
            else
                return GreatestCommonDivisor(min, reminder);
        }
    }
}
