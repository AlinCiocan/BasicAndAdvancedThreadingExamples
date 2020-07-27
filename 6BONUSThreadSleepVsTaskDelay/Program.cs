using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _6BONUSThreadSleepVsTaskDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();


            Task.Run(() =>
            {
                Task.Delay(2000);
         
                // Question, what will be displayed here??
                Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds);
            });

            Thread.Sleep(1000);
        }
    }
}
