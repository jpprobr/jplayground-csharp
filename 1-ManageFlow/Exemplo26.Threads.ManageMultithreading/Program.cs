using System;
using System.Threading.Tasks;

namespace Exemplo26.Threads.ManageMultithreading
{
    /// <summary>
    /// Exemplos mostram o que pode ocorrer em um cenário não gerenciado 
    /// usando multithreading. No exemplo é possível notar que nunca obteremos uma saída esperada
    /// Obs.: Isso é porque a operação não é atômica (operações de leitura e escrita ocorrem em momentos diferentes)
    /// É por isso que o acesso aos dados com os quais trabalhamos precisam ser sincronizados,
    /// para que você possa prever com segurança como seus dados são afetados
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo com problemas de acesso compartilhado (s/ previsão de resultado)
            /*int n = 0;
            
            var up = Task.Run(() =>
            {
                // 1 a 1M (incrementando)
                for (int i = 0; i < 1000000; i++)
                    n++;
            });

            // 1 a 1M (decrementando)
            for (int i = 0; i < 1000000; i++)
                n--;

            up.Wait();

            Console.WriteLine(n);
            */


            // Exemplo 2 - Uso do lock p/ corrigir exemplo anterior
            // Programa sempre retorna 0 porque o acesso a variável n agora está sincronizado
            // Não há como uma thread alterar o valor enquanto outra thread estiver utilizando ele.
            // Porém isso pode gerar um deadlock (impasse) no qual, neste caso,
            // ocorre que os 2 threads esperam uma ao outro e nenhum é concluído
            int n = 0;
            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    lock (_lock)
                        n++;
            });
            
            for (int i = 0; i < 1000000; i++)
                lock (_lock)
                    n--;

            up.Wait();
            Console.WriteLine(n);
        }
    }
}
