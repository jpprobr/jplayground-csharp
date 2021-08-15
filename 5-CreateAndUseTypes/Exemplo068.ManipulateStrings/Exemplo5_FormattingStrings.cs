using System;
using System.Globalization;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo5_FormattingStrings
    {
        public static void ExecutarExemplo()
        {
            Console.WriteLine("\n");

            // Ex 1 - Sobrescrevendo o método ToString
            Person p = new Person("John", "Paul");
            Console.WriteLine(p);
            Console.WriteLine();

            // Ex 2 - Usando as formatações de string
            double cost = 1234.56;
            Console.WriteLine("Custo em en-US: {0}", cost.ToString("C", new CultureInfo("en-US")));
            Console.WriteLine("Custo em pt-BR: {0}", cost.ToString("C", new CultureInfo("pt-BR")));
            Console.WriteLine();

            // Ex 3 - Formatando Data/Hora em pt-BR
            DateTime d = new DateTime(2013, 4, 22);
            CultureInfo provider = new CultureInfo("pt-BR");
            Console.WriteLine(d.ToString("d", provider));
            Console.WriteLine(d.ToString("D", provider));
            Console.WriteLine(d.ToString("M", provider));

            // Ex 4 - Formatando usando o ToString()
            Person p2 = new Person("Peter", "Parker");
            Console.WriteLine("Nome formatado com ToString() caso 2: {0}", p2.ToString("FSL"));
        }
    }


    class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Exemplo 1 de "overriding" do método ToString() p/ customização
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // Exemplo 2 de "overriding" do método ToString() p/ customização
        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format) || format == "G")
                format = "FL";

            format = format.Trim().ToUpperInvariant();

            switch (format)
            {
                case "FL":
                    return FirstName + " " + LastName;
                case "LF":
                    return LastName + " " + FirstName;
                case "FSL":
                    return FirstName + ", " + LastName;
                case "LSF":
                    return LastName + ", " + FirstName;
                default:
                    throw new FormatException(
                        String.Format("O formato de string: '{0}' não é suportado.", format)
                    );
            }
        }
    }


}
