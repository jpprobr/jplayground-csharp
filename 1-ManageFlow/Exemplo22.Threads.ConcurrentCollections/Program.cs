using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Exemplo22.Threads.ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> colecao = new BlockingCollection<string>();

            Task read = Task.Run(() =>
            {
                foreach (string v in colecao.GetConsumingEnumerable())
                    Console.WriteLine(v);
            });
        }
    }
}
