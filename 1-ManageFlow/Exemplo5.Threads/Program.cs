using System;
using System.Threading;

namespace Exemplo5.Threads
{
    /* ANOTAÇÕES
     * Caso seja necessário usar dados locais e inicializar para cada thread
     * pode-se usar a classe ThreadLocal<T>. Esta classe usa delegate p/ inicializar o valor
    */

    class Program
    {
        public static ThreadLocal<int> _field =
          new ThreadLocal<int>(() =>
          {
              // Permite obter informações sobre a thread que está em execução (thread atual)
              // OBS: Isto é chamado de "Thread's execution context" (contexto de execução de thread)
              return Thread.CurrentThread.ManagedThreadId;
          });


        public static void Main(string[] args)
        {
            // Inicia thread A
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            // Inicia thread B
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();

            Console.ReadKey();
        } 
    }
}
