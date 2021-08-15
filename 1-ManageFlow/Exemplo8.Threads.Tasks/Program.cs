using System;
using System.Threading.Tasks;

namespace Exemplo8.Threads.Tasks
{
    /// <summary>
    /// Exemplo mostra usar uma task de continuação
    /// Método ContinueWith permite executar outra operação assim que
    /// a operação das TASK estiver concluída
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            Console.WriteLine(t.Result); // Displays 84
        }
    }
}
