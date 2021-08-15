using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exemplo067.Manage_The_Object_Life_Cycle
{
    public static class Exemplo3_IDisposableAndFinalizer
    {
    }

    // Exemplo implementa caso usando tanto o "IDisposable" quanto o "Finalizador"

    class UnmangedWrapper : IDisposable
    {
        public FileStream Stream { get; private set; }

        public UnmangedWrapper()
        {
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        // "Finalizer" somente chama o Dispose apenas passando false liberar
        ~UnmangedWrapper()
        {
            Dispose(false); 
        }

        public void Close()
        {
            Dispose();
        }

        // Este método regular
        public void Dispose()
        {
            Dispose(true);
            // Chama SuppressFinalize p/ garantir que o objeto seja removido da lista de 
            // finalização que o Garbage Collector está acompanhando.
            // A instância já foi executada, portanto, não é necessário que o GC chame o finalizador
            GC.SuppressFinalize(this);
        }

        // Verifica se está sendo chamado em um Dispose explícito
        // ou se está sendo chamado a partir do finalizador        
        public void Dispose(bool disposing)
        {
            /*  Se o finalizador chamar o Dispose, não é preciso fazer nada 
                porque o Stream também implementa um finalizador e o GC se encarrega 
                de chamar o finalizador do Stream. 
                Se o Dispose for chamado explicitamente, então podemos fechar o Stream.
            */

            if (disposing)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }
}
