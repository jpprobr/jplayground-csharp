using System;
using System.Linq;

namespace Exemplo18.Threads.PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100000000);

            // O Runtime determinar se faz sentido transformar a query em paralela
            // Ao fazer isso ele gera objetos TASK e começa a executá-los
            var parallelResult = numbers.AsParallel()
                                        .Where(i => i % 2 == 0)
                                        .ToArray();

            // Para forçar PLINQ em uma query paralela, pode ser usado o método WithExecutionMode 
            // e especificar que ele deveria sempre executar query paralelas
            var parallelResult2 = numbers.AsParallel()
                                         .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                         .Where(i => i % 2 == 0)
                                         .ToArray();

            // Para limitar a qtde/grau de paralelistmo que é usado pode ser usado o método WithDegreeOfParallelism
            var parallelResult3 = numbers.AsParallel()
                                         .WithDegreeOfParallelism(2) // Número de processadores que quer usar
                                         .Where(i => i % 2 == 0)     // Normalmente PLINQ usa todos os processadores (até 64)
                                         .ToArray();           
        }
    }
}
