using System;
using System.Threading.Tasks;

namespace Exemplo9.Threads.Tasks
{
    /// <summary>
    /// Exemplo mostra variações das opções do método ContinueWith
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            // O agendamento desta execução será feito somente se a operação for cancelada
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Cancelada");
            }, TaskContinuationOptions.OnlyOnCanceled);

            // O agendamento desta execução será feito somente se a operação tiver falha
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Falhou!");
            }, TaskContinuationOptions.OnlyOnFaulted);

            // O agendamento desta execução será feito somente se a operação for completada
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completada");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            
            completedTask.Wait();
        }
    }
}
