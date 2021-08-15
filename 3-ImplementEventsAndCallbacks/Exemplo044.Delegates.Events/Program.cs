using System;

namespace Exemplo044.Delegates.Events
{
    /// <summary>
    /// Exemplo mostra criação e uso de evento
    /// Podemos inscrever uma classe em um evento e ser notificado
    /// Isso é usado p/ estabelecer um acoplamento fraco entre os 
    /// componenetes de um aplicativo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo com a classe Pub
            CreateAndRaise();
            Console.WriteLine("\n");

            // Exemplo com a classe Pub2 - (com alterações na declaração)
            CreateAndRaise_Pub2();
        }

        /// <summary>
        /// Método p/ assinar métodos e gerar evento
        /// OBS.: Classe Pub não tem conhecimento de nenhum assinante
        /// </summary>
        public static void CreateAndRaise()
        {
            Pub p = new Pub();

            // Assina o evento com 2 métodos diferentes
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");

            // Gera evento 
            p.Raise();
        }

        public static void CreateAndRaise_Pub2()
        {
            Pub2 p = new Pub2();

            // Assina o evento com 2 métodos diferentes
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");

            // Gera evento 
            p.Raise();
        }
    }

    /// <summary>
    /// Classe Pub usa Action p/ expor um evento
    /// </summary>
    public class Pub
    {
        // Exemplo de declaração de Ação p/ expor o evento OnChange
        // Sem usar a keyword "event" nada impede usuários da classe de
        /// alterar ou aumentar o evento
        public Action OnChange { get; set; }

        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }        
    }   

    public class Pub2
    {
        // Esta declaração usando a keyword "event" o compilador 
        // protege seu campo de acesso indesejado
        // Eventos não podem ser associados aos operadores "=" ou "+="
        public event Action OnChange = delegate { };
        
        public void Raise()
        {
            OnChange();
        }
    }
}
