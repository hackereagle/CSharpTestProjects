using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharImgProcUsingIntptr
{
    unsafe class Image
    {
        public int width, height, size;
        public byte* data;
        public byte[,] data_2d;

        Image(int width, int height)
        {
            size = width * height;
            data = new byte[size];
            data_2d = new byte[height, width];
        }
        public bool CreateGrayImg(int width, int height);
        public System.Drawing.Bitmap Displayed;
    }
}
