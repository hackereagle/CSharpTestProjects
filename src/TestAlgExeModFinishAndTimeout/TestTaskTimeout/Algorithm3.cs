using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTimeout
{
    class Algorithm3 : AlgBase
    {
        public Algorithm3(string name) : base(name)
        { }

        protected override bool GeneratorInspectMethod()
        {
            Console.WriteLine($"{System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}: ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}, run Algorithm3, name:{mName}");
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine($"{System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}: ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}, name:{mName} finish!");
            return true;
        }
    }
}
