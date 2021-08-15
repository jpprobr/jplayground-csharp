using System.Text;

namespace Exemplo068.ManipulateStrings
{
    class Program
    {
        /* Conceitos básicos sobre String 
         *  
         *  - String é um tipo por referência (que se parece com um tipo por valor) 
         *      - Operadores "==" e "!=" estão sobrecarregados p/ comparar no valor e não na referência
         *  
         *  - String é IMUTÁVEL: Não pode ser alterada após ter sido criada
         *      - Toda alteração em uma string criará outra string 
         *        (por isso os métodos de manipulação de string retornam uma string)
         *      - Sobre imutabilidade: Se sabemos que algo não mudará ele torna-se mais seguro p/ threads. 
         *          - Com a estrutura de dados imutável mantem-se "snapshots" dos estados
         *          - Operações como criar, desfazer e refazer tornam-se mais fáceis
         *  - 
         */

        static void Main(string[] args)
        {
            /* 
             * Descomente os exemplos caso queira ver/testar casos específicos
            */

            // Ex 1 - Concatenação de strings (importancia de considerar conceito de imutabilidade)
            //Exemplo1_Concat_and_Imutability.ExecutarExemplo();

            // Ex 2 - Uso do StringBuilder
            //Exemplo2_StringBuilder.ExecutarExemplo();

            // Ex 3 - StringWriter e StringReader
            //Exemplo3_StringWriter_And_StringReader.ExecutarExemplo();

            // Ex 4 - Search for strings
            //Exemplo4_SearchingForStrings.ExecutarExemplo();

            // Ex 5 - Formatting strings
            //Exemplo5_FormattingStrings.ExecutarExemplo();

            // Ex 6 - IFormatProvider e IFormattable
            //Exemplo6_IFormatProvider_And_IFormattable.ExecutarExemplo();

            // Ex 7 - Formtação de DateTime para string
            Exemplo7_FormatDateToString.ExecutarExemplo();
        }
    }
}
