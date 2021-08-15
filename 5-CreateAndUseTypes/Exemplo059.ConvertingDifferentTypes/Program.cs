using System;
using System.Data.Common;
using System.IO;
using System.Net.Http;

namespace Exemplo059.ConvertingDifferentTypes
{
    /*  Existem vários tipos diferentes de conversões: 
     *  ■ Conversões implícitas:    Não permite syntax especial. 
     *                              Caso em compilador sabe que é seguro convertê-la 
     *  ■ Conversões explícitas:    Sempre precisa de alguma syntax especial.
     *                              Por segurança, o compilador protege de todas as 
     *                              conversãos implícitas que não são seguras.
     *                              Também chamada de "Casting".
     *  
     *  ■ Conversões definidas pelo usuário: Permite que usuário adicione suporte
     *                                       a conversões implícitas e explícitas   
     * 
     *  ■ Conversão com uma classe auxiliar:
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Ex 1 - Conversão implícita de int p/ double 
            // Ao contrário não é implicitamente possível
            int i = 42;
            double d = i;

            // Ex 2 - Conversão implícita de um tipo por referência p/ seus tipos base (base type).
            // O tipo por referência pode ser armazenado dentro de um objeto
            // porque, em última análise, cada "reference type" herda de um objeto
            HttpClient client = new HttpClient(); // HttpClient herda de um object
            object obj = client;
            IDisposable disp = client;

            // Ex 3 - Conversão explícita - Exemplo usando "casting" de um "double" p/ um "int"
            double x = 1234.7;
            int a;
            // Cast double to int
            a = (int)x; // a = 1234

            // Ex 4 - Conversão explícita - P/ tipos por referência
            // É possível ir de um tipo derivado para um tipo base (base type)
            Object stream = new MemoryStream();               // Converte MemoryStream p/ Object  
            MemoryStream memoryStream = (MemoryStream)stream; // Converte um Object p/ um MemoryStream
            Object stream2 = memoryStream;

            // Ex 5 - Conversões definidas pelo usuário (uso da classe Money)
            ExemploExplicitAndImplicitOperator.ExecutarExemplos();

            // Ex 6 - Conversões com Helper classes
            ExemploHelperClasses.ExecutarExemplos();


            // É possível usar os operadores "is" e "as" p/ verificar se 
            // um tipo pode ser convertido em outro de forma segura 
            // (reporta erro na declaração no VS e da erro de compilação caso não estej ok)
            // Também podem ser usados em "Nullable Types"
            
            // Ex 7 - Uso do "is"
            /*void OpenConnection(DbConnection connection)
            {
                if (connection is SqlConnection)        // Note o uso do "is"
                {
                    // run some special code
                }
            }
            */

            // Ex 8 - Uso dos operadores "is" e "as" p/ verificar se 
            void LogStream(Stream stream)
            {
                MemoryStream memoryStream = stream as MemoryStream; // Note o uso do "as"
                if (memoryStream != null)
                {
                    // ....
                }
            }
        }

       
    }
}
