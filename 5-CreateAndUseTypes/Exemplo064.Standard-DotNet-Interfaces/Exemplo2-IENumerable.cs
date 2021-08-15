using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exemplo064.Standard_DotNet_Interfaces
{
    class Exemplo2_IENumerable
    {
        public static void ExecutarExemplo()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };

            // Exemplo 1 - Mostra como iterar em uma col~eção sem usar o "foreach"
            // Este trecho de código é ocultado dos usuários quando usamos o "foreach"
            // Podemos pensar que funciona da mesma maneira que é usado em um banco de dados
            // GetEnumerator() retorna um IEnumerator
            // IENumrable<T> é a tabela 
            // IENumerator é o cursor que controla onde você está na tabela
            // Podemos ter vários cursores de BD e cada um controlando seu próprio estado
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current);
            }

            // Exemplo 2
            Person p1 = new Person("João", "Silva");
            Person p2 = new Person("Maria", "Oliveira");
            var personList = new Person[] { p1, p2 };

            var people = new People(personList);
            foreach (var p in people)
            {
                Console.WriteLine("Person: {0}", p.ToString());
            }
        }
    }


    class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " +LastName;
        }
    }

    class People : IEnumerable<Person>
    {
        public People(Person[] people)
        {
            this.people = people;
        }

        Person[] people;

        public IEnumerator<Person> GetEnumerator()
        {
            for (int index = 0; index < people.Length; index++)
            {
                // Yield é uma palavra-chave especial que pode ser usada apenas no contexto de iteradores. 
                // Ele instrui o compilador a converter esse código regular em uma máquina de estado. 
                // O código gerado controla onde você está na coleção e implementa métodos como MoveNext e Current.
                yield return people[index]; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
