using System;
using System.Collections.Generic;
using System.Linq;
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

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [System.Runtime.InteropServices.DllImport("kernel32")]
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
    }

    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine("\nFinish testing");
            Console.ReadLine();
        }
    }
}
