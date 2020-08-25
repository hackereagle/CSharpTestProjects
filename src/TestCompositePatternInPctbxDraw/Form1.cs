using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCompositePatternInPctbxDraw
{
    public partial class Form1 : Form
    {
        #region Private Field
        private bool drawCircle = false, drawRect = false;
        private Bitmap display, temp;
        private DrawCircle _drawCircle;
        private DrawRect _drawRect;
        #endregion Private Field
        public Form1()
        {
            InitializeComponent();
            display = new Bitmap(256, 256);
            this.pictureBox1.Image = display;
            //refer to https://social.msdn.microsoft.com/Forums/windows/en-US/8dab0381-3c47-47bb-bc79-e55a5c4dc10b/how-to-uncheck-radiobuttons-at-form-load?forum=winforms
            this.rbCircle.TabStop = false;
            this.rbRect.TabStop = false;

            _drawCircle = new DrawCircle();
            _drawRect = new DrawRect();
        }

        private System.Drawing.Point startPoint;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = new Point(e.X, e.Y);
            temp = display.Clone(new System.Drawing.Rectangle(0, 0, display.Width, display.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Left) && drawCircle == true && temp != null)
            {
                display = temp.Clone(new System.Drawing.Rectangle(0, 0, display.Width, display.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                _drawCircle.Draw(display, new List<Point>(new Point[] { startPoint, new Point(e.X, e.Y)}));
                this.pictureBox1.Image = display;
            }
            else if ((e.Button == System.Windows.Forms.MouseButtons.Left) && drawRect == true && temp != null)
            {
                display = temp.Clone(new System.Drawing.Rectangle(0, 0, display.Width, display.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                _drawRect.Draw(display, new List<Point>(new Point[] { startPoint, new Point(e.X, e.Y)}));
                this.pictureBox1.Image = display;
            }
        }

        private void RbCheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCircle.Checked) {
                drawCircle = true;
                drawRect = false;
            }
            else if(this.rbRect.Checked) {
                drawCircle = false;
                drawRect = true;
            }
            else {
                drawCircle = false;
                drawRect = false;
            }
        }
    }
}
