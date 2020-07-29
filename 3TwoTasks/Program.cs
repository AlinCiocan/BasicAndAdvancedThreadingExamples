using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _3TwoTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = Task.Run(() => GetScore(10));
            var task2 = Task.Run(() => GetScore(2));

            var sum = task1.Result + task2.Result;
            Console.WriteLine("Score sums: " + sum);
            Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        static int GetScore(int n)
        {
            Thread.Sleep(1000);
            return n * 10;
        }
    }
}
