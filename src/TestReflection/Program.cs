using CommonModules;
using TestReflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("All System.Reflection testing are here");

        TestClassBase testMethodInvokeArgOut = new TestMethodInvokeArgOut();
        testMethodInvokeArgOut.RunTest();

        Console.ReadLine();
    }
}