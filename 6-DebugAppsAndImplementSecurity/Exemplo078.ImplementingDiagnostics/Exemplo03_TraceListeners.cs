using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Exemplo078.ImplementingDiagnostics
{
    public static class Exemplo03_TraceListeners
    {
        // As classes TraceSource e Debug usam um "listener default" => DefaultTraceListener
        // P/ alterar isso é possível limpar o default e configurar outros "listeners"

        public static void ExecutarExemplo()
        {
            Stream outputFile = File.Create("tracefile.txt");
            TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile);
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            
            traceSource.Listeners.Clear();                  // Remove o listener default
            traceSource.Listeners.Add(textListener);        // Adiciona o listener criado "textListenter"
            traceSource.TraceInformation("Trace output");   // Grava informação de trace 
            traceSource.Flush();
            traceSource.Close();

        }
    }
}
