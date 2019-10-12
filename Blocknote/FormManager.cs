using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blocknote
{
    class FormManager
    {
        public RSAParameters publicKey;
        private RSAParameters privateKey;
        private RSACryptoServiceProvider cryptoServiceProvider;
        public int RSAKeySize = 1024;
        public FormManager()
        {

        }

        public void generateRSAKeys()
        {
            cryptoServiceProvider = new RSACryptoServiceProvider();

            privateKey = cryptoServiceProvider.ExportParameters(true);
            publicKey = cryptoServiceProvider.ExportParameters(false);

            var pks = Serializer.SerializeKey(publicKey);
            var dpk = Serializer.DeserializeKey(pks);
            Console.Write(dpk.Equals(publicKey));

        }

        public string SerializePublicKey()
        {
            return Serializer.SerializeKey(publicKey);
        }

        public void SendPublicKeyToServer(NetworkStream ns) 
        {
            var serializedKey = Encoding.Default.GetBytes(SerializePublicKey());
            ns.Write(serializedKey, 0, serializedKey.Length);
        }

    }
}
