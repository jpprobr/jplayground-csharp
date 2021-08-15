using System;

namespace Exemplo043.Delegates.Built_In_types
{
    /// <summary>
    /// Às vezes, declarar um delegado para um evento é um pouco complicado.
    /// Por esse motivo, o .NET Framework possui alguns tipos de delegados internos 
    /// que você pode usar ao declarar delegados. 
    /// </summary>
    class Program
    {
        // Para os exemplos anteriores com o "Calcular"
        // foi usado o seguinte delegado
        public delegate int Calculate(int x, int y);

        // Podemos substituir esse representante por um dos tipos internos, 
        // definido como: "Func <int, int, int>"
        // Estes podem ser encontrados na namespace "System"
        // e estes representam delegates que retornam um tipo e podem ter
        // de 0 a 16 parâmetros

        // Para tipos de delegates que não retornam um valor
        // podemos usar os tipos da namespace "System.Action"


        static void Main(string[] args)
        {
            // Exemplo usando o Action delegate
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };
            calc(3, 4); // Displays 7

            Console.WriteLine("\n");
        }
    }
}
