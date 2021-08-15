using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo054.CreateTypes
{
    public static class ExemploEnumeracoes
    {
        public static void ExecutarExemplo1()
        {
            Days day = Days.Sat;
            if ((byte)day == 1)
            {
                Console.WriteLine("Days.Sun: {0}. O valor int: {1}", Days.Sun, (int)Days.Sun);
            }

            Console.WriteLine("Days.Sun: {0}. O valor int: {1}", Days.Sun, (int)Days.Sun);
            Console.WriteLine("Days.Mon: {0}. O valor int: {1}", Days.Mon, (int)Days.Mon);
            Console.WriteLine("Days.Tue: {0}. O valor int: {1}", Days.Tue, (int)Days.Tue);
        }

        public static void ExecutarExemplo2()
        {
            Console.WriteLine("DaysOfWeek.Sun: {0}. O valor flag: {1}", DaysOfWeek.Sunday, DaysOfWeek.Sunday.ToString());
            Console.WriteLine("DaysOfWeek.Mon: {0}. O valor flag: {1}", DaysOfWeek.Monday, DaysOfWeek.Monday.ToString());

            DaysOfWeek readingDays = DaysOfWeek.Monday | DaysOfWeek.Saturday;
            
            if(readingDays.HasFlag(DaysOfWeek.Saturday))
            {
                Console.WriteLine("readingDays has flag 'Saturday'");
            }

            if (readingDays.HasFlag(DaysOfWeek.Thursday))
            {
                Console.WriteLine("readingDays has flag 'Thursday'");
            }

        }
    }

    /// <summary>
    /// Exemplo 1
    /// Inicia do 0 e vai incrementando de 1 em 1
    /// </summary>
    public enum Gender { Male, Female }

    /// <summary>
    /// Exemplo 2 - 
    /// </summary>
    enum Days : byte { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri };


    [Flags]
    enum DaysOfWeek
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40
    }

  
}
