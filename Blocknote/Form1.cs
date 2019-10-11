using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            var client = new TcpClient();
            client.Connect("127.0.0.1", 9999);

            var ns = client.GetStream();

            var msg = Encoding.Default.GetBytes("hello from client");
            ns.Write(msg, 0, msg.Length);

            Thread.Sleep(1000);

            byte[] serverMessage = new byte[128];
            ns.Read(serverMessage, 0, serverMessage.Length);

            serverMessageLabel.Text = Encoding.Default.GetString(serverMessage);
            

            ns.Close();
            client.Dispose();

        }
    }
}
