using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreateInstanceByAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 2; i++)
            {
                ITestCreateInstance temp = (ITestCreateInstance)System.Reflection.Assembly.Load("TestCreateInstanceByAssembly").CreateInstance("TestCreateInstanceByAssembly.Class" + (i + 1).ToString());
                temp.Test();
            }

            Console.ReadLine();
        }
    }
}
