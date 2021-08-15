using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo23.Threads.ConcurrentCollections
{
    /// <summary>
    /// Exemplos com ConcurrentBag
    /// Ele permite duplicatas e não possui uma ordem específica
    /// Métodos importantes são: Add, TryTake e TryPeek
    /// Também implementa IEnurable<T> thread-safe
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // EXEMPLO 1
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            int result;

            // Não é muito útil em ambiente multithread
            // Pode ser que outro thread remova o item antes que você possa acessá-lo
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);

            Console.WriteLine();
            Console.WriteLine();

            // EXEMPLO 2
            // Exste segundo exemplo só exibe 42 porque o outro valor é adicionado 
            // após o início da iteração sobre o Bag
            ConcurrentBag<int> bag2 = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag2.Add(42);
                Thread.Sleep(1000);
                bag2.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag2)
                    Console.WriteLine(i);

            }).Wait();

        }
    }
}
