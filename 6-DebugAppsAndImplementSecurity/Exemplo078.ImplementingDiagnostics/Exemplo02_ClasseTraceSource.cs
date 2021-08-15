using System.Diagnostics;

namespace Exemplo078.ImplementingDiagnostics
{
    public static class Exemplo02_ClasseTraceSource
    {
        public static void ExecutarExemplo()
        {
            // Exemplo do uso da classe TraceSource
            // Note uso dos tipos de "TraceEvent"          
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();


            /* OPÇÕES do Enum TraceEventType:
            
            ■ CRITICAL: Essa é a opção mais grave. Deve ser usado com moderação e apenas para erros muito graves e irrecuperáveis. 
            
            ■ ERROR: Este membro da enumeração tem uma prioridade um pouco menor que a crítica, mas ainda indica que algo está errado
              no aplicativo. Normalmente, ele deve ser usado para sinalizar um problema que foi tratado ou recuperado. 
            
            ■ WARNING: Este valor indica que ocorreu algo incomum que pode valer a pena investigar mais. 
              Por exemplo, você percebe que uma determinada operação demora subitamente a processar mais do que o normal ou 
              sinaliza um aviso de que o servidor está com pouca memória. 
              
            ■ INFORMATION: Este valor indica que o processo está sendo executado corretamente, mas há algumas informações 
              interessantes a serem incluídas no arquivo de saída de rastreamento. 
              Pode ser uma informação de que um usuário fez logon em um sistema ou que algo foi adicionado ao banco de dados. 

            ■ VERBOSE: Esse é o valor mais baixo de todos os valores relacionados à gravidade na enumeração. 
              Ele deve ser usado para informações que não indicam nada de errado com o aplicativo e provavelmente aparecerão 
              em grandes quantidades. Por exemplo, ao instrumentar todos os métodos em um tipo para rastrear seu início e final, 
              é comum usar o tipo de evento detalhado. 
              
            ■ STOP, START, SUSPEND, RESUME, TRANSFER:  Esses tipos de eventos não são indicações de gravidade, 
              mas marcam o evento de rastreamento como relacionado ao fluxo lógico do aplicativo. 
              Eles são conhecidos como tipos de eventos de atividade e marcam o início ou a parada de uma operação lógica ou a 
              transferência de controle para outra operação lógica.
            */
        }
    }
}
