using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo063.ClassHierarchy
{
    class Exemplo1HierarquiaClasse
    {
    }


    interface IEntity
    {
        int Id { get; }
    }
    class Repository<T>
     where T : IEntity
    {
        protected IEnumerable<T> _elements;
        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }
        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }

    class Order : IEntity
    {
        public int Id { get; }
        // Other implementation details omitted
        // …
    }

    class OrderRepository : Repository<Order>
    {
        public OrderRepository(IEnumerable<Order> orders)
        : base(orders) 
        { 
            // A palavra "base" permite a chamada do construtor da classe base
        }
        public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
        {
            List<Order> result = null;
            // Some filtering code
            return result;
        }
    }
}