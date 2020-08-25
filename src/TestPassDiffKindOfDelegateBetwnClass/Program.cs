using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPassDiffKindOfDelegateBetwnClass
{
    // goal: pass function by class method arguments.
    //       Test different kind of delegate such as delegate, Action, Func ect.
    // reference:
    //  [C#]Delegate、Action、Func、Predicate介紹 https://dotblogs.com.tw/brianClub/2016/07/05/224004
    //  C#雜記 — 委派(Delegate)、FUNC<>、ACTION<> https://medium.com/@ad57475747/c-%E9%9B%9C%E8%A8%98-%E5%A7%94%E6%B4%BE-delegate-func-action-4b3191c7a131
    //  Pass Method as Parameter using C# https://stackoverflow.com/questions/2082615/pass-method-as-parameter-using-c-sharp

    class UserControlA
    {
        // Method1: Using Delegate
        public delegate int TestDelegate(string str);
        public TestDelegate _testDelegate;
        // Method2: Using Action
        Action<string> _testAction;
        // Method3: Using Func
        Func<string, int> _testFunc;

        public UserControlA(TestDelegate testDelegate, Action<string> testAction, Func<string, int> testFunc)
        {
            _testDelegate = testDelegate;
            _testAction = testAction;
            _testFunc = testFunc;
        }

        public void DoSomething()
        {
            Console.WriteLine("UserControlA have done some things!");
            _testDelegate("Test Method1: Using Delegate!");
            _testAction("Test Method2: Using Generic Delegate ─ Action!");
            _testFunc("Test Method3: Using Generic Delegate ─ Func!");
        }
    }

    class UserControlB
    {
        UserControlA test;
        public UserControlB()
        {
            test = new UserControlA(ForUserControlA_Called, TestAction, ForUserControlA_Called);
        }

        int ForUserControlA_Called(string str)
        {
            Console.WriteLine("In UserControlB, testing " + str);
            return 0;
        }

        void TestAction(string str)
        {
            ForUserControlA_Called(str);
        }

        public void Call_UserControlA_DoSomething()
        {
            Console.WriteLine("UserControlB call UserControlA to do some thing!");
            test.DoSomething();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserControlB yo = new UserControlB();
            yo.Call_UserControlA_DoSomething();
            Console.ReadLine();
        }
    }
}
