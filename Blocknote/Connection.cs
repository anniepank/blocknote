using Crypto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blocknote
{
    public class Connection
    {
        private RSAParameters publicKey;
        private RSAParameters privateKey;
        private RSACryptoServiceProvider cryptoServiceProvider;
        public int RSAKeySize = 1024;
        private TcpClient client;

        public Connection(TcpClient client)
        {
            this.client = client;
            cryptoServiceProvider = new RSACryptoServiceProvider();

            privateKey = cryptoServiceProvider.ExportParameters(true);
            publicKey = cryptoServiceProvider.ExportParameters(false);

        }

        public byte[] Decrypt(byte[] message)
        {
            return cryptoServiceProvider.Decrypt(message, false);
        }

        public string SerializePublicKey()
        {
            return Serializer.SerializeKey(publicKey);
        }

        public void SendPublicKeyToServer(TcpClient client) 
        {
            var serializedKey = Encoding.Default.GetBytes(SerializePublicKey());
            Send(client, TCPConnection.PUBLIC_KEY, serializedKey);
        }

        public void SendTextName(TcpClient client, string name)
        {
            var msg = Encoding.Default.GetBytes(name);
            Send(client, TCPConnection.FILE_NAME_HEADER, msg);
        }

        public static byte[] Receive(TcpClient client, int length)
        {
            Console.WriteLine("Read: " + length);
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

            if (msg == null)
            {
                Console.WriteLine("Write: 4");
                Console.WriteLine("Write: 4");
                client.GetStream().Write(BitConverter.GetBytes(messageType), 0, 4);
                client.GetStream().Write(BitConverter.GetBytes(0), 0, 4);
            }

            if (messageType != TCPConnection.GET_SESSION_KEY)
            {
                client.GetStream().Write(BitConverter.GetBytes(messageType), 0, 4);
                Console.WriteLine("Write: 4");
                client.GetStream().Write(BitConverter.GetBytes(msg.Length), 0, 4);
                Console.WriteLine("Write: " + msg.Length);
                client.GetStream().Write(msg, 0, msg.Length);
            }

        }

    }
}
