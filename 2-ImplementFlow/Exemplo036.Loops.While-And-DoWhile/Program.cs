using System;

namespace Exemplo036.Loops.While_And_DoWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };

            // Exemplo 1 - Uso do while
            int index = 0;
            while (index < values.Length)
            {
                Console.Write(values[index]);
                index++;
            }

            // Exemplo 2 - Teste com continue
            Console.WriteLine("\n Teste com While e continue");

            index = 0;
            while (index < values.Length)
            {
                Console.Write(values[index]);

                if (values[index] == 3)
                    return;

                index++;
            }

            Console.WriteLine("\n");

            // Exemplo 3 - Uso do "do-while"
            do
            {
                Console.WriteLine("Executada uma vez!");
            }
            while (false);
        }
    }
}
