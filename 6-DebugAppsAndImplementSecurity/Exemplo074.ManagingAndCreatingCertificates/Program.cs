using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Exemplo074.ManagingAndCreatingCertificates
{
    /* Exemplos de comando (BAT/CMD/Shell) 
       
        Exemplo de comando (BAT/CMD/Shell) p/ gerar certificado
        => CMD: makecert testCert.cer

        Exemplo de comando p/ criar e instalar um certificado customizado
        em uma "Certificate Store" personalizado
        => makecert - n "CN = WouterDeKort" -sr currentuser - ss testCertStore
    */

    // Exemplo mostra como usar este certificado gerado para assinar e verificar um texto. 
    // Os dados são divididos em hash e depois assinados. 
    // Ao verificar, o mesmo algoritmo de hash é usado para garantir que os dados 
    // não sejam alterados.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando certificado gerado...");
            SignAndVerify();
        }

        // Assinar (gerar assinatura) e validar certificado
        public static void SignAndVerify()
        {
            string textToSign = "Test paragraph";

            // Assina
            byte[] signature = Sign(textToSign, "cn = WouterDeKort");

            // Verifica
            var resultVerify = Verify(textToSign, signature);

            // Remova o comentário desta linha p/ fazer que a etapa de verificação falhe
            // signature[0] = 0;
            Console.WriteLine("\n {0}", resultVerify);
        }

        // Assinar certificado a partir de texto e assunto em questão
        static byte[] Sign(string text, string certSubject)
        {
            X509Certificate2 cert = GetCertificate();
            
            // Obtem chave privada
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            
            // Obtem hash de dados gerado
            byte[] hash = HashData(text);
            
            // Usa chave privada do certificado p/ criar assinatura p/ dados
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        // Verificar baseado no texto e na assinatura 
        static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();

            // Obtem chave pública
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            
            // Obtem hash de dados
            byte[] hash = HashData(text);

            // Usa chave pública do certificado p/ verificar se dados foram alterados
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        // Gera e retorna Hash de dados (no caso do texto informado)
        private static byte[] HashData(string text)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }

        // Obtem certificado no padrão X.509
        private static X509Certificate2 GetCertificate()
        {
            X509Store myStore = new X509Store("testCertStore", StoreLocation.CurrentUser);
            myStore.Open(OpenFlags.ReadOnly);
            var certificate = myStore.Certificates[0];
            return certificate;
        }
    }
}
