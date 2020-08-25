using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Testing_MVVM.BusinessLogic
{
    class TestingDoSomeThings
    {
        System.Reactive.Subjects.ISubject<string> result = new System.Reactive.Subjects.Subject<string>();

        public void Testing1(string Content)
        {
            result.OnNext(Content + " : Enter Testing1");
        }

        public IObservable<string> Result => result.AsObservable();

    }
}
