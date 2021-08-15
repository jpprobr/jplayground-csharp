using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo054.CreateTypes
{
    public class ExemploMetodos
    {
        // Exemplo 1 - Uso de argumentos nomeados e opcionais
        // Note que quando não declaramos o modificador de acesso 
        // por default o método é privado
        void MyMethod(int firstArgument, string secondArgument = "default value", bool thirdArgument = false)
        {
            
        }

        void CallingMyMethod()
        {
            MyMethod(1, thirdArgument: true);
        }


        // Exemplo 2 - Tipos de modificadores de acesso
        /*
            private: (default)     
            public:
            internal: 
            protected:
            internal:
            protected:
         */
    }

    class Card 
    {
    }

    class Deck
    {
        // Lista de Cards - declarado como campo da instancia
        public ICollection<Card> Cards { get; private set; }

        // Método que retorna o Card atual - declarado como campo da instancia
        public Card this[int index]     // uso do this remete a própria classe
        {
            get { return Cards.ElementAt(index); }
        }

        // Exemplo de declaração de campos como estático, ou seja, 
        // os dados não são específicos p/ as instancias (não são diferentes em cada instancia)
        // Importante lembrar que ao alterar o valor estático em um lugar, irá mudar
        // em todos os outros códigos em que o campo for usado, porque fica em uma única instancia 
        // e não fica em instancias separadas
        public static int MyStaticField = 42;

        // OBS.: Se todos os métodos de uma classe são estáticos, a classe inteira pode ser 
        // declarada como estática
    }
}
