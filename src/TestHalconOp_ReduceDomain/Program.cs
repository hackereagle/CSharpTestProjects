using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHalconOp_ReduceDomain
{
    class Program
    {
        public static System.Drawing.Bitmap Hobject2Bitmap(HalconDotNet.HObject HImg)
        {
            if (HImg == null)
                return null;

            System.Drawing.Bitmap bmpImg;

            HalconDotNet.HTuple Channels;
            HalconDotNet.HOperatorSet.CountChannels(HImg, out Channels);

            System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            HalconDotNet.HTuple hred, hgreen, hblue, type, width, height;
            HalconDotNet.HOperatorSet.GetImagePointer3(HImg, out hred, out hgreen, out hblue, out type, out width, out height);

            bmpImg = new System.Drawing.Bitmap(width.I, height.I, pixelFmt);
            System.Drawing.Imaging.BitmapData bitmapData = bmpImg.LockBits(new System.Drawing.Rectangle(0, 0, width.I, height.I), System.Drawing.Imaging.ImageLockMode.ReadWrite, pixelFmt);
            unsafe
            {
                byte* data = (byte*)bitmapData.Scan0;
                byte* hr = (byte*)hred.IP;
                byte* hg = (byte*)hgreen.IP;
                byte* hb = (byte*)hblue.IP;

                for (int i = 0; i < width.I * height.I; i++)
                {
                    *(data + (i * 3)) = (*(hb + i));
                    *(data + (i * 3) + 1) = *(hg + i);
                    *(data + (i * 3) + 2) = *(hr + i);
                }

            }
            bmpImg.UnlockBits(bitmapData);

            return bmpImg;

        }
        
        public static HalconDotNet.HObject Bitmap2Hobject(System.Drawing.Bitmap input)
        {
            if (input == null)
                return new HalconDotNet.HObject();
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, input.Width, input.Height);

            HalconDotNet.HObject himg = new HalconDotNet.HObject();
            System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            HalconDotNet.HOperatorSet.GenImageInterleaved(out himg, srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
            input.UnlockBits(srcBmpData);

            return himg;
        }

        static void Main(string[] args)
        {
            HalconDotNet.HOperatorSet.SetSystem("clip_region", "false");

            System.Drawing.Bitmap srcImg = new System.Drawing.Bitmap("D:/Document/project/lena.bmp");
            ImageVisualizer.ImageVisualizer.TestShowVisualizer(srcImg);

            // test 1: use ReduceDomain and show processed image with Bitmap.
            HalconDotNet.HObject hImage, region, result;
            hImage = Bitmap2Hobject(srcImg);
            HalconDotNet.HOperatorSet.GenRectangle1(out region, 100, 100, 256, 256);
            HalconDotNet.HOperatorSet.ReduceDomain(hImage, region, out result);

            System.Drawing.Bitmap processedImg = Hobject2Bitmap(result);
            ImageVisualizer.ImageVisualizer.TestShowVisualizer(processedImg);

            // test 2: use CropRectangle or CropDomain
            HalconDotNet.HOperatorSet.CropDomain(result, out result);
            processedImg = Hobject2Bitmap(result);
            ImageVisualizer.ImageVisualizer.TestShowVisualizer(processedImg);

            HalconDotNet.HOperatorSet.CropRectangle1(hImage, out result, 100, 100, 256, 256);
            processedImg = Hobject2Bitmap(result);
            ImageVisualizer.ImageVisualizer.TestShowVisualizer(processedImg);
        }
    }
}
