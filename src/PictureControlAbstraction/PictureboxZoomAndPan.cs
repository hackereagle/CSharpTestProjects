using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCSEM.ImgProcToolsGui.BusinessLogic.Interface;

namespace JCSEM.ImgProcToolsGui.BusinessLogic
{
    public class PictureboxZoomAndPan : JCSEM.ImgProcToolsGui.BusinessLogic.Interface.IZoomAndPan<System.Drawing.Bitmap, System.Drawing.Point, System.Drawing.Size>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcPictureBox"></param>
        public PictureboxZoomAndPan(System.Windows.Forms.PictureBox srcPictureBox)
        {
            _pcbox = srcPictureBox;
            DisplaySize = new System.Drawing.Size(100, 100);
            origLeftTop = new System.Drawing.Point(0, 0);
            totalZoom = 1;
        }

        #region Privates Field
        private System.Drawing.Size DisplaySize;
        private System.Drawing.Size DisplayImgOrgSize;
        private System.Drawing.Point origLeftTop;
        private double totalZoom;
        private System.Windows.Forms.PictureBox _pcbox;
        #endregion Privates Field

        #region Properties Field
        public Point get_LeftTopPoint
        {
            get
            {
                return origLeftTop;
            }
        }

        public double ZoomRatio
        {
            get
            {
                return totalZoom;
            }
        }
        #endregion Properties Field

        /// <summary>
        /// display image
        /// </summary>
        /// <param name="DisplayImg"></param>
        /// <returns></returns>
        public bool Disp(System.Drawing.Bitmap DisplayImg)
        {
            try
            {
                DisplaySize = new System.Drawing.Size(DisplayImg.Width, DisplayImg.Height);
                DisplayImgOrgSize = new System.Drawing.Size(DisplayImg.Width, DisplayImg.Height);
                origLeftTop = new System.Drawing.Point(0, 0);
                totalZoom = 1;

                _pcbox.Image = DisplayImg;
            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In PictureboxZoomAndPan.Disp: " + ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In PictureboxZoomAndPan.Disp: " + ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// according to mouse movie translate picture
        /// </summary>
        /// <param name="DisplayImg"></param>
        /// <param name="CurrentMousePos"></param>
        /// <param name="LastMousePos"></param>
        public void MovePicture(System.Drawing.Bitmap DisplayImg, System.Drawing.Point CurrentMousePos, System.Drawing.Point LastMousePos)
        {
            try
            {
                System.Drawing.Size LeftTopDelta = new System.Drawing.Size();
                LeftTopDelta.Width = CurrentMousePos.X - LastMousePos.X;
                LeftTopDelta.Height = CurrentMousePos.Y - LastMousePos.Y;

                origLeftTop.X += LeftTopDelta.Width;
                origLeftTop.Y += LeftTopDelta.Height;

                System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap(_pcbox.Width, _pcbox.Height);
                System.Drawing.Rectangle ZoomSize = new System.Drawing.Rectangle(origLeftTop.X, origLeftTop.Y, DisplaySize.Width, DisplaySize.Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newBitmap);
                g.DrawImage(DisplayImg, ZoomSize);

                _pcbox.Image = newBitmap;
                _pcbox.Refresh();

            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In PictureboxZoomAndPan.MovePicture: " + ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In PictureboxZoomAndPan.MovePicture: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// according to mouse wheel delta zoom in or zoom out DisplayImg
        /// </summary>
        /// <param name="DisplayImg"></param>
        /// <param name="WheelDelta"></param>
        /// <param name="mousePos"></param>
        public void ZoomPicture(System.Drawing.Bitmap DisplayImg, double WheelDelta, System.Drawing.Point mousePos)
        {
            if (mousePos.X == -1 && mousePos.Y == -1)
                mousePos = origLeftTop;

            double zoom;
            System.Drawing.Size LeftTopDelta = new System.Drawing.Size();
            try
            {
                if (WheelDelta > 0)
                {
                    if (totalZoom < 300)
                    {
                        zoom = Math.Pow(1.25, WheelDelta / 120.0);
                        LeftTopDelta.Width = Convert.ToInt32(Convert.ToDouble(mousePos.X - origLeftTop.X) * 0.25);
                        LeftTopDelta.Height = Convert.ToInt32(Convert.ToDouble(mousePos.Y - origLeftTop.Y) * 0.25);
                        origLeftTop.X -= LeftTopDelta.Width;
                        origLeftTop.Y -= LeftTopDelta.Height;
                    }
                    else
                        zoom = 1;
                }
                else
                {
                    if (totalZoom > 0.03)
                    {
                        zoom = Math.Pow(0.85, WheelDelta / (-120.0));
                        LeftTopDelta.Width = Convert.ToInt32(Convert.ToDouble(mousePos.X - origLeftTop.X) * 0.25);
                        LeftTopDelta.Height = Convert.ToInt32(Convert.ToDouble(mousePos.Y - origLeftTop.Y) * 0.25);
                        origLeftTop.X += LeftTopDelta.Width;
                        origLeftTop.Y += LeftTopDelta.Height;
                    }
                    else
                        zoom = 1;
                }
                totalZoom = totalZoom * zoom;


                DisplaySize.Width = Convert.ToInt32(DisplaySize.Width * zoom);
                DisplaySize.Height = Convert.ToInt32(DisplaySize.Height * zoom);

                System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap(_pcbox.Width, _pcbox.Height);
                System.Drawing.Rectangle ZoomSize = new System.Drawing.Rectangle(origLeftTop.X, origLeftTop.Y, DisplaySize.Width, DisplaySize.Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newBitmap);
                g.DrawImage(DisplayImg, ZoomSize);

                _pcbox.Image = newBitmap;
                _pcbox.Refresh();
            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In PictureboxZoomAndPan.ZoomPicture: " + ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In PictureboxZoomAndPan.ZoomPicture: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// calculate real coordinate from picture after zoom in or zoom out
        /// </summary>
        /// <param name="RealPoint"></param>
        /// <param name="MousePos"></param>
        public void CoordinateAfterZoom(ref System.Drawing.Point RealPoint, System.Drawing.Point MousePos)
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

                    if (RealPoint.X > DisplayImgOrgSize.Width)
                        RealPoint.X = DisplayImgOrgSize.Width;

                    if (RealPoint.Y > DisplayImgOrgSize.Height)
                        RealPoint.Y = DisplayImgOrgSize.Height;
                }
                else
                {
                    RealPoint.X = MousePos.X - origLeftTop.X;
                    RealPoint.Y = MousePos.Y - origLeftTop.Y;
                }
            }

            if ((MousePos.X - origLeftTop.X) > DisplaySize.Width)
                RealPoint.X = DisplayImgOrgSize.Width;

            if ((MousePos.Y - origLeftTop.Y) > DisplaySize.Height)
                RealPoint.Y = DisplayImgOrgSize.Height;
        }
    }
}
