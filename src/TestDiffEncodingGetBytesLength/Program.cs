using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDiffEncodingGetBytesLength
{
    // string to byte array method is refering to https://dotblogs.com.tw/shunnien/2013/07/22/111936
    // NOTE from last web:
    //          1. string to byte array is using GetBytes method
    //          2. byte array to string is using GetString method
    //this project only test length of difference encode method, so do not use GetString.
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "Hello World";
            string text = "你好"; // using chinese had strong difference in this example.
            Console.WriteLine($"string length = {text.Length}");

            // test asci
            byte[] asciiBytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine($"\nLength of string encoded by ASCII is {asciiBytes.Length}");

            // test unicode
            byte[] unicodeByte = Encoding.Unicode.GetBytes(text);
            Console.WriteLine($"\nLength of string encoded by Unicode is {unicodeByte.Length}");

            // test utf8
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine($"\nLength of string encoded by UTF8 is {utf8Bytes.Length}");

            // test utf16
            byte[] utf16Bytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine($"\nLength of string encoded by UTF16 is {utf16Bytes.Length}");

            // test utf16
            byte[] utf32Bytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine($"\nLength of string encoded by UTF32 is {utf32Bytes.Length}");
            Console.ReadLine();
        }
    }
}
