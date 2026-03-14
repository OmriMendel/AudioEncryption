using System;
using System.IO;
using System.Security.Cryptography;

namespace AudioEncryption
{
    internal class KeyHelper
    {
        public static void GenerateAndSaveKeys(string publicPath, string privatePath)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                string privateKeyXml = rsa.ToXmlString(true);
                File.WriteAllText(privatePath, privateKeyXml);

                string publicKeyXml = rsa.ToXmlString(false);
                File.WriteAllText(publicPath, publicKeyXml);
            }
        }


        public static RSA LoadKeyFromXml(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath))
                throw new FileNotFoundException("Key file not found: " + xmlFilePath);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string xmlString = File.ReadAllText(xmlFilePath);

            rsa.FromXmlString(xmlString);

            return rsa;
        }
    }
}