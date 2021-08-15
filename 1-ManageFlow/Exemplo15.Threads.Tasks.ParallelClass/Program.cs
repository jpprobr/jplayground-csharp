using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Exemplo15.Threads.Tasks.ParallelClass
{
    /// <summary>
    /// Exemplo mostra como cancelar o loop usando o objeto ParallelLoopState
    /// Há 2 opções para fazer o cancelamento: Break ou Stop
    /// Break: Garante que todas as iterações que rodam atualmente serão finalizadas
    /// Stop:  Apenas termina a execução de tudo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int cont = 0;
            var contTeste1 = new List<int>();

            // Teste com Break
            ParallelLoopResult result = Parallel.
                For(0, 100, (int i, ParallelLoopState loopState) =>
                {
                    cont++;
                    contTeste1.Add(cont);
                    Console.Write("{0} [cont={1}], ", i, cont);
                    if (i == 50)
                    {
                        // Note que o "cont" está fora de ordem mas só imprime 50
                        Console.WriteLine("\n*****[Breaking loop]*****\n");

                        // Aborta execução de iterações além da iteração atual
                        loopState.Break();
                    }
                    return;
                });

            Console.WriteLine();
            Console.WriteLine("result.LowestBreakIteration: {0}", result.LowestBreakIteration);
            Console.WriteLine("ContTeste1 é: {0}", contTeste1.Max());
            Console.WriteLine();

            Console.WriteLine("--------------------");

            cont = 0;
            var contTeste2 = new List<int>();

            // Teste com Stop
            ParallelLoopResult result2 = Parallel.
                For(0, 100, (int i, ParallelLoopState loopState) =>
                {
                    cont++;
                    contTeste2.Add(cont);
                    Console.Write("{0} [cont={1}], ", i, cont);

                    if (i == 50)
                    {
                        Console.WriteLine("\n*****[Stopping loop]*****\n");

                        // Aborta execução de iterações além da iteração atual
                        loopState.Stop();
                    }

                    return;
                });

            Console.WriteLine();
            Console.WriteLine("result2.LowestBreakIteration: {0}", result2.LowestBreakIteration);
            Console.WriteLine("contTeste2 é: {0}", contTeste2.Max());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();

            /*
             Ao interromper o loop paralelo, a variável resultante tem um valor IsCompleted false 
             e um LowestBreakIteration de 500. 
             Quando você usa o método Stop, o LowestBreakIteration é nulo.
            */

            /*
             NOTE QUE: O valor do cont e o i não coincidem com o valor de controle do loop (LowestBreakIteration)
            */
        }
    }
}
