using System;

namespace Exemplo051.HandlingExceptions.ThrowingExceptions_
{
    /// <summary>
    /// Exemplo mostra casos de lançar ou relançar exceções
    /// </summary>
    class Program
    {
        /*  OPÇÕES p/ relançar a exceção:
            1) Usar a palavra-chave throw sem um identificador. 
            2) Usar a palavra-chave throw com a exceção original. 
            3) Usar a palavra-chave throw com uma nova exceção. 
    */

        static void Main(string[] args)
        {
            ExecutarExemplo1();
            ExecutarExemplo2();
            ExecutarExemplo3();
        }

        static void SomeOperation()
        {
            Console.WriteLine("Executa alguma operação");
            throw new Exception();
        }

        static void Log(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        /// <summary>
        /// Reproduz novamente a exceção sem modificar a pilha de chamadas. 
        /// Essa opção deve ser usada quando você não deseja modificações na exceção. 
        /// </summary>
        static void ExecutarExemplo1()
        {
            try
            {
                SomeOperation();
            }
            catch (Exception logEx)
            {
                Log(logEx);
                throw; // rethrow the original exception
            }
        }

        /// <summary>
        /// Redefine a pilha de chamadas para o local atual no código. 
        /// Portanto, você não pode ver de onde veio a exceção e 
        /// fica mais difícil depurar o erro
        /// </summary>
        static void ExecutarExemplo2()
        {
            try
            {
                SomeOperation();
            }
            catch (Exception logEx)
            {
                Log(logEx);
                throw logEx; // reseta a pilha e lança a exceção
            }
        }

        /// <summary>
        /// Pode ser útil quando queremos disparar outra exceção 
        /// para que está chamando o código corrente
        /// No exemplo OrderProcessingException é uma exceção customizada
        /// </summary>
        static void ExecutarExemplo3()
        {
           /*
           try
           {
               SomeOperation();
           }
           catch (MessageQueueException ex)  
           {
               throw new OrderProcessingException("Error while processing order", ex);
           }
           */

            // Para usuários que esperam alguma informação do processamento de pedidos
            // a exceção MessageQueueException não faz sentido e então no exemplo 
            // pode-se perder uma informação importante
        }
    }
}
