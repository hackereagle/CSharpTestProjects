using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompositePatternInPctbxDraw
{
    public class HObject
    {
        public HObject()
        {
        }
    }

    public interface IDrawShape
    {
        HObject Region
        { get; }

        void Draw(System.Drawing.Bitmap bitmap, List<System.Drawing.Point> points);
    }
}
