using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blocknote
{
    class Connection
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

        public void SendPublicKeyToServer() 
        {
            var serializedKey = Encoding.Default.GetBytes(SerializePublicKey());
            Send(serializedKey);
        }

        public void SendTextName(string name)
        {
            var msg = Encoding.Default.GetBytes(name);
            Send(msg);
        }

        public void Send(byte[] msg)
        {
            client.GetStream().Write(msg, 0, msg.Length);
        }

    }
}
