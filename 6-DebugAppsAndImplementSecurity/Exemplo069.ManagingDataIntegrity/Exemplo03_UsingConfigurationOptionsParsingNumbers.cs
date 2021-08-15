using System;
using System.Globalization;

namespace Exemplo069.ManagingDataIntegrity
{
    public static class Exemplo03_UsingConfigurationOptionsParsingNumbers
    {
        public static void ExecutarExemplo()
        {
            CultureInfo english = new CultureInfo("En"); // ingles
            CultureInfo dutch = new CultureInfo("Nl");   // holandes
            string value = "€19,95";
            decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);
            Console.WriteLine(d.ToString(english)); // Displays 19.95
        }
    }
}
