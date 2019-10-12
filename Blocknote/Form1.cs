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

        private void Form1_Load(object sender, EventArgs e)
        {
            var formManager = new FormManager();
            formManager.generateRSAKeys();


            // establishing connection with server
            var client = new TcpClient();
            client.Connect("127.0.0.1", 9999);
            var ns = client.GetStream();

            formManager.SendPublicKeyToServer(ns);

            Thread.Sleep(1000); 

            // reading response from server
            byte[] serverResponse = new byte[1024];
            ns.Read(serverResponse, 0, serverResponse.Length);
            var serverResponseString = Encoding.Default.GetString(serverResponse);
            

            serverMessageLabel.Text = Encoding.Default.GetString(serverResponse);

            

            ns.Close();
            client.Dispose();

        }
    }
}
