using System;

namespace Exemplo048.HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;

            // exemplo 1
            //s = null;

            // exemplo 2
            s = "A";

            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You need to enter a value");
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not a valid number. Please try again", s);
            }
            finally  
            {
                Console.WriteLine("Program complete.");
            }

            // Exemplos que não permitem cair no bloco finally: 
            // Loop infinito e falta de energia
            // É importante garantir que no bloco finally não ocorra nenhuam exceção
            // pois o controle passa para o bloco externo, se houver e a 
            // exceção original é perdida
        }
    }
}
