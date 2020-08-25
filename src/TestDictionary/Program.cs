using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> test = new Dictionary<string, int[]>();
            test.Add("Red", new int[3] { 255, 0, 0});
            test.Add("Blue", new int[3] { 0, 0, 255});
            test.Add("Green", new int[3] { 0, 255, 0});

            Console.WriteLine($"red {(test["Red"])[0]}");

            HalconDotNet.HObject[] tttttt = new HalconDotNet.HObject[3];
            for (int i = 0; i < 3; i++) {
                //tttttt[i] = new HalconDotNet.HObject();
                HalconDotNet.HOperatorSet.GenEmptyObj(out tttttt[i]);
            }
            Console.ReadLine();
        }
    }
}
