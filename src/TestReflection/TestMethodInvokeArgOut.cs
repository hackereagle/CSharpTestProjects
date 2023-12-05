using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommonModules;

namespace TestReflection
{
    internal class TestMethodInvokeArgOut : TestClassBase
    {
        private class ReferenceType
        {
            public ReferenceType()
            {
                Value = 0;
            }

            public ReferenceType(int val)
            {
                Value = val;
            }
            public int Value { get; set; }
        }

        private class InvokedClass
        { 
            private void MethodWithOutArg(int arg1, out int arg2, out ReferenceType refType, ref int arg3, ref ReferenceType refType2)
            {
                arg2 = arg1 * 2;
                refType = new ReferenceType();
                refType.Value = arg1 * 3;

                arg3 = arg1 * 4;
                refType2.Value = refType2.Value * 5;
            }
        }

        private class InvokerClass
        {
            private InvokedClass _invokedClass;
            public InvokerClass(InvokedClass invokedClass)
            {
                _invokedClass = invokedClass;
            }

            public void CallMethod(string methodName, object[] parameters)
            {
                Type waferAlignmentService = _invokedClass.GetType();
                MethodInfo method = waferAlignmentService.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)!;
                object? result = method.Invoke(_invokedClass, parameters);
            }
        }

        public override void RunTest()
        {
            PrintTestTitle("Test MethodInvoke Have Out Argument");

            // ARRANGE
            InvokedClass invokedClass = new InvokedClass();
            InvokerClass invoker = new InvokerClass(invokedClass);

            // ACT
            int receiver = 0;
            ReferenceType refType = null;
            int testRefValue = 3;
            ReferenceType testRef = new ReferenceType(10);
            object[] parameters = new object[] { 3, receiver, refType, testRefValue, testRef };
            invoker.CallMethod("MethodWithOutArg", parameters);
            // Due to the variable is valuable type, so .NET will box it to a reference type object.
            // We need to unbox it to over write the original variable.
            receiver = (int)parameters[1];
            refType = (ReferenceType)parameters[2];
            testRefValue = (int)parameters[3];
            // Only reference type variable can be over written.


            // ASSERT
            Assert(receiver == 6, "receiver == 6");
            Assert(refType != null, "receiver != null");
            Assert(refType!.Value == 9, "receiver == 9");
            Assert(testRefValue == 12, "testRefValue == 12");
            // Only reference type variable can be over written.
            Assert(testRef.Value == 50, "testRef.Value == 50");
        }
    }
}
