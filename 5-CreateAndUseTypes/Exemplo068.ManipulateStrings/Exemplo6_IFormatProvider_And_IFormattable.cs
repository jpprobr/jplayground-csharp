using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo6_IFormatProvider_And_IFormattable
    {
        public static void ExecutarExemplo()
        {
            int a = 1;
            int b = 2;
            string result = string.Format("a: {0}, b: {1}", a, b);
            Console.WriteLine(result); // Displays 'a: 1, b: 2'
        }
    }
}
