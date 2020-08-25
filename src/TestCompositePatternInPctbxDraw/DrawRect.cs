using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompositePatternInPctbxDraw
{
    class DrawRect:IDrawShape
    {
        private HObject _region;

        public DrawRect()
        {
        }

        public HObject Region
        {
            get { return _region; }
        }

        public void Draw(System.Drawing.Bitmap bitmap, List<System.Drawing.Point> points)
        {
            System.Drawing.Point startPoint = points[0], endPoint = points[1];

            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Blue, 3);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.DrawRectangle(pen, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

            pen.Dispose(); g.Dispose();
        }
    }
}
