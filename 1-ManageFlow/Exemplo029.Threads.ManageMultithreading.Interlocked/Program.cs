using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo029.Threads.ManageMultithreading
{
    /// <summary>
    /// Exemplo sem e com Interlocked (tornar as operações atômicas)
    /// n++ siginifica n = n + 1 (tanto para leitura quanto p/ escrita)
    /// Nenhuma outra thread verá resultados intermediários. 
    /// Obviamente, somar e subtrair é uma operação simples. 
    /// Se você tiver operações mais complexas, ainda precisará usar um bloqueio.
    /// Resolve caso reportado no Exemplo 26
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });
            
            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);
            
            up.Wait();
            
            Console.WriteLine(n);
        }

        // Interlocked também suporta alterancia de valores
        // => if ( c.Exchange(ref isInUse, 1) == 0) { }
        // Neste caso comentado ele retorna o valor atual e depois seta
        // para o novo valor
    }
}
