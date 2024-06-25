using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace TestEventLog
{
    internal class TestMicrosoftExtensionEventLog
    {
        public TestMicrosoftExtensionEventLog()
        { 
            Console.WriteLine("\n===== Test Microsoft.Extensions.Logging.EventLog! It don\'t need to run as Administrator! =====");
        }

        public void TestWriteToApplicationWithInformation()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddEventLog(new EventLogSettings()
                {
                    SourceName = Assembly.GetExecutingAssembly().GetName().Name,
                    LogName = "Application",
                });
            });

            var logger = loggerFactory.CreateLogger<TestMicrosoftExtensionEventLog>();
            logger.LogInformation("test with Microsoft.Extensions.Logging.EventLog");
            Console.WriteLine("Run success! Please check windows Event Log.");
        }
    }
}
