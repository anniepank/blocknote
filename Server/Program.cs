using Blocknote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static RijndaelManaged myRijndael;

        public static RSAParameters GetPublicKeyFromClient(NetworkStream ns)
        {
            var msg = new byte[1024];

            ns.Read(msg, 0, msg.Length);

            var response = Encoding.Default.GetString(msg);

            return Serializer.DeserializeKey(response);
        }

        public static string GetTextNameFromClient(TcpClient client, NetworkStream ns)
        {
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = ns.Read(buffer, 0, client.ReceiveBufferSize);

            return Encoding.Default.GetString(buffer, 0, bytesRead);
        }

        static void Main(string[] args)
        {
            var aes = new AES();
            aes.GenerateSessionKey();

            var original = "abs";
            byte[] encrypted = AES.EncryptStringToBytes(original, aes.rijndaelManaged.Key, aes.rijndaelManaged.IV);

            // Decrypt the bytes to a string.
            string roundtrip = AES.DecryptStringFromBytes(encrypted, aes.rijndaelManaged.Key, aes.rijndaelManaged.IV);

            //Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);

            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                NetworkStream ns = client.GetStream();

                // getting public RSA key from client
                RSAParameters publicKey = GetPublicKeyFromClient(ns);
                var rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(publicKey);

                var encr = rsa.Encrypt(aes.rijndaelManaged.Key, false);
                var encrIV = rsa.Encrypt(aes.rijndaelManaged.IV, false);

                original = "abc";
                encrypted = AES.EncryptStringToBytes(original, aes.rijndaelManaged.Key, aes.rijndaelManaged.IV);

                var lenBytes = BitConverter.GetBytes(encrypted.Length);
                var stringLenBytes = BitConverter.GetBytes(original.Length);
                ns.Write(lenBytes, 0, lenBytes.Length);
                ns.Write(encr, 0, encr.Length);
                ns.Write(encrIV, 0, encrIV.Length);
                ns.Write(stringLenBytes, 0, stringLenBytes.Length);
                ns.Write(encrypted, 0, encrypted.Length);
                
                // var textName = GetTextNameFromClient(client, ns);

                Thread.Sleep(20000);

                ns.Close();
                client.Dispose();

            }
            

        }
    }
}
