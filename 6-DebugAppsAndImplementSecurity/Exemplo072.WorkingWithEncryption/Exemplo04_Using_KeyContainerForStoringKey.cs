using System.Security.Cryptography;
using System.Text;

namespace Exemplo072.WorkingWithEncryption
{
    class Exemplo04_Using_KeyContainerForStoringKey
    {
        public static void ExecutarExemplo()
        {
            // Converte dados p/ uma sequência de bytes
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");


            string containerName = "SecretContainer";
            CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            byte[] encryptedData;

            // RSACryptoServiceProvider pode ser configurado p/ usar um container de chaves
            // 
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            {
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
        }
    }
}
