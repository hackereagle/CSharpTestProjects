using CommonModules;
using TestReflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("All System.Reflection testing are here");

        //TestClassBase testMethodInvokeArgOut = new TestMethodInvokeArgOut();
        //testMethodInvokeArgOut.RunTest();

        TestClassBase testInvokeGetter = new TestInvokeGetter();
        testInvokeGetter.RunTest();

        Console.ReadLine();
    }
}