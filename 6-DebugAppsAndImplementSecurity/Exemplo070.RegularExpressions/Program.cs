using System;
using System.Text.RegularExpressions;

namespace Exemplo070.RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1234AB";

            // Ex 1 - Com validação manual
            Console.WriteLine("\n {0}", ValidateZipCodeManually(input));

            // Ex 2 - Com validação por Regex
            Console.WriteLine("\n {0}", ValidateZipCodeRegEx(input));

            // Ex 3 - Usando RegEx p/ remover espaços em excesso
            string inputComEspacos = "1 2  3  4   5";
            Console.WriteLine("\n Resultado format entrada: {0}", FormatInputWithRegex(inputComEspacos));
        }

        // Exemplo da dificuldade p/ validar um CEP Holandes manualmente
        static bool ValidateZipCodeManually(string zipCode)
        {
            // Valid zipcodes: 1234AB | 1234 AB | 1001 AB
            if (zipCode.Length < 6) return false;
            string numberPart = zipCode.Substring(0, 4);
            int number;
            if (!int.TryParse(numberPart, out number)) return false;

            string characterPart = zipCode.Substring(4);
            if (numberPart.StartsWith("0")) 
                return false;
            
            if (characterPart.Trim().Length < 2) 
                return false;
            
            if (characterPart.Length == 3 && characterPart.Trim().Length != 2)
                return false;
            return true;
        }

        static bool ValidateZipCodeRegEx(string zipCode)
        {
            Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        static string FormatInputWithRegex(string input)
        {
            Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
          
            string result = regex.Replace(input, " ");
            return result; // return to displays 1 2 3 4 5 
        }
    }
}
