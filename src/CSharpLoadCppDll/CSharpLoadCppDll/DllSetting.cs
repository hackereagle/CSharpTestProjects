using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using TestCSUsingCppDll;

namespace CSharpLoadCppDll
{

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ImgInfomation
    {
        public int width;
        public int height;
        public int channels;
        public int step;
        public byte* src;
    }

    unsafe class DllSetting
    {
        [DllImport("ManagementDll.dll", EntryPoint = "Convert2Gray", CallingConvention = CallingConvention.Cdecl)]
        public extern static ImgInfomation Convert2Gray(ImgInfomation inputImg);

    }
}
