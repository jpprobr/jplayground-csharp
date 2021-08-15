using System;

namespace Exemplo055.GenericTypes
{
    /*
     No .NET Framework, um ponto que podemos notar o uso de "Generics" 
     está no suporte para Nullables. 
     Um tipo de referência PODE ter um valor real NULO, o que significa que não tem valor. 
     Um tipo por VALOR NÃO PODE ter um valor NULO, no entanto. 
     Por ex., como podemos expressar que algum valor booleano é verdadeiro, falso ou desconhecido?
     Um booleano comum pode ser verdadeiro ou falso. (do Tipo de dados por VALOR)
    */

    /*
        O .NET Framework possui várias implementações de classes de coleções genéricas
        no namespace System.Collections.Generic
        
        Sempre que possível, as coleções genéricas devem ser usadas ao invés das "não-genéricas"
        
        Tipos genéricos podem ser usados em estruturas, classes, interfaces, 
        métodos, propriedades e delegates

        Os tipos por referência por natureza já têm a opção de serem nulos. (Nullables)
    */


    class Program
    {
        static void Main(string[] args)
        {
            // Exemplos chamando a Classe MyClass com tipo genérico

            // Exemplo 1 passando uma classe como argumento p/ a MyClass (exige o new) 
            var myClass1 = new MyClass<Exemplo1>();
            Console.WriteLine("exemplo1: {0}\n", myClass1.MyProperty.MyProperty);

            // Exemplo 2 passando uma interface como argumento p/ a MyClass2
            Exemplo2 exemplo2 = new Exemplo2();
            var myClass2 = new MyClass2<IExemplo2>(exemplo2);
            Console.WriteLine("exemplo2: {0}\n", myClass2.MyProperty.MyProperty);

            Console.ReadKey();
        }
        

        class Exemplo1
        {
            public string MyProperty { get { return "Teste Exemplo 1"; } }
        }

        interface IExemplo2
        {
            string MyProperty { get; }
        }

        class Exemplo2 : IExemplo2
        {
            public string MyProperty { get { return "Teste Exemplo 2"; } }

            /// <summary>
            /// Exemplo de método com um parâmetro do tipo genérico
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public void MyGenericMethod<T>()
            {
                // Para obter o valor default de um tipo genérico
                // deve-se usar a keyword "default", que retorna 
                // o valor default do tipo em questão (que está sendo passado)
                T defaultValue = default(T);
            }
        }

        /// <summary>
        /// MyClass 
        /// Exemplo de classe usando a clausula "where" em sua definição 
        /// p/ condicinar o tipo genérico passar como argumento 
        /// A condição do "where" significa O argumento T deve ser 
        /// um tipo por referência: por exemplo, uma classe, interface, delegate ou array
        /// A expressão "new()" significa que o "T" deve ter um construtor default público 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class MyClass<T> where T : class, new()
        {
            public MyClass()
            {
                MyProperty = new T();
            }

            public T MyProperty { get; set; }
        }

        /// <summary>
        /// MyClass2 (mesma configuração anterior, porém sem a expressão "new()"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class MyClass2<T> where T : class
        {
            public MyClass2(T tipoGenerico)
            {
                MyProperty = tipoGenerico;
            }

            public T MyProperty { get; set; }
        }
    }
}
