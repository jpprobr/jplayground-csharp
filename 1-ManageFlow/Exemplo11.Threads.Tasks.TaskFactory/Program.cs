using System;
using System.Threading.Tasks;

namespace Exemplo11.Threads.Tasks
{
    /// <summary>
    /// Exemplo mostra caso similar ao do exemplo 10, mas usando TaskFactory
    /// Um TaskFactory é criado com uma determinada configuração 
    /// e pode ser usado para criar tarefas com essa configuração 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task<int[]> parent = Task.Run(() =>
            {
                var results = new int[3];

                // Note que o parametro do tipo Enum (TaskCreationOptions) foi passado apenas uma vez
                // e no exemplo anterior se repetia
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                   TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                return results;
            });

            var finalTask = parent.ContinueWith(
               parentTask =>
               {
                   foreach (int i in parentTask.Result)
                       Console.WriteLine(i);
               });
            
            finalTask.Wait();
        }
    }
}
