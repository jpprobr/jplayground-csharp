using System;

namespace Exemplo033.Null_Coaslescing
{
    /// <summary>
    /// Exemplo com o null-coalescing operator: (??)
    /// O operador retornará o valor da esquerda se ele não for nulo;
    /// caso contrário, ele retorna o operando certo (especificado)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo 1
            int? x = null;
            int y = x ?? -1; // O valor de y é -1 porque x é nulo            
            Console.WriteLine("O valor de y é: {0}", y);
            Console.WriteLine("\n");

            // Exemplo 2
            int? a = null;
            int? b = null;
            int c = a ?? b ?? -1;
            Console.WriteLine("O valor de c é: {0}", c);

            // Exemplo 2
            b = 2;
            int? c2 = a == null ? b : a;
            Console.WriteLine("O valor de c2 é: {0}", c2);

            // Exemplo 3 - Possui aplicação e resultado do exemplo 2 (usando o null-coalescing)
            b = 2;
            int? c3 = a ?? b;
            Console.WriteLine("O valor de c3 é: {0}", c3);
        }
    }
}
