using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThreadPoolTimeoutEvent
{
    class Program
    {
        static System.Threading.ManualResetEvent eventX = new System.Threading.ManualResetEvent(false);
        static int mAmountOfItem = -1;
        static object mMutex = new object();

        static void ExecuteAlgorithm(object data)
        {
            object[] package;
            if (data is object[])
                package = (object[])data;
            else
                return;

            AlgBase algo = (AlgBase)package[0];
            int test = (int)package[1];

            algo.Inspect();

            lock (mMutex)
            {
                mAmountOfItem--;
                if (mAmountOfItem == -1)
                    eventX.Set();
            }
        }

        static void Main(string[] args)
        {
            // setting threadpool
            //System.Threading.ThreadPool.SetMinThreads(1, 1);
            //System.Threading.ThreadPool.SetMaxThreads(4, 4);

            List<AlgBase> algorithms = new List<AlgBase>();
            algorithms.Add(new Algorithm1("test1"));
            algorithms.Add(new Algorithm2("test2"));
            algorithms.Add(new Algorithm3("test3"));
            algorithms.Add(new Algorithm1("test4"));
            algorithms.Add(new Algorithm2("test5"));
            algorithms.Add(new Algorithm3("test6"));
            algorithms.Add(new Algorithm1("test7"));
            algorithms.Add(new Algorithm2("test8"));

            eventX.Reset();
            System.Threading.WaitCallback workUnit = new System.Threading.WaitCallback(ExecuteAlgorithm);
            foreach (AlgBase alg in algorithms)
            {
                lock (mMutex)
                {
                    mAmountOfItem++;
                }
                object[] param = new object[2] { alg, 0};
                System.Threading.ThreadPool.QueueUserWorkItem(workUnit, param);
            }

            if (eventX.WaitOne(7000, false) == false)
            {
                Console.WriteLine($"{System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}: Have one timeout!");
            }
            else
            {
                Console.WriteLine("all back");
            }

            eventX.Reset();
            Console.ReadLine();
        }
    }
}
