using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestListReleaseMemory
{
    class TestObj
    {
        private byte[] data;
        public TestObj(int mb)
        {
            data = new byte[mb * 1024 * 1024];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TestObj> eatMem = new List<TestObj>();
            for (int i = 0; i < 1000; i++)
            {
                eatMem.Add(new TestObj(5));
            }

            eatMem.Clear();
            eatMem = null;
            Console.ReadLine();
        }
    }
}
