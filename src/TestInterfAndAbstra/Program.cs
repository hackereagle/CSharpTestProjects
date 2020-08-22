using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfAndAbstra
{
    // 我的規劃：
    //                                 +--正方形(Square)
    //               +----四邊形---+--長方形(Rectangle)
    //               |  (Quadrangle)
    //形狀(Shape)----+----三角形-------+--等腰三角形(IsoscelesTriangle)
    //               |  (Triangle)     |--正三角形(RegularTraiangle)
    //               +----圓形-------+--正圓形(Circle)
    //                  (Round)      |--橢圓形(Ellipse)
    //
    // 其中Shape 是介面，四邊形、三角形、圓形等是抽象類別
    //
    // reference:
    //      https://dotblogs.com.tw/atowngit/archive/2009/08/26/10253.aspx
    //      https://jeffprogrammer.wordpress.com/2015/07/27/%E6%B7%BA%E8%AB%87-c-%E6%8A%BD%E8%B1%A1%E9%A1%9E%E5%88%A5%E8%88%87%E4%BB%8B%E9%9D%A2/
    //      

    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(16);
            Rectangle rectangle = new Rectangle(20, 5);
            IsoscelesTriangle isoscelesTriangle = new IsoscelesTriangle(10, 25);
            RegularTraiangle regularTriangle = new RegularTraiangle(25);
            Circle circle = new Circle(25);
            Ellipse ellipse = new Ellipse(25, 10);

            System.Console.ReadLine();
        }
    }
}
