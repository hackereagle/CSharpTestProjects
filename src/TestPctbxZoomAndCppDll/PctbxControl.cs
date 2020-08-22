using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Display
{
    class PctbxControl
    {
        //原本的方法(没有用tableLayoutPanel)，此法是直接改變picture box的大小、位置，缺點是它是以整個Form做為移動、放大縮小的所在。
        //public void MovePicture(PictureBox PctbxDisplay, int delta_x, int delta_y)
        //{
        //    System.Drawing.Point NewLocation = new System.Drawing.Point();
        //    NewLocation.X = PctbxDisplay.Location.X + delta_x;
        //    NewLocation.Y = PctbxDisplay.Location.Y + delta_y;
        //    PctbxDisplay.Location = new System.Drawing.Point(NewLocation.X, NewLocation.Y);
        //}

        //public void ZoomPicture(PictureBox PctbxDisplay, int delta)
        //{
        //    var PctSize = PctbxDisplay.Size;
        //    PctSize.Height += delta;
        //    PctSize.Width += delta;
        //    PctbxDisplay.Size = PctSize;
        //}

        private double totalZoom;
        public PctbxControl()
        {
            totalZoom = 1;
        }

        public void MovePicture(Bitmap DisplayImg, PictureBox PctbxDisplay, Point CurrentMousePos, Point LastMousePos, ref Point origLeftTop, Size nowDisplaySize)
        {
            Size LeftTopDelta = new Size();
            LeftTopDelta.Width = CurrentMousePos.X - LastMousePos.X;
            LeftTopDelta.Height = CurrentMousePos.Y - LastMousePos.Y;

            origLeftTop.X += LeftTopDelta.Width;
            origLeftTop.Y += LeftTopDelta.Height;

            Bitmap newBitmap = new Bitmap(PctbxDisplay.Width, PctbxDisplay.Height);
            Rectangle ZoomSize = new Rectangle(origLeftTop.X, origLeftTop.Y, nowDisplaySize.Width, nowDisplaySize.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            g.DrawImage(DisplayImg, ZoomSize);

            PctbxDisplay.Image = newBitmap;
            PctbxDisplay.Refresh();
            GC.Collect();
        }

        public void ZoomPicture(Bitmap DisplayImg, PictureBox PctbxDisplay, int WheelDelta, Point mousePos, ref Point origLeftTop, ref Size DisplaySize)
        {
            double zoom;
            Size LeftTopDelta = new Size();

            if (WheelDelta > 0)
            {
                zoom = Math.Pow(1.25, WheelDelta / 120);
                LeftTopDelta.Width = Convert.ToInt32(Convert.ToDouble(mousePos.X - origLeftTop.X) * 0.25);
                LeftTopDelta.Height = Convert.ToInt32(Convert.ToDouble(mousePos.Y - origLeftTop.Y) * 0.25);
                origLeftTop.X -= LeftTopDelta.Width;
                origLeftTop.Y -= LeftTopDelta.Height;
            }
            else
            {
                zoom = Math.Pow(0.85, WheelDelta / (-120));
                LeftTopDelta.Width = Convert.ToInt32(Convert.ToDouble(mousePos.X - origLeftTop.X) * 0.25);
                LeftTopDelta.Height = Convert.ToInt32(Convert.ToDouble(mousePos.Y - origLeftTop.Y) * 0.25);
                origLeftTop.X += LeftTopDelta.Width;
                origLeftTop.Y += LeftTopDelta.Height;
            }
            totalZoom = totalZoom * zoom;

            DisplaySize.Width = Convert.ToInt32(DisplaySize.Width * zoom);
            DisplaySize.Height = Convert.ToInt32(DisplaySize.Height * zoom);

            Bitmap newBitmap = new Bitmap(PctbxDisplay.Width, PctbxDisplay.Height);
            Rectangle ZoomSize = new Rectangle(origLeftTop.X, origLeftTop.Y, DisplaySize.Width, DisplaySize.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            g.DrawImage(DisplayImg, ZoomSize);

            PctbxDisplay.Image = newBitmap;
            PctbxDisplay.Refresh();
            GC.Collect();
        }

        public void CoordinateAfterZoom(ref Point RealPoint, Point MousePos, ref Point origLeftTop, ref Size DisplaySize)
        {
            if ((MousePos.X - origLeftTop.X) < 0 || (MousePos.Y - origLeftTop.Y) < 0)
            {
                RealPoint.X = 0;
                RealPoint.Y = 0;
            }
            else
            {
                if (totalZoom > 0)
                {
                    RealPoint.X = Convert.ToInt16((double)(MousePos.X - origLeftTop.X) / totalZoom);
                    RealPoint.Y = Convert.ToInt16((double)(MousePos.Y - origLeftTop.Y) / totalZoom);
                }
                else
                {
                    RealPoint.X = MousePos.X - origLeftTop.X;
                    RealPoint.Y = MousePos.Y - origLeftTop.Y;
                }
            }
        }
    }
}
