using System;

namespace Exemplo046.Delegates.EventHandler
{
    /// <summary>
    /// Exemplo mostra mesmo caso do exemplo anterior, porém
    /// usando uma propriedade de acesso ao evento (custom event acessor)
    /// ou (acessador de evento personalizado)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            new ClasseCliente().CreateAndRaise();
        }        
    }

    public class ClasseCliente
    {
        public void CreateAndRaise()
        {
            Pub p = new Pub();

            // Sender é por convenção o objeto que gerou o evento 
            // sender é nulo se for proveniente de um método estático
            
            // Evento 1
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("Event raised: {0}", e.Value);
                Console.WriteLine("Sender: {0}", sender);
            };

            //Evento 2
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("Evento 2 disparado: {0}", e.Value);
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
    /// Classe Pub
    /// </summary>
    public class Pub
    {
        private event EventHandler<MyArgs> onChange = delegate { };

        /// <summary>
        /// Note que os acessadores ADD e REMOVE se parecem com os acessadores GET e SET
        /// É importante usar o "lock" para garantir que a operação seja thread-safe
        /// </summary>
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }

            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }


        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }
}
