using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo069.ManagingDataIntegrity
{
    public static class Exemplo02
    {
        public static void ExecutarExemplo()
        {
            // Ex 1 - Usando parse
            // O método bool.Parse usa os campos estáticos somente leitura TrueString e FalseString
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b); // displays True

            // Ex 2 - Usando o tryParse (caso não tenha certeza que o "parsing" será bem sucedido)
            string value = "1";
            int result;
            bool exemplo_successo = int.TryParse(value, out result);
            if (exemplo_successo)
            {
                // value is a valid integer, result contains the value
            }
            else
            {
                // value is not a valid integer
            }

            // Ex 3 - Usando o Convert com valor nulo p/ observar retorno (valor padrão)
            /*
                A diferença entre "Parse", "TryParse" e "Convert" é que o "Convert" permite valores nulos
                Ele não lança uma ArgumentNullException; em vez disso, 
                ele retorna o valor padrão para o tipo fornecido (supplied type)
            */
            int i = Convert.ToInt32(null);
            Console.WriteLine(i); // Displays 0

            // Ex 4 - Conversão de um double p/ um int
            /* Uma diferença entre os métodos Convert e Parse é que o Parse permite apenas usar string
             * como entrada, enquanto o Convert também pode usar outros tipos base como entrada. 
             * O valor "double" é arredondado.
            */
            double d = 23.15;
            int i = Convert.ToInt32(d);
            Console.WriteLine(i); // Displays 23
            // OBS.: Métodos como estes lançam um "OverflowException" quando são 
            //       "parseados" / convertidos e são muito grandes p/ o tipo de destino
        }

    }
}
