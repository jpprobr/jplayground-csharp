using System;
using System.Linq;

namespace Exemplo20.Threads.PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo com uso do operador ForAll que permite iterar sobre uma coleção
            // quando a iteração também pode ser feita de maneira paralela.
            // Em contraste com ForEach, o ForAll não precisa de todos os resultados  
            // antes de iniciar a execução. No exemplo abaixo o ForAll remove, no entanto,
            // qualquer ordem de classificação especificada
            Console.WriteLine();
            Console.WriteLine("Testando ForAll: ");
            var numeros1 = Enumerable.Range(0, 20);
            var resultForAll = numeros1.AsParallel()
                                       .Where(i => i % 2 == 0);

            resultForAll.ForAll(e => Console.WriteLine(e));


            // Pode acontecer que a query paralela de algumas operações gerar uma exceção
            // O .NET Framework lida com isso agregando todas as exceções em um AggregateException
            // a qual exporõe uma lista com todas as exceções que ocorreram 
            // durante a execução paralela. 
            // As exceções podem ser vistas através da propriedade InnerExceptions
            Console.WriteLine();
            Console.WriteLine("Testando ForAll com AggregateException: ");
            var numeros2 = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numeros2.AsParallel()
                    .Where(i => IsEven(i));
                
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }

        /// <summary>
        /// Verifica se número é par
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsEven(int i)
        {
            if (i % 10 == 0) 
                throw new ArgumentException("i");

            return i % 2 == 0;
        }
    }
}
