using Blocknote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static RSAParameters GetPublicKeyFromClient(NetworkStream ns)
        {
            var msg = new byte[1024];

            ns.Read(msg, 0, msg.Length);
            ns.Write(msg, 0, msg.Length);

            var response = Encoding.Default.GetString(msg);

            return Serializer.DeserializeKey(response);
        }

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                NetworkStream ns = client.GetStream();

                var publicKey = GetPublicKeyFromClient(ns);
                
                ns.Close();
                client.Dispose();

            }
            

        }
    }
}
