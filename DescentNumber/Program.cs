using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescentNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            var entries = new Dictionary<int, string>
            {
                {1, ""},{5, ""},{12, ""},{16, ""},{25, ""},{33, ""},{65, ""},{81, ""},{92, ""},{101, ""},
                {136, ""},{154, ""},{168, ""},{212, ""},{512, ""},{775, ""},{632, ""},{889, ""},{900, ""},{1235, ""},
                {86, ""},{98, ""},{7, ""},{3, ""},{14, ""},{18, ""},{1230, ""},{2, ""},{9, ""},{2133, ""},
                {2251, ""},{2461, ""},{2539, ""},{2764, ""},{2986, ""},{3016, ""},{3658, ""},{3512, ""},{3841, ""},
                {3123, ""},{3898, ""},{3784, ""},{3969, ""},{4005, ""},{4021, ""},{4036, ""},{4037, ""},{4035, ""},{4039, ""},
                {4056, ""},{4065, ""},{4012, ""},{4066, ""},{4087, ""},{4070, ""},{4099, ""},{5231, ""},{5555, ""},
                {5468, ""},{5291, ""},{5897, ""},{6983, ""},{6458, ""},{6969, ""},{9863, ""},{7778, ""},{9326, ""},{98653, ""},
            };

            var keys = entries.Keys.ToArray();

            foreach(var key in keys)
            {
                entries[key] = FindLargestDescentNumber(key);
            }

            var counter = 0;
            foreach(var entry in entries)
            {
                Console.WriteLine("#{0} )  largest descent number for {1} is : {2}", ++counter, entry.Key, entry.Value );
                Console.WriteLine();
                System.Threading.Thread.Sleep(5000);
            }

            Console.WriteLine("Press Enter key to exit");
            Console.ReadLine();
        }

        private static string FindLargestDescentNumber(int number)
        {
            var result = "-1";
            ///(x,y) =(2N, -N)
            ///(x + Ku)(y - Kv) or (x - Ku)(y + Kv)
            ///GCD(5, 3) = 1
            ///remainder of 1/5 = 5; remainder of 1/3 = 3
            /// :. (x - K5) (y + K3) ==> (2N - 5K) (-N + 3K)
            /// this is math, we have choice to decide on the operator type to use and where to put it depending on what ever suits
            /// our need ::)
            /// 

            /// 2)
            /// Simplifying the equations
            /// 2N - 5k = 1
            /// -N + 3k = 0  ==> N - 2K = 1
            ///                  N - 1  = 2K
            ///                 (N - 1)/2 = K
            ///                 

            //magic constant k
            var k = (number - 1) / 2;

            var numThrees = ((-number) + (3 * k));  //here we are adding the remainer of 5s 3 multiple to the number of threes
            var numFives = ((2 * number) - (5 * k)); //here we are adding the remainer of 3s 5 multiple to the number of fives

            //if both numbers are neg return -1

            if (numThrees < 1 && numFives < 1)
                return "-1";

            if(numThrees > 2)
            {
                var mod = numThrees % 3;
                //var newNumbThrees =

                var extraFives = ((numThrees - mod) * 5) / 3; //normalized the new number from the 3s  multiple of 5 realm to that of the 5s multiple of 3 realm
                numFives = extraFives + numFives; // new number of 5s 
                numThrees = mod; // new number of 3s
            }

            result = GenerateExpression(numFives, numThrees);


            return result;
        }

        static char fivesChar = (5).ToString().ToCharArray()[0];

        static char threesChar = (3).ToString().ToCharArray()[0];

        private static string GenerateExpression(int numFives, int numThrees)
        {

            if (numFives < 0 || numThrees < 0)
                return "-1";
            var fives = new String( fivesChar, numFives * 3);

            var threes = new String(threesChar, numThrees * 5);

            var result = String.Concat(fives, threes);

            return result;
        }
    }
}
