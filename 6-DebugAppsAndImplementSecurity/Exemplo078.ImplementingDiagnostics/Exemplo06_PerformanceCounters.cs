using System;
using System.Diagnostics;

namespace Exemplo078.ImplementingDiagnostics
{
    public static class Exemplo06_PerformanceCounters
    {
        // Exemplo 1 - mostra como ler dados de Performance Counters (Ex. programa perfmon.exe no Windows)
        public static void ReadPerformanceCounters_ex1()
        {
            Console.WriteLine("Press escape key to stop");
            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
            {
                string text = "Available memory: ";
                Console.Write(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }

        // Exemplo 2 - mostra como criar os próprios contadores de desempenho
        // Pode ser útil p/ criar aplicativos de monitoramento (painéis e dashboards c/ dados do app e relacionados)
        public static void ReadPerformanceCounters_ex2()
        {

            if (CreatePerformanceCounters_ex2())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }
            var totalOperationsCounter = new PerformanceCounter("MyCategory", "# operations executed", "", false);
            var operationsPerSecondCounter = new PerformanceCounter("MyCategory", "# operations / sec", "", false);

        }

        private static bool CreatePerformanceCounters_ex2()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData(
                        "# operations executed",
                        "Total number of operations executed",
                        PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData(
                        "# operations / sec",
                        "Number of operations executed per second",
                        PerformanceCounterType.RateOfCountsPerSecond32)
                };

                PerformanceCounterCategory.Create("MyCategory", "Sample category for Codeproject", counters);

                return true;
            }

            return false;
        }
    }
}
