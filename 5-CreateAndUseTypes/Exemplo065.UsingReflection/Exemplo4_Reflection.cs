using System;
using System.Linq;
using System.Reflection;

namespace Exemplo065.UsingReflection
{
    public static class Exemplo4_Reflection
    {
        public static void ExecutarExemplos()
        {
            // Ex 1 - Exemplo mais básico de reflection
            // Obter o tipo atual de um objeto
            int i = 42;
            System.Type tipo = i.GetType();

            // Ex 2 - Inspecionando um assembly para tipos 
            //        que implementam uma interface personalizada

            /*
            // Carrega assembly por nome 
            // (mesmo que chamar múltiplas vezes o runtime só carregará o assembly uma única vez)
            Assembly pluginAssembly = Assembly.Load("testeAssembly");

            // Verifica se plugins estão definidos no assembly e obtem objetos do tipo IPlugin
            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;
            */

            // Ex 3 - Suposição de caso em que precisamos, por exemplo, 
            // selecionar todos os campos inteiros privados para exibi-los na tela. 
            // (Note que é necessário acessar os metadados)
            // (Veja o método DumpObject na classe Exemplo3)         
            var myApp = new MyApplication();
            Exemplo3.DumpObject(myApp);

            // Ex 4 - Reflection também pode ser usada p/ executar métodos em um tipo
            // Podemos especificar os parâmetros que o método precisa e, em tempo de execução, 
            // o .NET Framework verificará se os parâmetros correspondem e então método será executado
            /*
            int x = 42;
            
            // Obtem método de um tipo (ex.: classe, interface...)
            MethodInfo compareToMethod = x.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            
            // Invoca método obtido
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
            */
        }
    }

    // Simula aplicação
    public class MyApplication
    {
        private int _field1 = 1;
        private string _field2 = "texto 1";

        public int property1 { get { return 2; } }
        public string property2 { get { return "texto 2"; } }
    }

    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(MyApplication application);
    }

    public class MyPlugin : IPlugin
    {
        public string Name
        {
            get { return "MyPlugin"; }
        }
        public string Description
        {
            get { return "My Sample Plugin"; }
        }
        public bool Load(MyApplication application)
        {
            return true;
        }
    }


    public class Exemplo3
    {
        public static void DumpObject(object obj)
        {
            // Uso da enumeração BindingFlags p/ controlar como a reflexion busca por membros
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                {
                    Console.WriteLine(field.GetValue(obj));
                    // Deve imprimir apenas o campo do tipo string que não é público
                }
            }
        }
    }
}
