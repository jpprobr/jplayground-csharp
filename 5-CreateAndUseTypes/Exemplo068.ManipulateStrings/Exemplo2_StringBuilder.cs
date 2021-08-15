using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo2_StringBuilder
    {
        public static void ExecutarExemplo()
        {
            // Ex 2 - Uso do StringBuilder 
            //        (usa buffer de strings internamente p/ melhorar a performance)
            StringBuilder sb = new StringBuilder(string.Empty);
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("x");
            }
        }
    }
}
