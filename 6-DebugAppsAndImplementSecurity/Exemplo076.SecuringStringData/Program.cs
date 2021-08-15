using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Exemplo076.SecuringStringData
{
    /*  - Um SecureString criptografa automaticamente seu valor, 
          diminuindo a possibilidade de um invasor encontrar uma versão em texto 
          sem formatação da string. 
        - Um SecureString também é fixado em um local de memória específico.
        - O Garbage collector não move em volta da string, assim evita-se o problema 
          de ter várias cópias. 
        - SecureString é uma sequência mutável que pode ser feita somente leitura 
          quando necessário. 
        - Por fim, o SecureString implementa o IDisposable para garantir que seu conteúdo 
          seja removido da memória sempre que terminar de usa-lo.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        void TestingSecureString()
        {
            // O aplicativo lê um caractere de cada vez do usuário 
            // e anexa esses caracteres ao SecureString.
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    
                    if (cki.Key == ConsoleKey.Enter) 
                        break;
                    
                    ss.AppendChar(cki.KeyChar);
                    
                    Console.Write("*");
                }
                ss.MakeReadOnly();
            }

        }


        public static void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
