using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfAndAbstra
{
    public abstract class Round : IShape
    {
        #region interface properties
        public int Area { get { return CalculateArea(); } }
        public Point Center { get { return GetTriangleCen(); } }
        #endregion interface properties

        protected const double PI = 3.1415926;

        protected abstract int CalculateArea();
        protected abstract Point GetTriangleCen();
    }

    public class Circle : Round
    {
        public int r = 0;
        public Circle(int Radius)
        {
            r = Radius;
            System.Console.WriteLine("I am circle~~~! My radius = {0}, Area = {1}", r, Area);
        }

        protected override int CalculateArea()
        {
            return Convert.ToInt32(Convert.ToDouble(r) * Convert.ToDouble(r) * PI / 2.0);
        }
        protected override Point GetTriangleCen()
        {
            return new Point(r / 2, r / 2);
        }
    }

    public class Ellipse : Round
    {
        public int major = 0, minor = 0;
        public Ellipse(int Major, int Minor)
        {
            major = Major; minor = Minor;
            System.Console.WriteLine("I am ellipse~~~! My major = {0}, minor = {1}, Area = {2}", major, minor, Area);
        }

        protected override int CalculateArea()
        {
            return Convert.ToInt32(Convert.ToDouble(major) * Convert.ToDouble(minor) * PI);
        }
        protected override Point GetTriangleCen()
        {
            return new Point(major / 2, minor / 2);
        }
    }
}
