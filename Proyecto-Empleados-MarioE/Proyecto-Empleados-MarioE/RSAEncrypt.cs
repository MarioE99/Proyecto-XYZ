namespace Proyecto_Empleados_MarioE
{
    using System.Security.Cryptography;
    using System.IO;
    public class RSAEncrypt
    {

        public static void GenerateKeys(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = RSA.Create())
            {
                var publicKey = rsa.ToXmlString(false); // Obtener solo la clave pública
                var privateKey = rsa.ToXmlString(true); // Obtener la clave privada

                File.WriteAllText(publicKeyPath, publicKey);
                File.WriteAllText(privateKeyPath, privateKey);
            }
        }

        public static string Encrypt(string plainText, string publicKeyPath)
        {
            using (var rsa = RSA.Create())
            {
                var publicKey = File.ReadAllText(publicKeyPath);
                rsa.FromXmlString(publicKey);

                var data = System.Text.Encoding.UTF8.GetBytes(plainText);
                var encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);

                return Convert.ToBase64String(encryptedData);
            }
        }

        public static string Decrypt(string encryptedText, string privateKeyPath)
        {
            using (var rsa = RSA.Create())
            {
                var privateKey = File.ReadAllText(privateKeyPath);
                rsa.FromXmlString(privateKey);

                var data = Convert.FromBase64String(encryptedText);
                var decryptedData = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);

                return System.Text.Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}
