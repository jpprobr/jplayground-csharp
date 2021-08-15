using System;

namespace Exemplo042.Delegates.LambdaExpressions
{
    /// <summary>
    /// Exemplo mostra uso de lambda expression e anonymous funcions
    /// p/ substituir os métodos criados no Exemplo 039
    /// </summary>
    class Program
    {
        public delegate int Calculate(int x, int y);


        static void Main(string[] args)
        {
            // Método de soma escrito com lambda expression e anonymous function
            // equivalente a:  public int Somar(int x, int y) { return x + y; }
            Calculate calc = (x, y) => x + y;   // Note que o delegate recebe um método 
            Console.WriteLine(calc(3, 4));      // Displays 7

            // Método de multiplicação escrito com lambda expression e anonymous function
            // equivalente a:  public int Multiplicar(int x, int y) { return x * y; }
            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));      // Displays 12

            Console.WriteLine("\n");
            Console.WriteLine("Outro exemplo: ");

            // Outro exemplo de método de soman com mais de um comando no bloco
            Calculate calc2 =
            (x, y) =>
            {
                Console.WriteLine("Somando números...");
                return x + y;
            };
            int result = calc2(3, 4);

            Console.WriteLine("Result: {0}", result);
        }



    }
}
