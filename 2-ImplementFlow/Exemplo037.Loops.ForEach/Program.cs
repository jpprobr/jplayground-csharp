using System;
using System.Collections.Generic;

namespace Exemplo037.Loops.ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo 1
            CannotChangeForeachIterationVariable();

            Console.WriteLine("\n");

            // Exemplo 2
            ExecutarExemplo2();
        }

        static void CannotChangeForeachIterationVariable()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName = "Doe"},
                new Person() { FirstName = "Jane", LastName = "Doe"},
            };

            foreach (Person p in people)
            {
                if (people.IndexOf(p) == 1)// Obtem index do item atual e se for 1 alterada a propriedade 
                {
                    p.LastName = "Changed"; // Isto é permitido
                    // p = new Person();    // Isto gera um erro de compilação
                }

                Console.WriteLine("FirstName: {0}, LastName: {1}", p.FirstName, p.LastName);
            }
        }

        /// <summary>
        /// Exemplo mostra um código similar ao que o compilador gera p/ um loop ForEach
        /// Se alterarmos o valor de e.Current p/ qq outra coisa, o Iterator Pattern não poderá
        /// determinar o que fazer quando e.MoveNext é chamado
        /// </summary>
        static void ExecutarExemplo2()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName = "Doe"},
                new Person() { FirstName = "Jane", LastName = "Doe"},
            };
            
            List<Person>.Enumerator e = people.GetEnumerator();

            try
            {
                Console.WriteLine("e.Current (inicial): {0}", e.Current);

                Person v;
                while (e.MoveNext())
                {
                    v = e.Current;
                    Console.WriteLine("e.Current: {0}", v);
                }
            }
            finally
            {
                System.IDisposable d = e as System.IDisposable;
                if (d != null) d.Dispose();
            }
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
