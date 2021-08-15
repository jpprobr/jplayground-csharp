using System;

namespace Exemplo032.BooleanExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //  && (AND): Retorna true quando ambos os operandos são true

            //  || (OR):  Retorna true quando um dos operandos é true

            /*  ^^ (XOR / Exclusive OR): 
             *  Retorna true somente quando EXATAMENTE um dos operandos for verdadeiro
             *  Tabela com possíveis valores para o XOR operator
             *  Left operand    Right operand       Result
                True            True                False
                True            False               True
                False           True                True
                False           False               False
             */

            // Exemplo com operador XOR
            bool a = true;
            bool b = false;
            Console.WriteLine(a ^ a); // True  + True  = False
            Console.WriteLine(a ^ b); // True  + False = True
            Console.WriteLine(b ^ b); // False + False = False
        }
    }
}
