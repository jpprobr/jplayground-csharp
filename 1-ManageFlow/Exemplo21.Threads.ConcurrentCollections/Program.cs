using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Exemplo21.Threads.ConcurrentCollections
{
    /// <summary>
    /// Exemplo mostra uso de coleções concorrentes (p/ ambientes de paralelismo)
    /// Essas coleções são thread-safe 
    /// (preparadas p/ acesso simultâneo e sincronização em cenários multithreading)
    /// </summary>
    class Program
    {
        /* As classes de coleções especiais p/ tratar dados em paralelo são:
            ■ BlockingCollection<T>
            ■ ConcurrentBag<T>
            ■ ConcurrentDictionary<TKey,T>
            ■ ConcurrentQueue<T>
            ■ ConcurrentStack<T>
        */

        static void Main(string[] args)
        {
            // BlockingCollection é thread-safe p/ adicionar ou remover dados
            // A remoção de um item da coleção pode ser bloqueada até que os dados fiquem disponíveis
            // A adição de dados é rápida, mas você pode definir um limite superior máximo. 
            // Se esse limite for atingido, a adição de um item bloqueará a thread de chamada até que haja espaço.
            // BlockingCollection é um wrapper para outros tipos de coleção. 
            // Por default usa a ConcurrentQueue
            BlockingCollection<string> colecao = new BlockingCollection<string>();
            
            // Task escuta novos itens sendo adicionados a coleção
            // e bloqueia se não houver itens disponíveis
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    // Remove item da coleção
                    var itemRemovido = colecao.Take();
                    Console.WriteLine("colecao: {0}", itemRemovido);
                }
            });

            // Task adiciona itens a coleção
            Task write = Task.Run(() =>
            {
                while (true)
                {
                    // Obtem valor informado pelo usuário
                    string s = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(s)) 
                        break;

                    colecao.Add(s);
                }
            });

            // Exemplo com uso do método GetConsumingEnumerable 
            // Com ele recebemos um IEnumerable que bloqueia até encontrar um novo item 
            // Dessa forma é possível usar um foreach com o BlockCollection 
            // e é possível remover o "while(true)"
            Task read2 = Task.Run(() =>
            {
                foreach (string v in colecao.GetConsumingEnumerable())
                    Console.WriteLine(v);
            });

            write.Wait();

            /* O programa termina quando o usuário não entra com dados
             * Cada string adicionada é inserida peloa TASK de escrita é removida pela TASK de leitura
            */
        }
    }
}
