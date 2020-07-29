using System;
using System.Threading;

namespace IsCompleteExample
{
    class Program
    {
        private static bool _isDestroyed = false;
        private static object myLock = new object();

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main - Mitica Macelarul";

            var thread = new Thread(AttackAntenna5G);
            thread.Name = "Secondary - Simion cu o secure";
            thread.Start();

            AttackAntenna5G();
        }

        static void AttackAntenna5G()
        {
            lock (myLock)
            {
                if (!_isDestroyed)
                {
                    Console.WriteLine("Antenna 5G was destroyed by" + Thread.CurrentThread.Name);
                    _isDestroyed = true;
                }
            }
        }
    }
}
