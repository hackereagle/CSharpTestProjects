using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReflection
{
    internal class TestInvokeGetter : CommonModules.TestClassBase
    {
        public TestInvokeGetter()
        {
        }

        private class TestClass
        {
            private int _testField = 0;
            public int TestProperty 
            { 
                get => _testField; 
                set => _testField = value; 
            }
        }

        public override void RunTest()
        {
            PrintTestTitle("Test Invoke Property Getter");

            TestClass testClass = new TestClass();
            testClass.TestProperty = 100;
            var targetProp = testClass.GetType().GetProperties().Where(x => x.Name == "TestProperty");
            
            Console.WriteLine($"{targetProp.First().Name} = {targetProp.First().GetValue(testClass)}");
        }
    }
}
