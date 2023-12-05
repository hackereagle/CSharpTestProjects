namespace CommonModules
{
    public abstract class TestClassBase
    {
        public abstract void RunTest();

        protected void PrintTestTitle(string title)
        {
            System.Console.WriteLine($"\n\n========= {title} =========");
        }

        protected void Assert(bool condition, string msg)
        { 
            // get caller
            string caller;
            var trace = new System.Diagnostics.StackTrace(true);
            var frame1 = trace.GetFrame(1);
            var frame2 = trace.GetFrame(2);
            var frame1FullName = trace.GetFrame(1)!.GetMethod()!.DeclaringType!.FullName;
            var frame2FullName = frame2!.GetMethod()!.DeclaringType!.FullName;
            if (frame2FullName!.Equals(frame1FullName))
            {
                frame2FullName = "this";
            }

            caller = $"{frame2FullName}.{frame2!.GetMethod()!.Name}";

            if (condition)
            {
                WriteSuccessMsg($"{caller}: OK");
            }
            else
            { 
                WriteFailMsg($"{caller} unepected: {msg}");
            }
        }

        protected void RecoverDefaultColor()
        {
            Console.ForegroundColor = FOREGROUND_DEFAULT;
            Console.BackgroundColor = BACKGROUND_DEFAULT;
        }

        private const ConsoleColor FAIL = ConsoleColor.DarkRed;
        private const ConsoleColor SUCCESS = ConsoleColor.Green;
        private const ConsoleColor FOREGROUND_DEFAULT = ConsoleColor.Gray;
        private const ConsoleColor BACKGROUND_DEFAULT = ConsoleColor.Black;
        private void WriteFailMsg(string msg)
        {
            Console.BackgroundColor = FAIL;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(msg);
            RecoverDefaultColor();
        }

        private void WriteSuccessMsg(string msg)
        {
            Console.BackgroundColor = SUCCESS;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(msg);
            RecoverDefaultColor();
        }
    }
}