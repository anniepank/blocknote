using Blocknote;
using Crypto;
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
        private static TcpListener server;
        private static NetworkStream ns;
        private static TcpClient client;
       // private static AES aes;
        private static RSACryptoServiceProvider rsa;

        public static RijndaelManaged myRijndael;



        private static RSACryptoServiceProvider GetPublicKeyFromClient(TcpClient client, int len)
        {
            var msg = Receive(client, len);
            RSAParameters publicKey = Serializer.DeserializeKey(Encoding.Default.GetString(msg));
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(publicKey);

            return rsa;
        }
        /*
        public static string GetTextNameFromClient(TcpClient client, NetworkStream ns)
        {
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = ns.Read(buffer, 0, client.ReceiveBufferSize);

            return Encoding.Default.GetString(buffer, 0, bytesRead);
        }
        */

        public static byte[] Receive(TcpClient client, int length)
        {
            Console.Write("Read: " + length);
            var message = new byte[length];
            int read = 0;
            while (read < message.Length)
            {
                read += client.GetStream().Read(message, read, message.Length - read);
            }

            return message;
        }

        public static void Send(TcpClient client, int messageType, byte[] msg)
        {
            Console.Write("Send:" + 4);
            Console.Write("Send:" + 4);
            Console.Write("Send:" + msg.Length);
            client.GetStream().Write(BitConverter.GetBytes(messageType), 0, 4);
            client.GetStream().Write(BitConverter.GetBytes(msg.Length), 0, 4);
            client.GetStream().Write(msg, 0, msg.Length);
        }


        private static void ResponseToClient()
        {
            while (true)
            {

                if (ns != null && ns.CanWrite)
                {
                    Send(client, TCPConnection.ENCRYPTED_AES_WITH_RSA, Encoding.UTF8.GetBytes("encrypted key from server"));
                }
            }
        }


        public static AES GenerateSessionKey()
        {
            AES aes = new AES();
            aes.GenerateSessionKey();
            return aes;
        }

        public static void SendEcryptedSessionKey(AES aes)
        {
            var encr = rsa.Encrypt(aes.rijndaelManaged.Key, false);
            var encrIV = rsa.Encrypt(aes.rijndaelManaged.IV, false);

            var msg = new byte[encr.Length + encrIV.Length];
            Array.Copy(encr, 0, msg, 0, encr.Length);
            Array.Copy(encrIV, 0, msg, encr.Length, encrIV.Length);

            Send(client, TCPConnection.ENCRYPTED_AES_WITH_RSA, msg);
        }

        static void Main(string[] args)
        {


            var original = "abs";
            /*
                byte[] encrypted = AES.EncryptStringToBytes(original, aes.rijndaelManaged.Key, aes.rijndaelManaged.IV);

            // Decrypt the bytes to a string.
            string roundtrip = AES.DecryptStringFromBytes(encrypted, aes.rijndaelManaged.Key, aes.rijndaelManaged.IV);

            //Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);
            */

            server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            while (true)
            {
                client = server.AcceptTcpClient();

                ns = client.GetStream();


                Task.Factory.StartNew(() =>
                {
                    AES aes;
                    while (true)
                    {
                        int messageType;
                        try
                        {
                            messageType = BitConverter.ToInt32(Receive(client, 4), 0);
                        }
                        catch (IOException e)
                        {
                            break;
                        }


                        if (messageType == TCPConnection.GET_SESSION_KEY)
                        {
                            var lenBytes = BitConverter.ToInt32(Receive(client, 4), 0);
                            aes = GenerateSessionKey();
                            SendEcryptedSessionKey(aes);
                        }

                        if (messageType == TCPConnection.PUBLIC_KEY)
                        {
                            var lenBytes = BitConverter.ToInt32(Receive(client, 4), 0);
                            rsa = GetPublicKeyFromClient(client, lenBytes);
                        }


                        /*
                        if (messageType != TCPConnection.GET_SESSION_KEY)
                        {
                            var lenBytes = BitConverter.ToInt32(Receive(client, 4), 0);

                            byte[] bufferToRead = Receive(client, lenBytes);

                            if (lenBytes > 0)
                            {
                                string result = Encoding.UTF8.GetString(bufferToRead);

                                Console.WriteLine(result.Trim());
                            }
                        }*/
                    }
                });


                /*
                bool connectionEnd = false;
                while (!connectionEnd)
                {


                }

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
                */

            }


        }
    }
}