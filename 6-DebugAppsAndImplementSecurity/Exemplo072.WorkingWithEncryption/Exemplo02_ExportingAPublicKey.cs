using System;
using System.Security.Cryptography;

namespace Exemplo072.WorkingWithEncryption
{
    public static class Exemplo02_ExportingAPublicKey
    {
        public static void ExecutarExemplo()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            Console.WriteLine("\n publicKeyXML: {0}:", publicKeyXML);
            Console.WriteLine("\n privateKeyXML: {0}", privateKeyXML);
        }
    }
}
