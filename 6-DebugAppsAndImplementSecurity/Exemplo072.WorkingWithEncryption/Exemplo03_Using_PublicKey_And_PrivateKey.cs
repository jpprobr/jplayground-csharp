using System;
using System.Security.Cryptography;
using System.Text;

namespace Exemplo072.WorkingWithEncryption
{
    public static class Exemplo03_Using_PublicKey_And_PrivateKey
    {

        public static void ExecutarExemplo()
        {
            // Gera as 2 chaves (1 publica e 1 privada)
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            // Converte dados p/ uma sequência de bytes
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");
            
            // Criptografa dados (em bytes) 
            // Note que neste caso é necessário somente a chave pública
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                // Seta chave pública p/ adicionar 
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }

            // Descriptografa dados com a chave privada
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }

            // Obtem dados descriptografados p/ imprimir na tela
            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!
        }
    }
}
