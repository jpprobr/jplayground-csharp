using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exemplo078.ImplementingDiagnostics
{
    public static class Exemplo01_ClasseDebug
    {
        public static void ExecutarExemplo()
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }
    }
}
