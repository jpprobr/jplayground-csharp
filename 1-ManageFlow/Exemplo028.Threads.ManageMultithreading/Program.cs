using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplo028.Threads.ManageMultithreading
{
    /// <summary>
    /// Exemplo mostra a classe Volatile (tem métodos Read e Write especiais)
    /// Esses métodos desabilitam as otimizações do compilador
    /// para que possamos usar a ordem correta no seu código
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Run(() =>
            {
                Thread1();
            });

            //var task2 = Task.Run(() =>
            //{
                Thread2();
            //});

            Console.WriteLine();
        }

        // EXEMPLO 1 - Caso em que roda 2 threads podendo 
        // ter problema p/ saber e controlar a ordem de execução
        // Ao usar a palavra Volatile 

        //private static int _flag = 0;
        private static volatile int _flag = 0;
        private static int _value = 0;

        public static void Thread1()
        {
            Console.WriteLine("Executando a Thread1... ");

            _value = 5;
            _flag = 1;

            Console.WriteLine("_value = {0} e _flag = {1}", _value, _flag);
        }

        public static void Thread2()
        {
            Console.WriteLine("Executando a Thread2... ");

            if (_flag == 1)
                Console.WriteLine("\n{0}\n", _value);
        }
    }
}
