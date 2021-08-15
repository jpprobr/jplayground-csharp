using System;
using System.Dynamic;

namespace Exemplo061.DynamicObject_And_ExpandoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // DynamicObject é mais flexível
            // Quando estiver herdando dele, é possível substituir membros
            // os quais permitem substituir operações de get e set,
            // chamar métodos ou executar conversões

            // Exemplo 1 - DynamicObject
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.SomeProperty); // Displays ‘SomeProperty’

            // ExpandoObject é uma implementação "sealed" a qual permite
            // usar get e set de propriedades de um tipo (criado dinamicamente)
            // Ex.: ViewBag do MVC (passar dados do Controller p/ a View)
            dynamic expObj = new ExpandoObject();
            expObj.Teste1 = "Valor do Teste1";
            expObj.Teste2 = "Valor do Teste2";
            Console.WriteLine("expObj - Teste1: {0}", expObj.Teste1);
            Console.WriteLine("expObj - Teste2: {0}", expObj.Teste2);
        }
    }

    public class SampleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }


}
