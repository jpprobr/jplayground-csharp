using System;
using System.Linq;

namespace Exemplo19.Threads.PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Processamento paralelo não garante ordem específica
            var numeros1 = Enumerable.Range(0, 10);
            var resultUnordered = numeros1.AsParallel()
                                .Where(i => i % 2 == 0)
                                .ToArray();

            Console.WriteLine("resultUnordered: ");
            foreach (int i in resultUnordered)
                Console.WriteLine(i);


            // Para garantir que os resultados esteja ordenados, podemos adicionar o operador AsOrdered
            // Com isso a query ainda é processada em paralelo, mas os resultados são 
            // armazenados e classificados
            var numeros2 = Enumerable.Range(0, 10);
            var resultOrdered = numeros2.AsParallel().AsOrdered()
                                        .Where(i => i % 2 == 0)
                                        .ToArray();

            Console.WriteLine("resultOrdered: ");
            foreach (int i in resultOrdered)
                Console.WriteLine(i);


            // Caso seja necessário que algumas partes possam ser processadas sequencialmente
            // é possível usar o AsSequential p/ impedir que query seja processada em paralelo
            // O AsSequential garante que o método Take não bagunce a ordem
            var numeros3 = Enumerable.Range(0, 20);
            var resultUsingAsSequential = numeros3.AsParallel().AsOrdered()
                                                 .Where(i => i % 2 == 0)
                                                 .AsSequential();

            Console.WriteLine("resultUsingAsSequential: ");
            foreach (int i in resultUsingAsSequential.Take(5))
                Console.WriteLine(i);            
        }
    }
}
