using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCalculateImgInfoByParall
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Drawing.Bitmap srcImg = new System.Drawing.Bitmap(@"D:\Document\project\PMISH_Tech\02.Image_Processing_Tools\lena_gray.bmp");
            JCSEM.ImgProcToolsGui.BusinessLogic.CalculateGetImageInformation imgInfom = new JCSEM.ImgProcToolsGui.BusinessLogic.CalculateGetImageInformation(srcImg);
            //JCSEM.ImgProcToolsGui.BusinessLogic.ImgInfom infom = imgInfom.getImgInfom();
            Console.ReadLine();
        }
    }
}
