using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Display;

namespace TestPctbxZoomAndCppDll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ImagePath;
        Bitmap SrcImg, DisplayImg;
        private Size DisplaySize;
        private Point origLeftTop = new Point(0, 0);
        private void btnLoad_Click(object sender, EventArgs e)
        {
            openPicture.Filter = "JPEG檔|*.jpg*|BMP檔|*.bmp*|TIFF檔|*.tiff|PNG檔|*.png*";
            openPicture.RestoreDirectory = true;
            openPicture.FilterIndex = 2;
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                lblPicturePath.Visible = true;
                lblPicturePath.Text = openPicture.FileName;

                ImagePath = openPicture.FileName;
                SrcImg = new Bitmap(openPicture.FileName);
                DisplayImg = SrcImg.Clone(new Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                pctbx.Image = DisplayImg;

                DisplaySize.Width = DisplayImg.Width;
                DisplaySize.Height = DisplayImg.Height;
                if ((origLeftTop.X == 0 && origLeftTop.Y == 0))
                {
                    origLeftTop.X = 0;
                    origLeftTop.Y = 0;
                }
                
            }
        }

        PctbxControl pctbxCtrl = new PctbxControl();
        private void pctbx_MouseWheel(object sender, MouseEventArgs e)
        {
            if (DisplayImg != null)
            {
                Point CurrentMousePos = new Point(e.X, e.Y);

                pctbxCtrl.ZoomPicture(DisplayImg, pctbx, e.Delta, CurrentMousePos,
                    ref origLeftTop, ref DisplaySize);
            }
            
        }

        Point StartPoint;
        private void pctbx_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint.X = e.X;
            StartPoint.Y = e.Y;
        }

        private void pctbx_MouseMove(object sender, MouseEventArgs e)
        {
            Point CurrentPoint = new Point(e.X, e.Y);
            Point RealPosition = new Point(0, 0);
            string DisplayStr;
            pctbxCtrl.CoordinateAfterZoom(ref RealPosition, CurrentPoint, ref origLeftTop, ref DisplaySize);
            DisplayStr = "picture box coordinate:(x, y) = (" + e.X.ToString() + ", " + e.Y.ToString() + ") ||(x, y) = (" + RealPosition.X.ToString() + ", " + RealPosition.Y.ToString() + ")";
            if (DisplayImg != null && e.X > 0 && e.Y > 0 && RealPosition.X < DisplayImg.Width && RealPosition.Y < DisplayImg.Height)
                DisplayStr = DisplayStr + " || Gray = " + SrcImg.GetPixel(RealPosition.X, RealPosition.Y).ToString();
            else
                DisplayStr = DisplayStr + " || Gray = ";
            label_position.Text = DisplayStr;

            if (e.Button == System.Windows.Forms.MouseButtons.Left && DisplayImg != null && (StartPoint.X != 0 && StartPoint.Y != 0))
            {

                pctbxCtrl.MovePicture(DisplayImg, pctbx, CurrentPoint, StartPoint, ref origLeftTop, DisplaySize);
                StartPoint.X = e.X;
                StartPoint.Y = e.Y;
            }
        }
    }
}
