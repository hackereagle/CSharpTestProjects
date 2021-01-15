using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreateInstanceByAssembly
{
    interface ITestCreateInstance
    {
        void Test();
    }

    class Class1 : ITestCreateInstance
    {
        public Class1()
        {

        }

        void ITestCreateInstance.Test()
        {
            Console.WriteLine("Class1 created sucess!");
        }
    }

    class Class2 : ITestCreateInstance
    {
        public Class2()
        {

        }

        void ITestCreateInstance.Test()
        {
            Console.WriteLine("Class2 created sucess!");
        }
    }
}
