using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTransBetween_HObj_Bitmap_BitmapImg
{
    class ImageTypeConverter
    {
        /// <summary>
        /// Convert BitmapImage to Bitmap
        /// </summary>
        /// <param name="input">BitmapImage which be converted</param>
        /// <returns>Bitmap</returns>
        public static System.Drawing.Bitmap Bitmapimage2Bitmap(System.Windows.Media.Imaging.BitmapImage input)
        {
            if (input == null)
                return null;

            using (System.IO.MemoryStream outmstream = new System.IO.MemoryStream())
            {
                System.Windows.Media.Imaging.BitmapEncoder enc = new System.Windows.Media.Imaging.BmpBitmapEncoder();
                enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(input));
                enc.Save(outmstream);
                System.Drawing.Bitmap retBitmap = new System.Drawing.Bitmap(outmstream);

                if (retBitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    System.Drawing.Imaging.ColorPalette new_pal = retBitmap.Palette;
                    for (int i = 0; i < 256; i++)
                    {
                        new_pal.Entries[i] = System.Drawing.Color.FromArgb(255, i, i, i);
                    }
                    retBitmap.Palette = new_pal;
                }

                return retBitmap;
            }
        }

        /// <summary>
        /// Convert BitmapImage to HImage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HalconDotNet.HImage Bitmapimage2HImage(System.Windows.Media.Imaging.BitmapImage input)
        {
            if (input == null)
                return new HalconDotNet.HImage();

            try
            {
                HalconDotNet.HImage himg = new HalconDotNet.HImage();
                System.Windows.Media.Imaging.WriteableBitmap Metadata = new System.Windows.Media.Imaging.WriteableBitmap(input);

                int width = input.PixelWidth;
                int height = input.PixelHeight;
                int stride = width * ((input.Format.BitsPerPixel + 7) / 8);
                byte[] imageData = new byte[height * stride];
                input.CopyPixels(imageData, stride, 0);

                IntPtr ImgPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(imageData.Length);
                System.Runtime.InteropServices.Marshal.Copy(imageData, 0, ImgPtr, imageData.Length);
                if (input.Format == System.Windows.Media.PixelFormats.Bgra32 || input.Format == System.Windows.Media.PixelFormats.Bgr32)
                {
                    himg.GenImageInterleaved(ImgPtr, "bgrx", input.PixelWidth, input.PixelHeight, -1, "byte", input.PixelWidth, input.PixelHeight, 0, 0, -1, 0);
                }
                else if (input.Format == System.Windows.Media.PixelFormats.Bgr24)
                {
                    himg.GenImageInterleaved(ImgPtr, "bgr", input.PixelWidth, input.PixelHeight, -1, "byte", input.PixelWidth, input.PixelHeight, 0, 0, -1, 0);
                }
                else if (input.Format == System.Windows.Media.PixelFormats.Rgb24)
                {
                    himg.GenImageInterleaved(ImgPtr, "rgb", input.PixelWidth, input.PixelHeight, -1, "byte", input.PixelWidth, input.PixelHeight, 0, 0, -1, 0);
                }
                else if (input.Format == System.Windows.Media.PixelFormats.Indexed8 || input.Format == System.Windows.Media.PixelFormats.Gray8)
                {
                    himg.GenImage1("byte", input.PixelWidth, input.PixelHeight, ImgPtr);
                }
                else // default: trans to color image
                {
                    System.Drawing.Bitmap Meta = ImageTypeConverter.Bitmapimage2Bitmap(input);
                    himg = ImageTypeConverter.Bitmap2HImage(Meta);
                }
                
                System.Runtime.InteropServices.Marshal.FreeHGlobal(ImgPtr);

                return himg;
            }
            catch (HalconDotNet.HalconException ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmapimage2HImage: " + ex.Message);
                return null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmapimage2HImage: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Convert Bitmap to HImage which Halcon dot net data type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HalconDotNet.HImage Bitmap2HImage(System.Drawing.Bitmap input)
        {
            if (input == null)
                return new HalconDotNet.HImage();

            try
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, input.Width, input.Height);
                
                HalconDotNet.HImage himg = new HalconDotNet.HImage();
                if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, input.PixelFormat);
                    himg.GenImageInterleaved(srcBmpData.Scan0, "bgrx", input.Width, input.Height, -1, "byte", input.Width, input.Height, 0, 0, -1, 0);
                    input.UnlockBits(srcBmpData);
                }
                else if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    himg.GenImageInterleaved(srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                    input.UnlockBits(srcBmpData);
                }
                else if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    himg.GenImage1("byte", input.Width, input.Height, srcBmpData.Scan0);
                    input.UnlockBits(srcBmpData);
                }
                else // default: trans to color image
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = null;
                    System.Drawing.Bitmap MetaBmp = new System.Drawing.Bitmap(input.Width, input.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(MetaBmp);
                    g.DrawImage(input, rect);
                    g.Dispose();
                    srcBmpData = MetaBmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    himg.GenImageInterleaved(srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                    MetaBmp.UnlockBits(srcBmpData);
                }

                
                return himg;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmap2HImage: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Convert Bitmap to BitmapImage
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static System.Windows.Media.Imaging.BitmapImage Bitmap2Bitmapimage(System.Drawing.Bitmap input)
        {
            System.Windows.Media.Imaging.BitmapImage retval =  new System.Windows.Media.Imaging.BitmapImage();
            if (input == null)
                return retval;

            IntPtr hBitmap = input.GetHbitmap();
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    input.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;

                    retval.BeginInit();
                    // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                    // Force the bitmap to load right now so we can dispose the stream.
                    retval.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                    retval.StreamSource = ms;
                    retval.EndInit();
                    retval.Freeze();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmap2Bitmapimage" + ex.Message);
            }

            return retval;
        }

        /// <summary>
        /// Copy data from one memory address, source, to another address, destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <param name="length"></param>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, EntryPoint = "CopyMemory")]
        private static extern void CopyMemory(Int64 destination, Int64 source, Int64 length);
        /// <summary>
        /// Convert HImage to Bitmap
        /// </summary>
        /// <param name="HImg"></param>
        /// <returns></returns>
        public static System.Drawing.Bitmap HImage2Bitmap(HalconDotNet.HImage HImg)
        {
            if (HImg == null)
                return null;

            try
            {
                System.Drawing.Bitmap bmpImg;

                HalconDotNet.HTuple Channels;
                Channels = HImg.CountChannels();

                if (Channels.I == 3)
                {
                    System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                    HalconDotNet.HTuple hred, hgreen, hblue, type, width, height;
                    HalconDotNet.HOperatorSet.GetImagePointer3(HImg, out hred, out hgreen, out hblue, out type, out width, out height);

                    bmpImg = new System.Drawing.Bitmap(width.I, height.I, pixelFmt);
                    System.Drawing.Imaging.BitmapData bitmapData = bmpImg.LockBits(new System.Drawing.Rectangle(0, 0, width.I, height.I), System.Drawing.Imaging.ImageLockMode.ReadWrite, pixelFmt);
                    unsafe
                    {
                        Console.WriteLine(bitmapData.Scan0);
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
                }
                else if (Channels.I == 4)
                {
                    System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
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
                            *(data + (i * 4)) = *(hb + i);
                            *(data + (i * 4) + 1) = *(hg + i);
                            *(data + (i * 4) + 2) = *(hr + i);
                            *(data + (i * 4) + 3) = 255;
                        }
                        bmpImg.UnlockBits(bitmapData);
                    }
                }
                else if (Channels.I == 1)
                {
                    System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    HalconDotNet.HTuple hpointer, type, width, height;
                    const int Alpha = 255;
                    Int64[] ptr = new Int64[2];
                    hpointer = HImg.GetImagePointer1(out type, out width, out height);

                    bmpImg = new System.Drawing.Bitmap(width.I, height.I, pixelFmt);
                    System.Drawing.Imaging.ColorPalette pal = bmpImg.Palette;
                    for (int i = 0; i < 256; i++)
                        pal.Entries[i] = System.Drawing.Color.FromArgb(Alpha, i, i, i);

                    bmpImg.Palette = pal;
                    System.Drawing.Imaging.BitmapData bitmapData = bmpImg.LockBits(new System.Drawing.Rectangle(0, 0, width.I, height.I), System.Drawing.Imaging.ImageLockMode.ReadWrite, pixelFmt);
                    int PixelsSize = System.Drawing.Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;

                    Console.WriteLine(bitmapData.Scan0);
                    ptr[0] = (Int64)bitmapData.Scan0;
                    ptr[1] = (Int64)hpointer.IP;
                    if (width % 4 == 0)
                        CopyMemory(ptr[0], ptr[1], width * height * PixelsSize);
                    else
                    {
                        ptr[1] += width;
                        CopyMemory(ptr[0], ptr[1], width * PixelsSize);
                        ptr[0] += width;
                    }
                    bmpImg.UnlockBits(bitmapData);
                }
                else
                {
                    bmpImg = null;
                }

                return bmpImg;
            }
            catch (HalconDotNet.HalconException ex)
            {
                Console.WriteLine("In ImageTypeConverter.HImage2Bitmap: " + ex.Message);
                return null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.HImage2Bitmap: " + ex.Message);
                return null;
            }
        }

        // HImage -> BitmapImage
    }
}
