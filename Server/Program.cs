using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                var hello = Encoding.Default.GetBytes("hello world");
                NetworkStream ns = client.GetStream();
                ns.Write(hello, 0, hello.Length);

                var msg = new byte[128];
                ns.Read(msg, 0, msg.Length);
                ns.Write(msg, 0, msg.Length);

                var response = Encoding.Default.GetString(msg);

                Console.WriteLine(response);

                ns.Close();
                client.Dispose();

            }
            

        }
    }
}
