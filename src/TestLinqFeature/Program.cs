using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinqFeature
{
    class Program
    {
        static void TestWhereNotFoundAny()
        {
            try
            {
                int[] score = new int[5] { 40, 50, 60, 89, 93 };

                int aim = score.Where(x => x < 40).First(); // ERROR: 序列未包含項目
                Console.WriteLine($"result = {aim}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"In TestWhereNotFoundAny: {ex.Message}");
            }            
        }
        
        static void Main(string[] args)
        {
            TestWhereNotFoundAny();

            Console.ReadLine();
        }
    }
}
