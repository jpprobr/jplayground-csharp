using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exemplo16.Threads.Tasks.AsyncANDAwait
{
    /// <summary>
    /// Exemplo mostra uso do ASYNC e AWAIT
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result.Substring(0, 50));
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                // Método GetStringAsync retorna um Task<string> para o chamador
                // que terminará quando os dados forem recuperados. 
                // Enquanto isso, a thread principal pode fazer outro trabalho
                Console.WriteLine("Preparando download de conteúdo... ");
                string result = await client.GetStringAsync("http://www.microsoft.com");
                
                Console.WriteLine("**************Outro trabalho*****************");
                return result;
            }
        }
    }
}
