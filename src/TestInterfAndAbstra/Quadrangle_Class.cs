using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfAndAbstra
{
    public abstract class Quadrangle : IShape
    {
        #region interface properties
        public int Area { get { return width * height; } }
        public Point Center { get { return new Point(width / 2, height / 2); } }
        #endregion interface properties

        public int width = 0, height = 0;
    }

    public class Square : Quadrangle
    {
        public Square(int SideLength)
        {
            width = SideLength;
            height = SideLength;
            System.Console.WriteLine("I am square~~~! My width = height = {0}, Area = {1}", width, Area);
        }
    }

    public class Rectangle : Quadrangle
    {
        public Rectangle(int Width, int Height)
        {
            width = Width;
            height = Height;
            System.Console.WriteLine("I am rectangle~~~! My width = {0}, height = {1}, Area = {2}", width, height, Area);
        }
    }

}
