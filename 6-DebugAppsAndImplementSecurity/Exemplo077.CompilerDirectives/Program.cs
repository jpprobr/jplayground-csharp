using System;
using System.Reflection;

namespace Exemplo077.CompilerDirectives
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // Exemplo 1 - Mostra diretivas de compilação p/ "modo debug"
        // Uso de instruções especiais p/ o compilador ajudar no processo de compilação
        // Operadores do C# são permitidos: 
        // == (igualdade), != (desigualdade), && (e), || (ou e ! (não) para testar se é verdadeiro ou falso.
        public void DebugDirective()
        {
#if DEBUG
            Console.WriteLine("Debug mode");
#else
            Console.WriteLine("Not debug");
#endif
        }

        // Exemplo 2 - Mostra usos de diretivas de pré-processador para direcionar várias plataformas

        public Assembly LoadAssembly<T>()
        {
#if !WINRT
            Assembly assembly = typeof(T).Assembly;
#else
        Assembly assembly = typeof(T).GetTypeInfo().Assembly;
#endif
            return assembly;
        }

        // Exemplo 3 - Uso da diretiva "line"
        // A diretiva #line pode ser usada para modificar o número da linha do compilador e até o nome do arquivo.
        public void UsarDiretivaLine()
        {

#line 200 "OtherFileName"
            int a;    // line 200
#line default
            int b;   // line 4
#line hidden
            int c; // hidden
            int d; // line 7
        }

        // Exemplo 4 - Uso da diretiva "pragma" p/ ocultar o aviso ("warning")

        public void UsarDiretivaPragma()
        {
#pragma warning disable
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
#pragma warning restore
        }


        // Exemplo 5 - Chamar um método apenas em uma compilação de DEBUG
        public void SomeMethod()
        {
#if DEBUG
            Log("Step1");
#endif
        }

        // Exemplo 5.1 - Método comum que será chamado somente no modo DEBUG
        private static void Log(string message)
        {
            Console.WriteLine(message);
        }

        // Exemplo 5.2 - Método com o mesmo comportamento do anterior, porém usando um atributo condicionadl
        [System.Diagnostics.Conditional("DEBUG")]
        private static void Log2(string message)
        {
            Console.WriteLine(message);
        }
    }
}
