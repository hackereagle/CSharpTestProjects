using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCSEM.ImgProcToolsGui.BusinessLogic
{
    class PictureboxCtrl
    {
        public PictureboxCtrl(System.Windows.Forms.PictureBox pctbxDisp)
        {
            _DisplayImg = null;
            tempBmpWhenDrawing = null;
            _tbMouseStatue = null;

            if (!InitialPicturebox(pctbxDisp))
                System.Windows.Forms.MessageBox.Show("PictureboxCtrl initial fail!");

            _pctbxZoomAndPan = new PictureboxZoomAndPan(_pctbxDisp);
        }

        public PictureboxCtrl(System.Windows.Forms.PictureBox pctbxDisp, System.Windows.Controls.TextBlock tbMouseStatue)
        {
            _DisplayImg = null;
            tempBmpWhenDrawing = null;
            _tbMouseStatue = tbMouseStatue;

            if(!InitialPicturebox(pctbxDisp))
                System.Windows.Forms.MessageBox.Show("PictureboxCtrl initial fail!");

            _pctbxZoomAndPan = new PictureboxZoomAndPan(_pctbxDisp);
        }

        private bool InitialPicturebox(System.Windows.Forms.PictureBox pctbxDisp)
        {
            try
            {
                _pctbxDisp = pctbxDisp;
                _pctbxDisp.BackColor = System.Drawing.Color.Gray;
                _pctbxDisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
                _pctbxDisp.MouseDown += new System.Windows.Forms.MouseEventHandler(pctbxDisp_MouseDown);
                _pctbxDisp.MouseMove += new System.Windows.Forms.MouseEventHandler(pctbxDisp_MouseMove);
                _pctbxDisp.MouseWheel += new System.Windows.Forms.MouseEventHandler(pctbxDisp_MouseWheel);
                _pctbxDisp.MouseUp += new System.Windows.Forms.MouseEventHandler(pctbxDisp_MouseUp);
            }
            catch (System.Exception ex)
            {
                _pctbxDisp = null;
                System.Console.WriteLine("In PictureboxCtrl.InitialPicturebox: " + ex.Message);
                return false;
            }
            return true;
        }

        #region Privates Field
        static private JCSEM.ImgProcToolsGui.BusinessLogic.PictureboxZoomAndPan _pctbxZoomAndPan;
        private static System.Drawing.Bitmap SrcImg, _DisplayImg, BeGotGrayImg, tempBmpWhenDrawing;
        private bool drawLine = false, drawCircle = false, drawRect = false;
        static System.Windows.Forms.PictureBox _pctbxDisp;
        private System.Windows.Controls.TextBlock _tbMouseStatue;
        private string _mouseStatue;
        #endregion Privates Field

        #region Property Field
        //我覺得這邊的屬性之後要變成dependency properties
        public bool DrawLine
        {
            set
            {
                drawLine = value;
            }
        }

        public bool DrawCircle
        {
            set
            {
                drawCircle = value;
            }
        }

        public bool DrawRect
        {
            set
            {
                drawRect = value;
            }
        }

        public string MouseStatue
        {
            get { return _mouseStatue;}
        }

        public System.Drawing.Bitmap DisplayImg
        {
            get { return _DisplayImg;}
        }
        #endregion Property Field

        private static System.Drawing.Imaging.ColorPalette Set_8bppIndexed_Palette(System.Drawing.Imaging.ColorPalette inputPalette)
        {
            System.Drawing.Imaging.ColorPalette pal = inputPalette;
            if (inputPalette.Entries.Length < 1)
            {
                for (int i = 0; i < 256; i++)
                    pal.Entries[i] = System.Drawing.Color.FromArgb(255, i, i, i);
            }

            return pal;
        }

        private void IniBeGotGrayImg(out System.Drawing.Bitmap beGotGrayImg, System.Drawing.Bitmap srcImg)
        {
            //不知道為什麼，在這個區塊以外的地方使用SrcImg都一定會出泛型的問題，我猜與PixelFormat有關，因為若將SrcImg的PixelFormat改成format8bppindexed一定會出問題；Format24bppRgb一定不會，這個問題以後有時間再解決。
            // 後來發現是調色盤的問題，但目前解決不了，以後再研究
            //BeGotGrayImg = SrcImg.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            if (SrcImg.Palette.Entries.Length < 1)
                beGotGrayImg = SrcImg.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            else
            {
                beGotGrayImg = SrcImg.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height), SrcImg.PixelFormat);
                if (SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                    beGotGrayImg.Palette = Set_8bppIndexed_Palette(beGotGrayImg.Palette);
            }
        }

        public bool Disp(System.Drawing.Bitmap DisplayedImg)
        {
            SrcImg = DisplayedImg;
            IniBeGotGrayImg(out BeGotGrayImg, SrcImg);

            _DisplayImg = SrcImg.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            return _pctbxZoomAndPan.Disp(_DisplayImg);
        }

        #region relate with picture control code
        private System.Drawing.Point StartPoint;
        private void pctbxDisp_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            StartPoint.X = e.X;
            StartPoint.Y = e.Y;
            tempBmpWhenDrawing = _DisplayImg.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        }

        private bool IsDraggingImg(System.Windows.Forms.MouseEventArgs e, System.Drawing.Bitmap ClickedImg)
        {
            bool LeftButtonPressed = (e.Button == System.Windows.Forms.MouseButtons.Left);
            bool IsInitial = (ClickedImg != null && (StartPoint.X != 0 && StartPoint.Y != 0));
            bool NotDraw = (drawLine == false && drawCircle == false && drawRect == false);

            return LeftButtonPressed && IsInitial && NotDraw;
        }

        private void pctbxDisp_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Drawing.Point CurrentPoint = new System.Drawing.Point(e.X, e.Y);

            try
            {
                if (IsDraggingImg(e, _DisplayImg))
                {
                    _pctbxZoomAndPan.MovePicture(_DisplayImg, CurrentPoint, StartPoint);
                    StartPoint.X = e.X;
                    StartPoint.Y = e.Y;
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && drawLine == true)
                {
                    // draw line
                    _DisplayImg = tempBmpWhenDrawing.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(_DisplayImg);
                    g.DrawLine(pen, StartPoint.X, StartPoint.Y, e.X, e.Y);
                    _pctbxDisp.Image = _DisplayImg;
                    _pctbxDisp.Refresh();
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && drawCircle == true)
                {
                    // draw circle
                    
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left && drawRect == true)
                {
                    // draw rectangle
                    
                }
                else
                {
                    
                    System.Drawing.Point RealPosition = new System.Drawing.Point(0, 0);
                    _pctbxZoomAndPan.CoordinateAfterZoom(ref RealPosition, CurrentPoint);
                    _mouseStatue = "(x, y) = (" + RealPosition.X.ToString() + ", " + RealPosition.Y.ToString() + ")";
                    if (_DisplayImg != null && e.X > 0 && e.Y > 0 && RealPosition.X < _DisplayImg.Width && RealPosition.Y < _DisplayImg.Height)
                        _mouseStatue = _mouseStatue + " || Gray = " + BeGotGrayImg.GetPixel(RealPosition.X, RealPosition.Y).ToString();
                    else
                        _mouseStatue = _mouseStatue + " || Gray = ";

                    if (_tbMouseStatue != null)
                        _tbMouseStatue.Text = _mouseStatue;
                }
            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In pctbxDisp_MouseMove: " + ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In pctbxDisp_MouseMove: " + ex.ToString());
            }
        }

        private void pctbxDisp_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_DisplayImg != null)
            {
                System.Drawing.Point CurrentMousePos = new System.Drawing.Point(e.X, e.Y);
                _pctbxZoomAndPan.ZoomPicture(_DisplayImg, e.Delta, CurrentMousePos);
            }
        }

        private void pctbxDisp_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //drawLine = false;
            //drawCircle = false;
            //drawRect = false;
            if (tempBmpWhenDrawing != null)
                tempBmpWhenDrawing.Dispose();
        }
        #endregion relate with picture control code
    }
}
