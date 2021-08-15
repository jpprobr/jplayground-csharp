using System;
using System.Threading.Tasks;

namespace Exemplo10.Threads.Tasks
{
    /// <summary>
    /// Exemplo mostra Task Pai com várias Tasks filhas
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                // Tarefa filha 1
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();

                // Tarefa filha 2
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();

                // Tarefa filha 3
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            // Tarefa final executa somente depois que a tarefa pai está finalizada
            // e tarefa pai só finaliza quando todas as suas filhas estiverem finalizadas
            var finalTask = parent.ContinueWith(
              parentTask => {
                  foreach (int i in parentTask.Result)
                      Console.WriteLine(i);
              });

            finalTask.Wait();
        }
    }
}
