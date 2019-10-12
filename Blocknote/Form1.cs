using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blocknote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] Receive(TcpClient client, int length)
        {
            var message = new byte[length];
            int read = 0;
            while (read < message.Length)
            {
                read += client.GetStream().Read(message, read, message.Length - read);
            }

            return message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            // establishing connection with server
            var client = new TcpClient();
            client.Connect("127.0.0.1", 9999);

            var connection = new Connection(client);

            connection.SendPublicKeyToServer();

            // 4 bytes contains message length
            // text length inside message
            var lenBytes = Receive(client, 4);
            var message = Receive(client, 128 + 128 + 4 + BitConverter.ToInt32(lenBytes, 0));

            var aesKey = new byte[128];
            Array.Copy(message, 0, aesKey, 0, 128);
            var decryptedAesKey = connection.Decrypt(aesKey);


            var aesIV = new byte[128];
            Array.Copy(message, 128, aesIV, 0, 128);
            var decryptedAesIV = connection.Decrypt(aesIV);

            var stringLen = BitConverter.ToInt32(message, 128 + 128);

            var cipheredByAes = new byte[128];
            Array.Copy(message, 128 + 128 + 4, cipheredByAes, 0, message.Length - 128 - 128 - 4);

            string decryptedCipher = AES.DecryptStringFromBytes(cipheredByAes, decryptedAesKey, decryptedAesIV);
            decryptedCipher = decryptedCipher.Substring(0, stringLen);

            serverMessageLabel.Text = decryptedCipher;
            connection.SendTextName("simple.txt");

            client.Dispose();

        }
    }
}
