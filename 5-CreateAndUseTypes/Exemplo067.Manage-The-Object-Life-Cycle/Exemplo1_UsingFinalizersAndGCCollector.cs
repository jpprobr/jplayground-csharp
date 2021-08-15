using System;
using System.IO;

namespace Exemplo067.Manage_The_Object_Life_Cycle
{
    // Exemplo mostra usa de "finalizers" e do métod Collect() do Garbage Collector

    public static class Exemplo1_UsingFinalizersAndGCCollector
    {
        
    }


    // Exemplo de como adicionar um "finalizer"
    public class SomeType
    {
        ~SomeType()
        {
            // Esse código é chamado quando o método "finalize" é executado
            // É chamado somente quando ocorre uma "coleta de lixo" pelo "Garbage Collector"
            // O "finalizador" também aumenta o tempo de vida do objeto
            // pois o código de finalização também precisa ser executado
            // .NET Framework mantém uma referência para o objeto em uma fila especial de finalização
            // Uma thread adicional roda todas os finalizadores em um momento apropriado da execução
        }
    }

    // Podemos adicionar outros recursos e garantir que toda a memória seja liberada
    public class SomeType2
    {
        public void DoSomething()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            File.Delete("temp.dat");    // Throws an IOException because the file is already open.

            // Executar este método sem antes remover do coletor de lixo (sem as 2 linhas seguintes), 
            // irá ocasionar uma exceção porque o arquivo ainda estará aberto (mantendo uma referência no HEAP)
        }

        public void DoSomethingWithForceCollectByGC()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");

            // Força uma imediata coleta de lixo em todas as gerações (0 até N)            
            GC.Collect();
            GC.WaitForPendingFinalizers();

            File.Delete("temp.dat");
        }
    }
}
