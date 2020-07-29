using System;
using System.Diagnostics;
using System.Threading;

namespace _2TwoThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int score1 = 0;
            var thread1 = new Thread(() =>
            {
                score1 = GetScore(10);
            });
            thread1.Start();

            int score2 = 0;
            var thread2 = new Thread(() =>
            {
                score2 = GetScore(2);
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

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
