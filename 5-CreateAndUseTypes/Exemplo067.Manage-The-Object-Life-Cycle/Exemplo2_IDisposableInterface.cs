using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exemplo067.Manage_The_Object_Life_Cycle
{

    public static class Exemplo2_IDisposableInterface
    {
    }

    public class Exemplo2
    {
        // Exemplo mostra o uso do Dispose
        // Libera recursos não gerenciados imediatamente, porém desta forma 
        // pode ocorrer uma exceção antes da chamada do Dispose ser chamado 
        // e o recurso não ser liberado
        public void DoSomething1()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");            
            stream.Dispose();
            File.Delete("temp.dat");
        }

        // Mostra uso do mesmo caso do método anterior, porém com o uso do try/finally
        // para garantir que o método Dispose() seja executado e o objeto seja liberado
        public void DoSomething2()
        {
            StreamWriter sw = File.CreateText("temp.dat");

            try
            {
                sw.Write("some data");
                File.Delete("temp.dat");
            }
            finally
            {
                sw.Dispose();
            }
        }

        // Consegue o mesmo resultado que o exemplo anterior, porém com o uso do "using"
        // O "using" é traduzido pelo compilador como um try/finally que chama o Dispose() no objeto
        // Por isso, a expressão "using" pode ser usada somente com tipos que implementam IDisposable
        public void DoSomething3()
        {
            using (StreamWriter sw = File.CreateText("temp.dat"))
            {
                sw.Write("some data");
                File.Delete("temp.dat");
            }
        }
    }
}
