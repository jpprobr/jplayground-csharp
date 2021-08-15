using System;
using System.Threading;

namespace Exemplo1.Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true; // Somente quando todas as foreground threads finalizarem que as de background são terminadas
            t.Start();

            Console.WriteLine("Executando Thread 1...");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Mainthread: Do some work.");
                Thread.Sleep(2);
            }

            t.Join(); // Espera até que a outra thread termine

            //Console.ReadKey();
        }


        public static void ThreadMethod()
        {
            Console.WriteLine("Executando Thread 2...");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc:{0}", i);
                Thread.Sleep(2);
            }
        }
    }
}
