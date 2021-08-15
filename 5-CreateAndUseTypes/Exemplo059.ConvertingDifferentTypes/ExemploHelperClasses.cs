using System;

namespace Exemplo059.ConvertingDifferentTypes
{
    public static class ExemploHelperClasses
    {
        public static void ExecutarExemplos()
        {
            // Ex com classe Convert
            int value = Convert.ToInt32("42");
            Console.WriteLine("value: {0}", value);

            // Ex com o método "Parse" do struct "int" (Int32)
            value = int.Parse("43");
            Console.WriteLine("value: {0}", value);

            // Ex com o método "TryParse" do struct "int" (Int32)
            bool success = int.TryParse("44", out value);
            Console.WriteLine("value: {0}", value);
            Console.WriteLine("success: {0}", success);
        }
    }
}
