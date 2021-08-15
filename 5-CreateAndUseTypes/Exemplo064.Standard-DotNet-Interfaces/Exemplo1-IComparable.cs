using System;
using System.Collections.Generic;

namespace Exemplo064.Standard_DotNet_Interfaces
{
    public static class Exemplo_IComparable
    {
        public static void ExecutarExemplo()
        {
            List<Order> orders = new List<Order>
            {
                 new Order { Created = new DateTime(2012, 12, 1 )},
                 new Order { Created = new DateTime(2012, 1, 6 )},
                 new Order { Created = new DateTime(2012, 7, 8 )},
                 new Order { Created = new DateTime(2012, 2, 20 )},
            };

            orders.Sort();

            foreach (var order in orders)
            {
                Console.WriteLine("order Date: {0}", order.Created);
            }            
        }
    }

    class Order : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }

            // Método CompareTo (no caso obtido pela classe DateTime
            // se for < 0: Instancia atual precede o objeto especificado no método CompareTo p/ ordenação (sort order)
            // se for = 0: Instancia atual ocorre na mesma posição do objeto especificado no método CompareTo p/ ordenação (sort order)
            // se for > 0: Instancia atual procede o objeto especificado no método CompareTo p/ ordenação (sort order)
            return this.Created.CompareTo(o.Created);
        }
    }
}
