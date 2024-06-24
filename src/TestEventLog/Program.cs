using  System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using TestEventLog;
internal class Program
{
    private static bool IsRunAsAdmin()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Test EventLog");

        if (IsRunAsAdmin())
        {
            TestEventLogClass test = new TestEventLogClass();
            test.TestWriteToApplicationWithInformation();
        }
        else
        {
            Console.WriteLine("Please run this application with Administrator.");
        }

        Console.ReadKey();
    }
}