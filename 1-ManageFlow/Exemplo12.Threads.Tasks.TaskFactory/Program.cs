using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo12.Threads.Tasks.WaitAll
{
    /// <summary>
    /// Exemplo mostra o uso do WaitAll p/ aguardar a finalização de múltiplas tarefas
    /// antes de continuar a execução
    /// Note que: As tarefas são executadas simultaneamente e leva 1000 ms e não 3000 ms 
    /// (que seria a soma do tempo das 3 tarefas)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            // Execução da tarefa 1
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            // Execução da tarefa 2
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            // Execução da tarefa 3
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);
        }
    }
}
