using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormatOutputStr
{
    class TestFormat
    {
        public int X { set; get; }
        public int Y { set; get; }

        public TestFormat(int x, int y)
        {
            X = x; Y = y;
        }

        public override string ToString()
        {
            return $"X:{this.X}, Y:{this.Y}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            TestFormat test = new TestFormat(2, 7);
            Console.WriteLine(test.ToString());
            Console.WriteLine("X = " + test.X.ToString() + ", Y = " + test.Y.ToString());
            Console.ReadLine();
        }
    }
}
