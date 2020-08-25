using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCSEM.ImgProcToolsGui.BusinessLogic
{
    struct ImgInfom
    {
        public int height;
        public int width;
        public int channels;

        public int MaxGray;
        public int MinGray;
        public int Median;
        public double mean;
        public int MassGray;
        public double std;
        //public double snr;
        //public double psnr;
        public double entropy_1d;
        //public double entropy_2d;
    }

    class CalculateGetImageInformation
    {
        public CalculateGetImageInformation()
        {
            _Info.channels = 0;
            _Info.entropy_1d = 0;
            _Info.height = 0;
            _Info.MassGray = 0;
            _Info.MaxGray = 0;
            _Info.mean = 0;
            _Info.Median = 0;
            _Info.MinGray = 0;
            _Info.std = 0;
            _Info.width = 0;
        }

        private System.Drawing.Bitmap _SrcImg;
        private ImgInfom _Info;

        private double calculateEntropy_1d(int[] grayHis, UInt64 size)
        {
            double entropy = 0, Pi = 0;
            for (int i = 0; i < 256; i++)
            {
                Pi = Convert.ToDouble(grayHis[i]) / Convert.ToDouble(size);
                if (Pi != 0)
                    entropy = entropy + (-1) * (Pi * Math.Log(Pi) / Math.Log(2));
            }

            return entropy;
        }

        private unsafe double calculateStd(byte* data, UInt64 size, double mean)
        {
            double SquareSum = 0;
            for (UInt64 i = 0; i < size; i++)
            {
                SquareSum = SquareSum + Math.Pow((Convert.ToDouble(*(data + i)) - mean), 2);
            }

            return Math.Sqrt(SquareSum / Convert.ToDouble(size));
        }

        private void calculateImgInfom_parallel()
        {
            _Info.width = _SrcImg.Width;
            _Info.height = _SrcImg.Height;

            int startTime = Environment.TickCount;
            try
            {
                if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    _Info.channels = 1;
                    unsafe
                    {
                        System.Drawing.Imaging.BitmapData ptr = _SrcImg.LockBits(
                                                                    new System.Drawing.Rectangle(0, 0, _SrcImg.Width, _SrcImg.Height),
                                                                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                                    System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        byte* data = (byte*)ptr.Scan0.ToPointer();

                        _Info.MinGray = 255; _Info.MaxGray = 0;
                        UInt64 sum = 0, gray = 0;
                        //for (int i = 0; i < _SrcImg.Width * _SrcImg.Height; i++)
                        //{
                        //    gray = Convert.ToUInt64(*(data + i));
                        //    grayHis[gray]++;
                        //    sum += gray;
                        //    if (gray > Convert.ToUInt64(_Info.MaxGray)) _Info.MaxGray = Convert.ToInt16(gray);
                        //    if (gray < Convert.ToUInt64(_Info.MinGray)) _Info.MinGray = Convert.ToInt16(gray);
                        //}
                        int[,] grayHis_thread = new int[_SrcImg.Height, 256];
                        Parallel.For(0, _SrcImg.Height, j =>
                        {
                            for (int i = 0; i < _SrcImg.Width; i++)
                            {
                                gray = Convert.ToUInt64(*(data + i));
                                grayHis_thread[j, gray]++;
                                sum += gray;
                                //if (gray > Convert.ToUInt64(_Info.MaxGray)) _Info.MaxGray = Convert.ToInt16(gray);
                                //if (gray < Convert.ToUInt64(_Info.MinGray)) _Info.MinGray = Convert.ToInt16(gray);
                            }
                        }
                        );
                        

                        _Info.mean = Convert.ToDouble(sum) / Convert.ToDouble(_SrcImg.Width * _SrcImg.Height);
                        _Info.std = calculateStd(data, Convert.ToUInt64(_SrcImg.Width) * Convert.ToUInt64(_SrcImg.Height), _Info.mean);
                        _Info.MassGray = grayHis.Max();

                        double halfSize = (Convert.ToDouble(_SrcImg.Width) * Convert.ToDouble(_SrcImg.Height) / 2);
                        gray = 0;
                        for (double median = 0; median < halfSize; gray++)
                        {
                            median = median + Convert.ToDouble(grayHis[gray]);
                            if (median > halfSize)
                                _Info.Median = Convert.ToInt16(gray);
                        }

                        _Info.entropy_1d = calculateEntropy_1d(grayHis, Convert.ToUInt64(_SrcImg.Width) * Convert.ToUInt64(_SrcImg.Height));

                        _SrcImg.UnlockBits(ptr);
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("In CalculateGetImageInformation.calculateImgInfom " + ex.Message);
            }
            System.Console.WriteLine("CalculateGetImageInformation.calculateImgInfom_parallel spend " + (Environment.TickCount - startTime) + "ms");
        }

        private void calculateImgInfom()
        {
            _Info.width = _SrcImg.Width;
            _Info.height = _SrcImg.Height;

            int startTime = Environment.TickCount;
            try
            {
                if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    _Info.channels = 1;
                    unsafe
                    {
                        System.Drawing.Imaging.BitmapData ptr = _SrcImg.LockBits(
                                                                    new System.Drawing.Rectangle(0, 0, _SrcImg.Width, _SrcImg.Height),
                                                                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                                    System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        byte* data = (byte*)ptr.Scan0.ToPointer();

                        _Info.MinGray = 255; _Info.MaxGray = 0;
                        UInt64 sum = 0, gray = 0;
                        for (int i = 0; i < _SrcImg.Width * _SrcImg.Height; i++)
                        {
                            gray = Convert.ToUInt64(*(data + i));
                            grayHis[gray]++;
                            sum += gray;
                            if (gray > Convert.ToUInt64(_Info.MaxGray)) _Info.MaxGray = Convert.ToInt16(gray);
                            if (gray < Convert.ToUInt64(_Info.MinGray)) _Info.MinGray = Convert.ToInt16(gray);
                        }

                        _Info.mean = Convert.ToDouble(sum) / Convert.ToDouble(_SrcImg.Width * _SrcImg.Height);
                        _Info.std = calculateStd(data, Convert.ToUInt64(_SrcImg.Width) * Convert.ToUInt64(_SrcImg.Height), _Info.mean);
                        _Info.MassGray = grayHis.Max();

                        double halfSize = (Convert.ToDouble(_SrcImg.Width) * Convert.ToDouble(_SrcImg.Height) / 2);
                        gray = 0;
                        for (double median = 0; median < halfSize; gray++)
                        {
                            median = median + Convert.ToDouble(grayHis[gray]);
                            if (median > halfSize)
                                _Info.Median = Convert.ToInt16(gray);
                        }

                        _Info.entropy_1d = calculateEntropy_1d(grayHis, Convert.ToUInt64(_SrcImg.Width) * Convert.ToUInt64(_SrcImg.Height));

                        _SrcImg.UnlockBits(ptr);
                    }
                }
                else if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    _Info.channels = 3;
                    unsafe
                    {
                        System.Drawing.Imaging.BitmapData ptr = _SrcImg.LockBits(
                                                                    new System.Drawing.Rectangle(0, 0, _SrcImg.Width, _SrcImg.Height),
                                                                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        byte* data = (byte*)ptr.Scan0.ToPointer();

                        UInt32 R = 0, G = 0, B = 0;
                        for (int i = 0; i < _SrcImg.Width * _SrcImg.Height; i++)
                        {
                            R = Convert.ToUInt32(*(data + (i * 3)));
                            G = Convert.ToUInt32(*(data + (i * 3) + 1));
                            B = Convert.ToUInt32(*(data + (i * 3) + 2));
                            His_r[R]++; His_g[G]++; His_b[B]++;
                        }
                    }
                }
                else if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb || _SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppRgb)
                {
                    _Info.channels = 4;
                    unsafe
                    {
                        System.Drawing.Imaging.BitmapData ptr = _SrcImg.LockBits(
                                                                    new System.Drawing.Rectangle(0, 0, _SrcImg.Width, _SrcImg.Height),
                                                                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                                    System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                        byte* data = (byte*)ptr.Scan0.ToPointer();

                        UInt32 R = 0, G = 0, B = 0;
                        for (int i = 0; i < _SrcImg.Width * _SrcImg.Height; i++)
                        {
                            R = Convert.ToUInt32(*(data + (i * 4)));
                            G = Convert.ToUInt32(*(data + (i * 4) + 1));
                            B = Convert.ToUInt32(*(data + (i * 4) + 2));
                            His_r[R]++; His_g[G]++; His_b[B]++;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("In CalculateGetImageInformation.calculateImgInfom " + ex.Message);
            }
            System.Console.WriteLine("CalculateGetImageInformation.calculateImgInfom spend " + (Environment.TickCount - startTime) + "ms");
        }

        #region Relative Histogram Drawing
        private int[] grayHis = new int[256];
        private int[] His_r = new int[256];
        private int[] His_g = new int[256];
        private int[] His_b = new int[256];

        public System.Drawing.Bitmap Histogram;
        private void DrawingHistogramSolidLine(System.Drawing.Bitmap Hist, int[] gray, System.Drawing.Color color)
        {
            try
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Hist);

                System.Drawing.PointF org = new System.Drawing.PointF(5, Hist.Height - 5);
                System.Drawing.PointF p1, p2;
                System.Drawing.Pen mypen = new System.Drawing.Pen(color, 3);
                int MassGray = gray.Max(), length = gray.Length > 256 ? 256 : gray.Length;
                int interval = Convert.ToInt32(Math.Floor(Convert.ToSingle(Hist.Width) / 256));
                for (int i = 0; i < length; i++)
                {
                    p1 = new System.Drawing.PointF(org.X + (i * interval), org.Y - 1); // substrat 1 as don't let histogram hide coordinate axis
                    p2 = new System.Drawing.PointF(org.X + (i * interval), (org.Y - 1) * (1 - ((Convert.ToSingle(gray[i]) / Convert.ToSingle(MassGray)) * Convert.ToSingle(0.9))));// * Convert.ToSingle(0.9));
                    g.DrawLine(mypen, p1, p2);
                }

            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In ImageProc.DrawingHistogramSolidLine: " + ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In ImageProc.DrawingHistogramSolidLine: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void DrawingHistogramLine(System.Drawing.Bitmap Hist, int[] gray, System.Drawing.Color color)
        {
            try
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Hist);

                System.Drawing.PointF org = new System.Drawing.PointF(5, Hist.Height - 5);
                System.Drawing.PointF p_p = new System.Drawing.PointF(org.X, org.Y - 1);
                System.Drawing.PointF p_c = new System.Drawing.PointF(0, 0);
                System.Drawing.Pen mypen = new System.Drawing.Pen(color, 3);
                int MassGray = gray.Max(), length = gray.Length > 256 ? 256 : gray.Length;
                int interval = Convert.ToInt32(Math.Floor(Convert.ToSingle(Hist.Width) / 256));
                for (int i = 0; i < length; i++)
                {
                    p_c = new System.Drawing.PointF(org.X + (i * interval), (org.Y - 1) * (1 - ((Convert.ToSingle(gray[i]) / Convert.ToSingle(MassGray)) * Convert.ToSingle(0.9))));
                    g.DrawLine(mypen, p_p, p_c);
                    p_p = p_c;
                }

            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In ImageProc.DrawingHistogramLine: " + ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In ImageProc.DrawingHistogramLine: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void DrawHistogram()
        {
            const int Hist_W = 265, Hist_H = 265;
            Histogram = new System.Drawing.Bitmap(Hist_W, Hist_H, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Histogram);
            System.Drawing.Pen mypen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);
            g.FillRectangle(System.Drawing.Brushes.White, new System.Drawing.Rectangle(0, 0, _SrcImg.Width, _SrcImg.Height));

            System.Drawing.PointF org = new System.Drawing.PointF(5, 260);
            g.DrawLine(mypen, org, new System.Drawing.PointF(265, 260)); // drawing x axis
            g.DrawLine(mypen, org, new System.Drawing.PointF(5, 0)); // drawing y axis
            try
            {
                if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    DrawingHistogramSolidLine(Histogram, grayHis, System.Drawing.Color.Gray);

                    // labeling min and max gray value position
                    mypen = new System.Drawing.Pen(System.Drawing.Color.DarkBlue, Convert.ToSingle(1));
                    float[] dashValue = { 5, 5, 5, 5 };
                    mypen.DashPattern = dashValue;
                    g.DrawLine(mypen, new System.Drawing.PointF(org.X + _Info.MinGray, org.Y - 1), new System.Drawing.PointF(org.X + _Info.MinGray, Convert.ToSingle(Hist_H) * Convert.ToSingle(0.1)));
                    g.DrawLine(mypen, new System.Drawing.PointF(org.X + _Info.MaxGray, org.Y - 1), new System.Drawing.PointF(org.X + _Info.MaxGray, Convert.ToSingle(Hist_H) * Convert.ToSingle(0.1)));
                    // lebeling some data on axis
                    System.Drawing.Font font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular);
                    g.DrawString(_Info.MassGray.ToString(), font, System.Drawing.Brushes.Black, new System.Drawing.PointF(0, Convert.ToSingle(Hist_H) * Convert.ToSingle(0.1)));
                }
                else if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    DrawingHistogramLine(Histogram, His_r, System.Drawing.Color.Red);
                    DrawingHistogramLine(Histogram, His_g, System.Drawing.Color.Green);
                    DrawingHistogramLine(Histogram, His_b, System.Drawing.Color.Blue);
                }
                else if (_SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb || _SrcImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppRgb)
                {
                    DrawingHistogramLine(Histogram, His_r, System.Drawing.Color.Red);
                    DrawingHistogramLine(Histogram, His_g, System.Drawing.Color.Green);
                    DrawingHistogramLine(Histogram, His_b, System.Drawing.Color.Blue);
                }
            }
            catch (SystemException ex)
            {
                System.Windows.Forms.MessageBox.Show("In ImageProc.DrawHistogram: " + ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In ImageProc.DrawHistogram: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion Relative Histogram Drawing

        public CalculateGetImageInformation(System.Drawing.Bitmap SrcImg)
        {
            _SrcImg = SrcImg.Clone(new System.Drawing.Rectangle(0, 0, SrcImg.Width, SrcImg.Height),
                                    SrcImg.PixelFormat);
            calculateImgInfom_parallel();
            calculateImgInfom();
            DrawHistogram();
        }

        public ImgInfom getImgInfom()
        {
            ImgInfom temp = _Info;
            return _Info;
        }

    }
}
