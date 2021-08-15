using System;
using System.Globalization;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo7_FormatDateToString
    {
        public static void ExecutarExemplo()
        {
            var dataAtual = DateTime.Now;
            Console.WriteLine("Data atual: {0}", dataAtual.ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("pt-BR")));

            var result = string.Format("Data atual: {0}", dataAtual.ToString("dd/MM/yyyy", new CultureInfo("pt-BR")));
            Console.WriteLine("Data atual: {0}", result);

            var teste1 = "  ";
            Console.WriteLine("teste1:|{0}|", teste1.Trim());

            string teste2 = null;
            Console.WriteLine("teste2:|{0}|", teste2?.Trim());
        }
    }
}
