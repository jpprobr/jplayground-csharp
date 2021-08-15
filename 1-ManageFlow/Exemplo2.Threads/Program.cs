using System;
using System.Threading;

namespace Exemplo2.Threads
{
    class Program
    {
        public static void ThreadMethod(object objeto) // Passando um objeto como parâmetro
        {
            Console.WriteLine("ThreadProc objeto:{0}", objeto);

            for (int i = 0; i < (int)objeto; i++)  // Note que esta usando o objeto passado por parâmetro
            {
                Console.WriteLine("ThreadProc:{0}", i);
                Thread.Sleep(0);
            }
        }


        static void Main(string[] args)
        {
            // ParameterizedThreadStart pode ser usado p/ 
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5); // 5 é passado para ThreadMethod como um objeto
            t.Join();
        }      
    }
}