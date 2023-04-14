using System.Diagnostics;

namespace TplUnitTest
{
    public class TestsTask
    {
        [SetUp]
        public void Setup()
        {
        }

        private Task<int> SomeReturnTaskMethod(int param1)
        {
            return Task.Run<int>(async () => 
            {
                int threadId = System.Environment.CurrentManagedThreadId;
                Console.WriteLine($"[4]. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} Thread ID: {threadId}. This is method SomeReturnTaskMethod beging do something.");
                await Task.Delay(1000);
                Console.WriteLine($"[5]. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} Thread ID: {threadId}. This is method SomeReturnTaskMethod end do something.");
                return param1;
            });
        }
        [Test]
        public void TestTaskRunSync()
        {
            // refer to https://dotblogs.com.tw/JesperLai/2018/04/06/013332
            // arrange

            // action
            Stopwatch sw = new Stopwatch();
            int threadId = System.Environment.CurrentManagedThreadId;
            Console.WriteLine($"[1]. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} Thread ID:  {threadId} . Begin set Task");
            var result = this.SomeReturnTaskMethod(10);
            Console.WriteLine($"[2]. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} Thread ID:  {threadId} . End set Task");
            sw.Start();
            Console.WriteLine($"[3]. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} Thread ID:  {threadId} . End set Task");
            int res = result.Result;
            Console.WriteLine($"[6]. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} Thread ID:  {threadId} . End set Task");
            sw.Stop();

            // assert
            long elapsed = sw.ElapsedMilliseconds;
            Assert.That(elapsed, Is.EqualTo(1000).Within(100), $"Assert elapsed time, real elaped time = {elapsed}");
            Assert.That(Is.Equals(res, 10), $"Assert result: {res}");
        }
    }
}