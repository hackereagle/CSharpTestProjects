using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEventPassData
{
    class UserControlA
    {
        public delegate int fEvent(int arg);
        public event fEvent trigger;

        public UserControlA()
        {
        }

        public void DoSomeThing()
        {
            Console.WriteLine("UserControlA have done some things.");
            trigger(100);
        }
    }

    class UserControlB
    {
        UserControlA test;
        public UserControlB()
        {
            test = new UserControlA();
            test.trigger += ForUserControlA_Called;
        }

        int ForUserControlA_Called(int arg)
        {
            Console.WriteLine("In UserControlB, UserControlA call this event!");
            Console.WriteLine("In UserControlB, UserControlA pass arg = {0} to UserControlB", arg);
            return 0;
        }

        public void Call_UserControlA_DoSomeThing()
        {
            Console.WriteLine("UserControlB call UserControlA to do some thing!");
            test.DoSomeThing();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserControlB yo = new UserControlB();
            yo.Call_UserControlA_DoSomeThing();
            Console.ReadLine();
        }
    }
}
