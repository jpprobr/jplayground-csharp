using System;
using System.Threading.Tasks;

namespace Exemplo7.Threads.Tasks
{
    /// <summary>
    /// Exemplo que cria nova TASK e imediatamente a inicia
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Método Run enfileira trabalho específico p/ executar em um Thread Pool...
            // ...e retorna uma Task que representa o trabalho
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write("*");
                }
            });

            // Equivalente ao método Join em uma Thread
            // Aguarda até que a tarefa seja concluída antes de sair do aplicativo
            t.Wait();

            Console.WriteLine();
        }
    }
}
