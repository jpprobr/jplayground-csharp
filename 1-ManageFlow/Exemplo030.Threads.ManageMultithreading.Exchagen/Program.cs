using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo030.Threads.ManageMultithreading.Exchange
{
    class Program
    {
        static int value = 1;

        static void Main(string[] args)
        {
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output
                    Thread.Sleep(1000);
                    value = 2;
                }

                Interlocked.CompareExchange(ref value, 2, 1);
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine(value); // Displays 2
        }
    }
}
