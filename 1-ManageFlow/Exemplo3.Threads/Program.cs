using System;
using System.Threading;

namespace Exemplo3.Threads
{
    /* ANOTAÇÕES 
     - Pode ser usado o método Thread.Abort(), mas como este método é usado por outro thread, 
       isso pode abortar a qualquer momento. Quando isso ocorre  é lançado a exceção ThreadAbort Exception.
       Isso pode levar uma corrupção no estado e deixar o aplicativo inutilizável.
       Portanto a melhor maneira de para uma thread é usar uma variável compartilhada 
       que ambas as threads possam acessar
    */

    class Program
    {
        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: { 0}", i);
                Thread.Sleep(0);
            }
        }


        static void Main(string[] args)
        {
            bool stopped = false; // variável p/ flag de parada

            // Inicialização de thread através de expressão lambda que representa 
            // uma versão abreviada de um delegate
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Executando...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();

            Console.WriteLine("Pressione alguma tecla para continuar!");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }
    }
}
