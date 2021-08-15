using System;

namespace Exemplo057.OverridingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var derived = new Derived();
            Console.WriteLine("derived.MyMethod() = {0}", derived.MyMethod());
        }

        class Base
        {
            // Note que o método é declarado como "virtual"
            public virtual int MyMethod()
            {
                return 42;
            }
        }
        class Derived : Base
        {
            // Note que o método é declarado como "override"
            public override int MyMethod()
            {
                return base.MyMethod() * 2;
            }
        }

        // Note que no caso abaixo quando a classe é selada 
        // a herança fica desabilitada
        /*
        sealed class Base2
        {
            public virtual int MyMethod()
            {
                return 42;
            }
        }

        class Derived2: Base2
        {

        }
        */
    }
}
