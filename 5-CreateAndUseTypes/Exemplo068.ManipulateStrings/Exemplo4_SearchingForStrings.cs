using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo4_SearchingForStrings
    {
        public static void ExecutarExemplo()
        {
            // Ex 1
            string value = "My Sample Value 1 and my sample value 2";

            // Retorna indice da primeira ocorrência
            int indexOfp = value.IndexOf('p');         // returns 6 (caso não encontrar retorna -1)

            // Retorna indice da ultima ocorrencia
            int lastIndexOfm = value.LastIndexOf('m'); // returns 5 (caso não encontrar retorna -1)

            Console.WriteLine("\n indexOfp: {0}", indexOfp);
            Console.WriteLine("\n lastIndexOfm: {0}", lastIndexOfm);

            // Ex 2 - StartsWith e EndsWith
            string value2 = "< mycustominput >";
            Console.WriteLine("\n value2.StartsWith(<):{0}", value2.StartsWith("<"));
            Console.WriteLine("\n value2.StartsWith(<):{0}", value2.EndsWith(">"));

            // Ex 3 - Substring
            string value3 = "My Sample Value";
            string subString = value3.Substring(3, 6);       // Returns 'Sample'
            Console.WriteLine("\n substring: {0}", subString);

            // Ex 4 - Regex
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };
            foreach (string name in names)
                Console.WriteLine("\n{0}", Regex.Replace(name, pattern, String.Empty));
        }
    }
}
