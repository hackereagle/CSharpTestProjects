using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTimeout
{
    class Program
    {
        private static async Task<bool> ExecuteAlgorithm(AlgBase algorithm, int index)
        {
            return await Task.Run(() =>
            {
                bool ret = false;
                ret = algorithm.Inspect();
                lock (mResult)
                {
                    mResult[index] = ret;
                }

                return ret;
            });
        }

        // using this is going to occur a problem:
        // If some Task timeout, this method is no work until all Task finish.
        // So don't get result via Task.Result.
        static void GetResult(List<Task<bool>> tasks)
        {
            Console.WriteLine("\n\nGetResult:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Result}");
            }
        }

        static void GetResult(bool[] result)
        {
            Console.WriteLine("\n\nGetResult:");
            foreach (var r in result)
            {
                Console.WriteLine($"{r.ToString()}");
            }
        }

        static bool[] mResult;
        static void Main(string[] args)
        {
            List<AlgBase> algorithms = new List<AlgBase>();
            algorithms.Add(new Algorithm1("test1"));
            algorithms.Add(new Algorithm2("test2"));
            algorithms.Add(new Algorithm3("test3"));
            algorithms.Add(new Algorithm1("test4"));
            algorithms.Add(new Algorithm2("test5"));
            algorithms.Add(new Algorithm3("test6"));
            algorithms.Add(new Algorithm1("test7"));
            algorithms.Add(new Algorithm2("test8"));

            var tasks = new List<Task<bool>>();
            mResult = new bool[algorithms.Count];

            int i = 0;
            foreach (var alg in algorithms)
            {
                tasks.Add(ExecuteAlgorithm(alg, i));
                i++;
            }

            if (Task.WaitAll(tasks.ToArray(), 7000))
                Console.WriteLine("All back!");
            else
                Console.WriteLine("Have one timeout!");

            //GetResult(tasks);
            GetResult(mResult);

            Console.ReadLine();
        }
    }
}
