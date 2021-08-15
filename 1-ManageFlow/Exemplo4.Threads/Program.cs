using System;
using System.Threading;

namespace Exemplo4.Threads
{
    /* ANOTAÇÕES:
        Um segmento também pode ter seus próprios dados que não são uma variável local. 
        Marcando um campo com o atributo ThreadStatic, cada thread obtém sua própria cópia de um campo
    */

    class Program
    {
        // Aplicação do atributo ThreadStatic para o field/property (
        // O atributo indica que o field estático é único para cada thread
        // Note que: Cada thread usa seu próprio field 
        // (Caso o atributo ThreadStatic seja removido as threads irão acessar o "mesmo field") 
        [ThreadStatic] 
        public static int _field;

        // OBS: Note que 

        static void Main(string[] args)
        {
            // Inicia thread A
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            // Inicia thread B
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
