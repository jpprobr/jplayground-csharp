using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo14.Threads.Tasks.ParallelClass
{
    /// <summary>
    /// Exemplo mostra uso do For ou ForEach da classe Parallel 
    /// que permite o uso de loops paralelos que em tarefas maiores ou trabalhos não sequenciais 
    /// podem ajudar na melhoria de desempenho
    /// OBS: Para saber se mais ajuda ou atrapalha o ideal é entender bem a situação e comparar os resultados
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Execua loop do tipo FOR de forma paralela
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("Iniciando processamento do Parallel.For - indice: {0}", i);
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);
            
            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine("Iniciando processamento do Parallel.ForEach - indice: {0}", i);
                Thread.Sleep(1000);
            });
        }
    }
}
