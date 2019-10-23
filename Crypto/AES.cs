using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blocknote
{
    public class AES
    {
     public   AesCryptoServiceProvider rijndaelManaged;

        public void GenerateSessionKey()
        {
            rijndaelManaged = new AesCryptoServiceProvider();
            rijndaelManaged.GenerateKey();
            rijndaelManaged.GenerateIV();
            // rijndaelManaged.Mode = CipherMode.OFB;

        }

        public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CFB;
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                //aesAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static byte[] EncryptToBytesUsingCBC(string toEncrypt, byte[] Key, byte[] IV)
        {
            byte[] src = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] dest = new byte[src.Length];
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.IV = IV;
                aes.Key = Key;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.Zeros;
                // encryption
                using (ICryptoTransform encrypt = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    return encrypt.TransformFinalBlock(src, 0, src.Length);
                }
            }
        }

        public static byte[] Encrypt(byte[] plain, byte[] Key, byte[] IV)
        {
            byte[] encrypted; ;
            using (MemoryStream mstream = new MemoryStream())
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mstream,
                        aesProvider.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plain, 0, plain.Length);
                    }
                    encrypted = mstream.ToArray();
                }
            }
            return encrypted;
        }

        public static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CFB;
                //aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            //csDecrypt.Read(cipherText, 0, cipherText.Length);
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }

                    // plaintext = Encoding.UTF8.GetString(msDecrypt.ToArray());
                }

            }

            return plaintext;

        }

        public static byte[] Decrypt(byte[] encrypted, byte[] Key, byte[] IV)
        {
            byte[] plain;
            int count;
            using (MemoryStream mStream = new MemoryStream(encrypted))
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.Mode = CipherMode.CBC;
                    using (CryptoStream cryptoStream = new CryptoStream(mStream,
                     aesProvider.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        plain = new byte[encrypted.Length];
                        count = cryptoStream.Read(plain, 0, plain.Length);
                    }
                }
            }

            // My method was written quite some time ago, and I don't remember why we had to copy the Array
            // but I'm pretty sure that it's necessary
            byte[] returnval = new byte[count];
            Array.Copy(plain, returnval, count);
            return returnval;

        }
    }
}
