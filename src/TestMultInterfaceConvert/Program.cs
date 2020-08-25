using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultInterfaceConvert
{
    public interface IA
    {
        void FuncA();
    }

    public interface IB
    {
        void FuncB();
    }

    public class TestClass: IA, IB
    {
        public void FuncA()
        {
            Console.WriteLine("A");
        }

        public void FuncB()
        {
            Console.WriteLine("B");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IA test = new TestClass();
            test.FuncA();
            ((IB)test).FuncB();

            Console.ReadLine();
        }
    }
}
