using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbstractClassAndChildClassCtorOrder
{
    // refer to https://dotblogs.com.tw/mobile_net/2016/08/31/100829
    public abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Shape()");
        }

        protected string mShape;
        public string ShapeName { get { return mShape; } }

        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public Circle()
        {
            mShape = "Circle";
            Console.WriteLine("In Circle ctor");
        }

        public override void Draw()
        {
            Console.WriteLine($"Draw {ShapeName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Circle();
            shape.Draw();
            Console.ReadLine();
        }
    }
}
