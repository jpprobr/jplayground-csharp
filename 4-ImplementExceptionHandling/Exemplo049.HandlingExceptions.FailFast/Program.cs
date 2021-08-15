using System;

namespace Exemplo049.HandlingExceptions.FailFast
{
    /// <summary>
    /// Exemplo mostra uso do FailFast p/ casos excepcionais 
    /// em que pode ser mais vantajoso ou seguro encerrar o sistema do que 
    /// executar o bloco finally
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            try
            {
                int i = int.Parse(s);
                
                if (i == 42) 
                    Environment.FailFast("Special number entered");

                // Quando executado sem um depurador, a mensage é gravada no log de eventos
            }
            finally
            {
                Console.WriteLine("Program complete.");
            }
        }
    }
}
