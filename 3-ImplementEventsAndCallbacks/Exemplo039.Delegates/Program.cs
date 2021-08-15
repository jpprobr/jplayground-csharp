using System;

namespace Exemplo039.Delegates
{
    /// <summary>
    /// Exemplo mostra uso do "delegate"
    /// Delegates por ser aninhados em outros tipos 
    /// e em seguida, podem ser usados como um tipo aninhado
    /// Um delegate instanciado é um objeto e você pode 
    /// passa-lo como um argumento para outros métodos
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var exemplo = new ExemploDelegate();
            
            exemplo.UseDelegate();

            Console.WriteLine("\n");
        }
    }

    class ExemploDelegate
    {
        public delegate int Calculate(int x, int y);

        public int Somar(int x, int y) { return x + y; }
        public int Multiplicar(int x, int y) { return x * y; }

        public void UseDelegate()
        {
            Calculate calc = Somar;
            Console.WriteLine(calc(3, 4)); // Displays 7

            calc = Multiplicar;
            Console.WriteLine(calc(3, 4)); // Displays 12
        }
    }
}
