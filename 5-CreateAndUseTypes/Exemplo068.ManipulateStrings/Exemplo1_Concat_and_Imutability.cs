using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo068.ManipulateStrings
{
    public static class Exemplo1_Concat_and_Imutability
    {
        public static void ExecutarExemplo()
        {
            // Ex 1 - Em cada iteração será criada uma nova string (no caso 10.000 strings)
            //        A referência "s" apontará somente p/ o último item, então todas 
            //        as outras strings estarão imediatamente prontas para a "coleta de lixo"
            //        Para otimização o C# executa, em tempo de compilação o "string interning"
            //        Em strings identicas o compilador garante que apenas 1 objeto seja criado pelo CLR
            string s = string.Empty;
            for (int i = 0; i < 10000; i++)
            {
                s += "x";
            }
        }
    }
}
