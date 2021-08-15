using System;

namespace Exemplo045.Delegates.EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAndRaise();
        }

        public static void CreateAndRaise()
        {
            Pub p = new Pub();

            // Sender é por convenção o objeto que gerou o evento 
            // sender é nulo se for proveniente de um método estático
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("Event raised: {0}", e.Value);
                Console.WriteLine("Sender: {0}", sender);
            };
            
            p.Raise();
        }
    }

    /// <summary>
    /// Classe p/ representar argumentos do evento
    /// </summary>
    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }


    /// <summary>
    /// Embora a implementação do evento use um campo público, 
    /// você ainda pode personalizar a adição e remoção de assinantes
    /// Isto é chamado de "custom event accessor"
    /// </summary>
    public class Pub
    {
        /// <summary>
        /// Delegate usando argumentos
        /// Usar um EventHandler podemos especificar o tipo de argumento desejado
        /// Os subscribers do evento podem acessar os argumentos e usa-los
        /// </summary>
        public event EventHandler<MyArgs> OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }

    
}
