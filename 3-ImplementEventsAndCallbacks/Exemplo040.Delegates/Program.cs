using System;

namespace Exemplo040.Delegates
{
    /// <summary>
    /// Exemplo mostra uso de delegate com Multicast
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var exemplo = new Exemplo040();

            // Exemplo usando delegate com multicast (vários métodos)
            exemplo.Multicast();
        }
    }

    class Exemplo040
    {
        public void MethodOne()
        {
            Console.WriteLine("Method 1");
        }
        public void MethodTwo()
        {
            Console.WriteLine("Method 2");
        }
        

        public delegate void Del();

        public void Multicast()
        {
            // Delegate recebe o método 1
            Del d = MethodOne;

            // Delegate recebe também o método 2
            d += MethodTwo;

            d();

            // Exemplo obtendo a qtde métodos de um delegate
            Console.WriteLine("Qtde métods: {0}", DescobrirQtdeMetodosEmUso(d));
        }

        // Displays
        // MethodOne
        // MethodTwo


        /// <summary>
        /// Exemplo de método p/ descobrir quantos métodos 
        /// o multicast delegate está chamando
        /// </summary>
        /// <returns></returns>
        public int DescobrirQtdeMetodosEmUso(Delegate del)
        {
            int invocationCount = del.GetInvocationList().GetLength(0);
            return invocationCount;
        }
    }
}
