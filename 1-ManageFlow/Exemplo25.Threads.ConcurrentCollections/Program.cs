using System;
using System.Collections.Concurrent;

namespace Exemplo25.Threads.ConcurrentCollections
{
    /// <summary>
    /// Exemplo de Dicionário com concorrência - Coleção ConcurrentDictionary
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new ConcurrentDictionary<string, int>();
            
            // Tenta adicionar o item (com chave e valor)
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            // Tenta atualizar valor caso exista um item com a chave
            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            // É possível fazer algumas operações atomicamente
            // Operações atomicas: Significa que será iniciada e finalizada como uma única etapa,
            // sem que outros encadeamentos interfiram

            dict["k1"] = 42; // Overwrite unconditionally
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3); // Caso a chave exista retorna seu valor, caso não adiciona o item e retorna o valor adicionado
        }
    }
}
