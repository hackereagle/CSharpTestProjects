using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRemoveElemFromStrArr
{
    class Program
    {
        // this method refer to
        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/77ed73c3-fb56-414a-bacf-0cdcd41afff4/remove-element-from-an-array-of-string?forum=csharpgeneral
        static void Main(string[] args)
        {
            string[] test = { "yo~~~", "Hellow World", "this is third string", "HIROSE", "RORZE"};
            Console.WriteLine($"Before removing, string array length = {test.Length}");
            foreach (string str in test)
            {
                Console.WriteLine(str);
            }

            test = test.Where(w => w != test[0]).ToArray();
            Console.WriteLine($"\nAfer removing, string array length = {test.Length}");
            foreach (string str in test)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}
