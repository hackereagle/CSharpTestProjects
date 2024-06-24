﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Diagnostics;
using System.Reflection;

namespace TestEventLog
{
    internal class TestEventLogClass
    {
        public void TestWriteToApplicationWithInformation()
        { 
            EventLog eventLog = new EventLog("Application");
            eventLog.Source = Assembly.GetExecutingAssembly().GetName().Name;
            eventLog.WriteEntry("test", EventLogEntryType.Information);
            Console.WriteLine("Run success! Please check windows Event Log.");
        }
    }
}
