using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultArrayOperate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = new int[3, 4] 
                            { { 1, 1, 1, 1},
                              { 2, 2, 2, 2},
                              { 3, 3, 3, 3} };

            // this refer to https://stackoverflow.com/questions/4260207/how-do-you-get-the-width-and-height-of-a-multi-dimensional-array
            Console.WriteLine($"using GetLength to get 1st dim:{test.GetLength(0)}");
            Console.WriteLine($"using GetLength to get 2nd dim:{test.GetLength(1)}");

            // test other method
            Console.WriteLine($"rank: {test.Rank}"); // note: matrix's rank!
            Console.ReadLine();
        }
    }
}
