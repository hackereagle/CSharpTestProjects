using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfAndAbstra
{
    public abstract class Triangle : IShape
    {
        #region interface properties
        public int Area { get { return CalculateArea(); } }
        public Point Center { get { return GetTriangleCen(); } }
        #endregion interface properties

        public int bottom = 0, side1 = 0, side2 = 0;
        protected abstract int CalculateArea();
        protected abstract Point GetTriangleCen();
    }

    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(int Bottom, int TwoSide)
        {
            bottom = Bottom;
            side1 = side2 = TwoSide;
            System.Console.WriteLine("I am isosceles tringle~~~! My bottom = {0}, side1 = side2 = {1}, Area = {2}", bottom, side1, Area);
        }

        protected override int CalculateArea()
        {
            double theta = Math.Asin(Convert.ToDouble(bottom) / 2.0 / Convert.ToDouble(side1));
            int height = Convert.ToInt32(Convert.ToDouble(side1) * Math.Cos(theta));
            return bottom * height / 2;
        }
        protected override Point GetTriangleCen()
        {
            double theta = Math.Asin(Convert.ToDouble(bottom) / 2.0 / Convert.ToDouble(side1));
            int height = Convert.ToInt32(Convert.ToDouble(side1) * Math.Cos(theta));
            return new Point(bottom / 2, height / 3);
        }
    }

    public class RegularTraiangle : Triangle
    {
        public RegularTraiangle(int Side)
        {
            bottom = side1 = side2 = Side;
            System.Console.WriteLine("I am regular tringle~~~! My bottom = = side1 = side2 = {0}, Area = {1}", bottom, Area);
        }

        protected override int CalculateArea()
        {
            double theta = Math.Asin(Convert.ToDouble(bottom) / 2.0 / Convert.ToDouble(side1));
            int height = Convert.ToInt32(Convert.ToDouble(side1) * Math.Cos(theta));
            return bottom * height / 2;
        }
        protected override Point GetTriangleCen()
        {
            double theta = Math.Asin(Convert.ToDouble(bottom) / 2.0 / Convert.ToDouble(side1));
            int height = Convert.ToInt32(Convert.ToDouble(side1) * Math.Cos(theta));
            return new Point(bottom / 2, height / 3);
        }
    }
}
