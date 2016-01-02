using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var entries = new Dictionary<int, bool>
            {
                {5, false},{15, false},{7, false},
                {151, false},{263, false},{121, false},{93, false},{61, false},{478, false},
                {54653, false},{87457, false},{47, false},{71, false},{751, false},{97, false},
                {111, false},{371, false},{547, false},{883, false},{1317, false},{191, false},
                {481, false},{479, false},{13, false},{9, false},{17, false},{521, false},
                {153, false},{501, false},{177, false},{161, false},{181, false},{3941, false},
                {211, false},{221, false},{251, false},{231, false},{23589, false},
                {101, false},{701, false},{935487, false},{65231, false},{1321, false},
                {8541, false},{2187, false},{667, false},{917, false},{3451, false},{731, false},
                {721, false},{763, false},{787, false},{863, false},{851, false},{867, false},
            };

            var keys = entries.Keys.ToArray();

            foreach(var key in keys)
            {
                entries[key] = IsPrime(key);
            }

            foreach(var entry in entries)
            {
                Console.WriteLine("The number {0} {1} a prime number", entry.Key, entry.Value ? "is" : " is not");
            }

            Console.WriteLine("Press Enter key to exit");
            Console.ReadLine();
        }

        private static bool IsPrime(int val)
        {
            var isPrime = false;
            if(val <= 10)
            {
                if (val <= 1) return false;
                else if ((val < 4) || (val == 5) || (val == 7)) return true;
                else
                    return false;
            }

            if (NumberHasCorrectEnding(val))
            {
                if((val % 7) != 0)
                {
                    if ((val % 3) != 0)
                        isPrime = true;
                }
            }

            return isPrime;
        }

        static int[] endings = new int[] { 1, 3, 7 };
        private static bool NumberHasCorrectEnding(int val)
        {
            var hasCorrectEnding = false;
            var numStr = val.ToString().Trim();
            numStr = numStr.Substring(numStr.Length - 1);

            if (endings.Contains(Int32.Parse(numStr)))
            {
                hasCorrectEnding = true;

#if DEBUG
                //Console.WriteLine("\t\t {0} has  correct ending",val);
#endif
            }

            return hasCorrectEnding;
        }
    }
}
