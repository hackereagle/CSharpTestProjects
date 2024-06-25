using  System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using TestEventLog;

enum EventLogSample : int
{ 
    Unknown = -1,
    Diagnostic = 0,
    MicrosoftExtension = 1,
    End,
}

internal class Program
{
    private static bool IsRunAsAdmin()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private static EventLogSample ConvertUserChooseToId(string choose)
    { 
        EventLogSample id = EventLogSample.Unknown;
        try
        {
            int num = 0;
            if (int.TryParse(choose, out num) && 
                num < (int)EventLogSample.End)
            {
                id = (EventLogSample)num;
            }
            else
            { 
                Console.WriteLine("Invalid choose!");
            }
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message);
        }

        return id;
    }

    private static void RunExampleWithChooseID(EventLogSample id)
    {
        switch (id)
        { 
            case EventLogSample.Diagnostic:
                if (IsRunAsAdmin())
                {
                    // System.Diagnostics.EventLog need to run as Administrator
                    TestEventLogClass test = new TestEventLogClass();
                    test.TestWriteToApplicationWithInformation();
                }
                else
                {
                    Console.WriteLine("Please run this application with Administrator.");
                }
                break;
            case EventLogSample.MicrosoftExtension:
                TestMicrosoftExtensionEventLog testMicrosoftExtension = new TestMicrosoftExtensionEventLog();
                testMicrosoftExtension.TestWriteToApplicationWithInformation();
                testMicrosoftExtension.TestWriteToCustomLogWithInformation();
                break;
            default:
                Console.WriteLine("Unknown choose!");
                break;
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Test EventLog");

        EventLogSample id = EventLogSample.Unknown;
        if (args.Length < 2)
        {
            string? choose = null;
            while (choose == null)
            {
                Console.WriteLine("Please choose example:");
                Console.WriteLine("0: System.Diagnostics.EventLog");
                Console.WriteLine("1: Microsoft.Extensions.Logging.EventLog");
                choose = Console.ReadLine();
            }

            id = ConvertUserChooseToId(choose);
        }
        else
        { 
            id = ConvertUserChooseToId(args[1]);
        }

        RunExampleWithChooseID(id);

        Console.ReadKey();
    }
}