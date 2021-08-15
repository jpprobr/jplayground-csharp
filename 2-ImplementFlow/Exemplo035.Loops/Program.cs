using System;

namespace Exemplo035.Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo 1 - For com múltiplas condições
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int x = 0,                         // Valor inicial
                y = values.Length - 1;              // Condição 1 (percorrendo y "descendo")
                ((x < values.Length) && (y >= 0));  // Condição 2 (percorrendo x "subindo")
                x++, y--)                           // vai incrementando x e decrementando y
            {
                Console.Write(values[x]);
                Console.Write(values[y]);
            }
            // Displays
            // 162534435261

            
            // Exemplo 2 - Incrementando de 2 valores (de 2 em 2)
            Console.WriteLine("\n");
            int[] values_ex2 = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values_ex2.Length; index += 2)
            {
                Console.Write(values_ex2[index]);
            }

            
            // Exemplo 3 - Uso do "break" ou "return"  p/ abortar 
            Console.WriteLine("\n");
            int[] values_ex3 = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values_ex3.Length; index++)
            {
                if (values_ex3[index] == 4) 
                    break;
                
                Console.Write(values_ex3[index]);
            }

            // Exemplo 4 - Uso do "continue"
            Console.WriteLine("\n");
            int[] values_ex4 = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values_ex4.Length; index++)
            {
                if (values_ex4[index] == 4) 
                    continue;
                
                Console.Write(values_ex4[index]);
            }
            // Displays
            // 12356
        }
    }
}
