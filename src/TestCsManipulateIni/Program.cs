using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestCsManipulateIni
{
    class ManipulateIni
    {
        private string mIniPath;
        public ManipulateIni(string iniPath)
        {
            mIniPath = iniPath;
            // must create a empty ini file if no ini file in first read.
            if (!System.IO.File.Exists(mIniPath))
            {
                System.IO.FileStream file = System.IO.File.Create(mIniPath);
                file.Close();
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32", EntryPoint = "WritePrivateProfileString", SetLastError = true)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [System.Runtime.InteropServices.DllImport("kernel32", EntryPoint = "GetPrivateProfileString", SetLastError = true)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public void WriteValue(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, mIniPath);
        }

        public string GetValue(string section, string key)
        {
            StringBuilder result = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", result, 255, mIniPath);
            return result.ToString();
        }

        [System.Runtime.InteropServices.DllImport("kernel32", EntryPoint = "GetPrivateProfileSection", SetLastError = true)]
        private static extern long GetPrivateProfileSection(string section, IntPtr retVal, uint size, string filePath);
        private string[] GetSection(string section, string path)
        {
            uint MAX_BUFFER = 32767;
            System.IntPtr pReturnedString = System.Runtime.InteropServices.Marshal.AllocCoTaskMem((int)MAX_BUFFER);
            long bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, mIniPath);
            return IntPtrToStringArray(pReturnedString, bytesReturned);
        }
        private string[] IntPtrToStringArray(IntPtr pReturnedString, long bytesReturned)
        {
            if (bytesReturned == 0)
            {
                Marshal.FreeCoTaskMem(pReturnedString);
                return null;
            }

            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);
            return local.Substring(0, local.Length - 1).Split('\0');
        }
        public int GetAmountOfKeyInSection(string section)
        {
            string[] keysInSection = GetSection(section, mIniPath);
            // if no section, GetSection would return null
            if (keysInSection == null)
                return 0;
            else
                return keysInSection.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // test basic ini manipulating.
            ManipulateIni test = new ManipulateIni(AppDomain.CurrentDomain.BaseDirectory + "test.ini");
            test.WriteValue("sss", "aaa", "1");

            string result = test.GetValue("sss", "aaa");
            Console.WriteLine("Reading key aaa of section sss = {0}", result);

            // test read complete empty key
            result = test.GetValue("sss", "bbb");
            Console.WriteLine("Reading key bbb of section sss = {0}", result);
            if (result != "0" || result != "1")
            {
                Console.WriteLine("result is null");
            }

            // test how to count amount of key in specific section.
            int num = test.GetAmountOfKeyInSection("sss");
            Console.WriteLine("amount of section sss = {0}", num);

            Console.WriteLine("\nFinish testing");
            Console.ReadLine();
        }
    }
}
