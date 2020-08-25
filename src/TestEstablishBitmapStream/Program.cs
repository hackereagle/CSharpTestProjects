using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEstablishBitmapStream
{
    class Program
    {
        // reference: Parsing Windows Bitmap header information https://codereview.stackexchange.com/questions/175685/parsing-windows-bitmap-header-information
        // reference: WPF 基础（十三）Bitmap、BitmapImage、Image的区别。BitmapImage、Bitmap、byte[]之间的相互转化。Bitmap存储图片到本地。
        //            https://blog.csdn.net/xpj8888/article/details/88351176
        // reference: 點陣圖（Bitmap）檔案格式 https://crazycat1130.pixnet.net/blog/post/1345538-%E9%BB%9E%E9%99%A3%E5%9C%96%EF%BC%88bitmap%EF%BC%89%E6%AA%94%E6%A1%88%E6%A0%BC%E5%BC%8F
        static void Main(string[] args)
        {
            System.Drawing.Bitmap test = new System.Drawing.Bitmap("D:\\Document\\project\\03.Seal檢測\\SEAL樣品圖\\Innolux_Fab5_IrregularSeal_6509_20190729\\往左拉可檢出.bmp");
            System.Console.WriteLine("read bitmap size = {0} x {1} = {2}", test.Width, test.Height, test.Width * test.Height);
            ImageVisualizer.ImageVisualizer.TestShowVisualizer(test);

            // trans to bitmap data byte array 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            test.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] data = ms.GetBuffer();
            System.Console.WriteLine("byte array size = {0}", data.Length);
            System.Console.WriteLine("nDifferent between byte array and bitmap size = {0}", data.Length - (test.Width * test.Height));
            ms.Close();

            //trans bitmap data byte array to System.Drawing.Bitmap
            byte[] toBitmap = data;
            System.IO.MemoryStream ms_toBitmap = new System.IO.MemoryStream(toBitmap);
            //System.Drawing.Bitmap result = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms_toBitmap);
            System.Drawing.Bitmap result = new System.Drawing.Bitmap(ms_toBitmap);
            ImageVisualizer.ImageVisualizer.TestShowVisualizer(result);
            ms_toBitmap.Close(); // 一定要等bitmap用完才可以關，不然會有問題

            System.Console.ReadLine();
        }
    }
}
