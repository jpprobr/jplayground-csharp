using System;
using System.Diagnostics;

namespace Exemplo065.UsingReflection
{
    public static class Exemplo1_AplicarAtributos
    {
    }

    // Ex. mostra uso do atribuito Serializable (SerializableAttribute)
    // Note o uso do sufixo "Attribute"
    // Um tipo pode ter vários atributos
    // Alguns atributos podem ser aplicados várias vezes
    [Serializable]
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        // Exemplo usando múltiplos atributos
        [Conditional("CONDITION1"), Conditional("CONDITION2")]
        static void MyMethod() { }


        /*  Atributos podem ter parâmetros, que podem ser nomeados e opcionais
            Valores configurados podem ser inspecionados posteriormente em tempo de execução
            Atributos também tem um alvo específico ao qual se aplica.
            Podem ser aplicados a um assembly inteiro, uma classe, um método específico
            ou mesmo um parâmetro de um método.
        */
        [assembly: AssemblyTitle("ClassLibrary1")]
        [assembly: AssemblyDescription("")]
        [assembly: AssemblyConfiguration("")]
        [assembly: AssemblyCompany("")]
        [assembly: AssemblyProduct("ClassLibrary1")]
        [assembly: AssemblyCopyright("Copyright © 2013")]
        [assembly: AssemblyTrademark("")]
        [assembly: AssemblyCulture("")]
        static void MyMethod2() { }
    }

}
