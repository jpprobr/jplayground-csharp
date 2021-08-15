using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo059.ConvertingDifferentTypes
{
    public static class ExemploExplicitAndImplicitOperator
    {
        public static void ExecutarExemplos()
        {
            Money m = new Money(42.45M);
            
            decimal amount = m;            // Usa operador implícito (note que recebe tipo Money)
            int truncatedAmount = (int)m;  // Usa operador explícito (note que recebe tipo Money)
            string formattedAmount = m;    // Usa operador implícito (note que recebe tipo Money)

            Console.WriteLine("amount: {0}", amount);
            Console.WriteLine("truncatedAmount: {0}", truncatedAmount);
            Console.WriteLine("formattedAmount: {0}", formattedAmount);
        }
    }

    /// <summary>
    /// Classe Money c/ exemplos de implementação de conversões implícitas e explícitas
    /// através do uso das keywords "implicit operator" / "explicit operator"
    /// </summary>
    class Money
    {
        public Money(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }

        // Declaração de operador implícito p/ converter p/ decimal
        // Deve ser declarado com estático público em sua classe
        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        // Declaração de operador explícito p/ converter p/ int
        // Deve ser declarado com estático público em sua classe
        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }

        public static implicit operator string(Money money)
        {
            return $"R$ {money.Amount}";
        }
    }
}
