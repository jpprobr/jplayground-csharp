using System;
using System.Diagnostics;

namespace Exemplo078.ImplementingDiagnostics
{
    public static class Exemplo04_WritingDataEventLog
    {
        public static void GravarLog()
        {
            // Este exemplo mostra como gravar log no Event Log do Windows (requer permissões de administrador do SO)
            // As mensagens geradas podem ser vistas no Event Viewer do Windows (Visualizador de eventos)

            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Please restart application");
                Console.ReadKey();

                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "MySource";
            myLog.WriteEntry("Log event!");
        }

        public static void LerLogs()
        {
            EventLog log = new EventLog("MyNewLog");

            Console.WriteLine("Total entries: " + log.Entries.Count);
            EventLogEntry last = log.Entries[log.Entries.Count - 1];

            Console.WriteLine("Index:   " + last.Index);
            Console.WriteLine("Source:  " + last.Source);
            Console.WriteLine("Type:    " + last.EntryType);
            Console.WriteLine("Time:    " + last.TimeWritten);
            Console.WriteLine("Message: " + last.Message);
        }


        public static void GravarLogsComSubscribe()
        {
            EventLog applicationLog = new EventLog("Application", ".", "testEventLogEvent");
            
            // EntryWritten pode ser usado p/ "assinar" p/ capturar as alterações do Event Log
            applicationLog.EntryWritten += (sender, e) =>
            {
                Console.WriteLine(e.Entry.Message);
            };
            applicationLog.EnableRaisingEvents = true;
            applicationLog.WriteEntry("Test message", EventLogEntryType.Information);

            Console.ReadKey();
        }
    }
}
