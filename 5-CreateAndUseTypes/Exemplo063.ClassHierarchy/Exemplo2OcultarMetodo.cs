using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo063.ClassHierarchy
{
    public static class Exemplo2OcultarMetodo
    {
        public static void ExecutarExemplo()
        {
            Base b = new Base();
            b.Execute();
            b = new Derived();
            b.Execute();
        }
    }

    class Base
    {
        //public void Execute()
        public virtual void Execute()
        {
            Console.WriteLine("Base.Execute");
        }
    }
    class Derived : Base
    {
        // O uso da keyword "new" oculta explicitamente o membro de uma classe base
        // e sobrepõe o comportamento do método de mesma assinatura da classe base
        // (diferente do "new" para criar uma instancia)
        //public new void Execute()
        public override void Execute()
        {
            Console.WriteLine("Derived.Execute");
        }
    }
}
