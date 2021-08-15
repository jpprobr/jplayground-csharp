using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo17.Threads.Tasks.SleepAsync
{
    /// <summary>
    /// Exemplo mostra abordagem comparando 2 métodos com operações assíncronas
    /// Escalabilidade VS Responsividade
    /// O segundo método fornece escalabilidade
    /// </summary>
    class Program
    {
        /// <summary>
        /// Usa uma thread do Thread Pool enquanto está dormindo
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        /// <summary>
        /// Método não ocupa thread enquanto aguarda a execução de um Timer
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);

            return tcs.Task;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
