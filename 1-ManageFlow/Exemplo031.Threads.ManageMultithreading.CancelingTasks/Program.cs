using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo031.Threads.ManageMultithreading.CancelingTasks
{
    /// <summary>
    /// Exemplo com CancellationToken que ajuda a cancelar tasks
    /// considerando que pode haver tasks de longa duração
    /// Você passa um CancellationToken para a Task, o qual irá monitorar
    /// periodicamente o token para ver se o cancelamento é solicitado
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // CancellationTokenSource é usado p/ sinalizar que
            // a Task deve ser cancelada
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            // A operação será encerrada quando o cancelamento for solicitado
            // Os usuários externos da tarefa não verão nada diferente,
            // porque a tarefa terá apenas um estado RanTocompletion
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                // Se você deseja sinalizar para usuários externos que sua tarefa
                // foi cancelada, você pode fazer isso lançando uma 
                // OperationCanceledException (p/ testar descomente linha se 
                // token.ThrowIfCancellationRequested(); // Note que uma Exception é lançada

            }, token);

            try
            {
                // ao pressionar ENTER liberamos a app p/ executar o método Cancel (abaixo)
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();
                
                cancellationTokenSource.Cancel();
                
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }
    }
}
