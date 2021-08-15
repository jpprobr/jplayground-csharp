using System;

namespace Exemplo038.JumpStatements
{
    /// <summary>
    /// Exemplo mostra uso de GoTo (a qual deve ser evitada e não é recomendada)
    /// É considerada uma má prática
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;

            if (x == 3)
                goto customLabel;

            x++;

            if (x == 4)
                goto customLabel2;

            x++;

        customLabel:
            Console.WriteLine("customLabel");
            Console.WriteLine(x);            
        // Displays 3

        customLabel2:
            Console.WriteLine("customLabel2");
            Console.WriteLine(x);
            

        }
    }
}
