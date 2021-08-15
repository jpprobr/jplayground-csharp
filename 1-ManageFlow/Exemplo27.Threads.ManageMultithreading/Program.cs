using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo27.Threads.ManageMultithreading
{
    /// <summary>
    /// Exemplo mostra caso de deadlock
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            object lockA = new object();
            object lockB = new object();

            // Cria task e thread secundária
            var up = Task.Run(() =>
            {
                // Bloqueia A e aguarda B ficar livre
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B -- (Texto 1) -- outra thread");
                    }
                }
            });

            // .Na thread principal, porém, B está bloqueada e aguardando liberação de A
            lock (lockB)
            {
                //
                lock (lockA)
                {
                    Console.WriteLine("Locked A and B -- (Texto 2)");
                }
            }

            up.Wait();

            // Em resumo: A espera B e B espera A
            // É possível evitar deadlocks no código, certificando-se que os bloqueios sejam
            // solicitados na mesma ordem.
            // Dessa forma o primeiro thread pode terminar seu trabalho, 
            // depois que o segundo thread puder continuar

            Console.WriteLine("...");
        }
    }
}
