using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThreadPoolTimeoutEvent
{
    class Algorithm2 : AlgBase
    {
        public Algorithm2(string name) : base(name)
        { }

        protected override bool GeneratorInspectMethod()
        {
            Console.WriteLine($"{System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}: ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}, run Algorithm2, name:{mName}");
            System.Threading.Thread.Sleep(4000);
            //Task.Delay(4000);
            Console.WriteLine($"{System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}: ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}, name:{mName} finish!");
            return true;
        }

    }
}
