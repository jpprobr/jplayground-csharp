using System;
using System.Threading;

namespace Exemplo6.Threads.ThreadPool
{
    class Program
    {
        /* ANOTAÇÕES: 
            Como o thread pool limta o número de threads, você obtém um grau menor
            de paralelismo do que a classe Thread comum, porém o Thread Pool tem muitas vantagens
        */

        static void Main(string[] args)
        {
            /*
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            */

            Console.ReadLine();
        }
    }
}
