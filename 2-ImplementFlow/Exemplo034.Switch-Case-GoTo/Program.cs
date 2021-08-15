using System;

namespace Exemplo034.Switch_Case_GoTo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo 1
            int i = 1;
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine("Case 1");
                        goto case 3;  // Note que com goto não usamos o break
                    }
                case 2:
                    {
                        Console.WriteLine("Case 2");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Case 3");
                        goto case 2;
                    }
            }
            // Displays
            // Case 1
            // Case 3
            // Case 2

            Console.WriteLine("\n");

            // Exemplo 2
            CheckWithSwitch('y');
        }

        /// <summary>
        /// Exemplo mostra que as "switch-sections" pode conter uma ou mais "switch-labels"
        /// No caso das vogais há vários casos que precisam apenas de um bloco
        /// </summary>
        /// <param name="input"></param>
        static void CheckWithSwitch(char input)
        {
            switch (input)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    {
                        Console.WriteLine("Entrada é uma vogal");
                    }
                    break;
                case 'y':
                    {
                        Console.WriteLine("Entrada é, as vezes, um vogal");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Entrada é uma consoante");
                        break;
                    }
            }
        }
    }
}
