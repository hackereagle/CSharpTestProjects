using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDisposedObjEvent
{
    public delegate void delSomeEvent();
    public class Observated : IDisposable
    {
        public Observated()
        { }

        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public event delSomeEvent SomeEvent;
        public void DoSomething()
        {
            if (SomeEvent != null)
                SomeEvent.Invoke();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            { 
            }

            _disposed = true;
        }
    }


    public class Test : IDisposable
    {
        public Test()
        { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SomeMethod()
        {
            Console.WriteLine("yo");
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            { 
            }

            _disposed = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Observated a = new Observated();
            Test b = new Test();

            a.SomeEvent += b.SomeMethod;

            a.DoSomething();
            b.Dispose();
            a.DoSomething();

            Console.ReadLine();
        }
    }
}
