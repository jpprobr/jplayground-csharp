using System;
using System.Linq;
using System.Collections.Generic;

namespace Exemplo047.Delegates.EventHandler_.Exceptions
{
    /// <summary>
    /// Exemplo mostra como 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CreateAndRaise_Exemplo1();
        }

        // Exemplo 1
        public static void CreateAndRaise_Exemplo1()
        {
            Pub p = new Pub();

            p.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 1 called");
            
            p.OnChange += (sender, e)
                => { throw new Exception(); };
            
            p.OnChange += (sender, e)
                => Console.WriteLine("Subscriber 3 called");
            
            try
            {
                p.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }
        
        // Displays
        // Subscriber 1 called
        // Subscriber 3 called
        // 1
    }


    public class Pub
    {
        public event EventHandler OnChange = delegate { };

        public void Raise()
        {
            var exceptions = new List<Exception>();

            // Uso o GetInvocationList() p/ recuperar os subscribers (percorre os delegates)
            // e enumerá-los manualmente p/ tratar as exceções
            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    // Chama o método representado pelo delegate atual
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
