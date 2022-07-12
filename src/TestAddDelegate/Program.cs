using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAddDelegate
{
    class Program
    {
        delegate void delTestDelegate();
        static delTestDelegate Callback { set; get; }
        static event delTestDelegate Event;

        static void TestAFunc()
        {
            Console.WriteLine($"TestAFunc be called! Thread ID : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }

        static void TestBFunc()
        {
            Console.WriteLine($"TestBFunc be called! Thread ID : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main ThreadID: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            Callback += TestAFunc;
            Callback += TestBFunc;
            Event += TestAFunc;
            Event += TestBFunc;

            Console.WriteLine("\nTest delegate");
            Callback();

            Console.WriteLine("\nRemove TestBFunc and call Callback");
            Callback -= TestBFunc;
            Callback();

            Console.WriteLine("\nTest event");
            Event();

            Console.ReadLine();
        }
        // Result:
        // Main ThreadID: 1
        //
        // Test delegate
        // TestAFunc be called! Thread ID : 1
        // TestBFunc be called! Thread ID : 1
        //
        // Remove TestBFunc and call Callback
        // TestAFunc be called! Thread ID : 1
        //
        // Test event
        // TestAFunc be called! Thread ID : 1
        // TestBFunc be called! Thread ID : 1

        // Conclusion:
        // delegate can be added and removed.
        // event and delegate are sync.
    }
}
