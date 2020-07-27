using System;
using System.Diagnostics;
using System.Threading;

namespace _3TwoTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var score1 = GetScore(10);
            var score2 = GetScore(2);

            var sum = score1 + score2;
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
