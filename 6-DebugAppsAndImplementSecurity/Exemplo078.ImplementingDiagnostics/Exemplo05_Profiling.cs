using System;
using System.Text;
using System.Diagnostics;

namespace Exemplo078.ImplementingDiagnostics
{
    public static class Exemplo05_Profiling
    {
        const int numberOfIterations = 100000;

        public static void ExecutarExemplo()
        {
            // Exemplo de uso da Classe StopWatch p/ medir o tempo de execução de algum código
            
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Algorithm1();
            sw.Stop();
            Console.WriteLine("Algoritmo 1: {0}", sw.Elapsed); // exibe tempo decorrido

            sw.Reset();
            sw.Start();
            Algorithm2();
            sw.Stop();
            Console.WriteLine("Algoritmo 2: {0}", sw.Elapsed);


            Console.WriteLine("Ready…");
            Console.ReadLine();
        }

        private static void Algorithm1()
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < numberOfIterations; x++)
            {
                sb.Append('a');
            }
            string result = sb.ToString();
        }

        private static void Algorithm2()
        {
            string result = "";
            for (int x = 0; x < numberOfIterations; x++)
            {
                result += 'a';
            }
        }
      
    }
}
