using Crypto;
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

        private TcpClient client;
        private NetworkStream ns;
        private byte[] aes;
        private byte[] aesIV;
        private Connection connection;

        private void Form1_Load(object sender, EventArgs e)
        {

            getSessionKeyButton.Enabled = false;
            generateRSAButton.Enabled = true;

            toggleLoginForm(false);

            /*
            bool connectionEndMessage = false;

            while (!connectionEndMessage)
            {
                var messageType = connection.ReceiveBytes(client, 4);
                var len = connection.ReceiveBytes(client, 4);

            }

            

            
            // 4 bytes contains message length
            // text length inside message

            var lenBytes = connection.ReceiveBytes(client, 4);
            var message = connection.ReceiveBytes(client, 128 + 128 + 4 + BitConverter.ToInt32(lenBytes, 0));

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
            */

        }

        private void ReceiveResponseFromServerAsync()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        var messageType = BitConverter.ToInt32(Connection.Receive(client, 4), 0);
                        var lenBytes = BitConverter.ToInt32(Connection.Receive(client, 4), 0);

                        byte[] bufferToRead = Connection.Receive(client, lenBytes);

                        if (messageType == TCPConnection.ENCRYPTED_AES_WITH_RSA)
                        {
                            aes = new byte[128];
                            Array.Copy(bufferToRead, 0, aes, 0, 128);
                            aes = connection.Decrypt(aes);

                            aesIV = new byte[128];
                            Array.Copy(bufferToRead, 128, aesIV, 0, 128);
                            aesIV = connection.Decrypt(aesIV);

                            Invoke((MethodInvoker)delegate
                            {
                                getSessionKeyButton.Enabled = false;
                            });
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
            });
        }

        private void SendMessage()
        {
            string somethingToSay = "hello from client";
            byte[] buffer = Encoding.UTF8.GetBytes(somethingToSay);
            Connection.Send(client, TCPConnection.PUBLIC_KEY, buffer);
        }

        private void getSessionKeyButton_Click(object sender, EventArgs e)
        {
            getSessionKeyButton.Enabled = false;

            client = new TcpClient();
            client.Connect("127.0.0.1", 9999);
            ns = client.GetStream();

            // Client send RSA public key to server
            connection.SendPublicKeyToServer(client);

            ReceiveResponseFromServerAsync();

            Connection.Send(client, TCPConnection.GET_SESSION_KEY, null);
            getSessionKeyButton.Enabled = false;

            

            toggleLoginForm(true);

            
        }

        private void generateRSAButton_Click(object sender, EventArgs e)
        {
            getSessionKeyButton.Enabled = true;
            generateRSAButton.Enabled = false;
            // RSA keys are generated inside
            connection = new Connection();
        }



        private void toggleLoginForm(bool toggle)
        {
            labelLogin.Visible = toggle;
            labelPassword.Visible = toggle;

            loginButton.Visible = toggle;

            textBoxLogin.Visible = toggle;
            textBoxPassword.Visible = toggle;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            SendLogin(client, login, password);
        }

        private void SendLogin(TcpClient client, string login, string password)
        {
            login = "anna";
            password = "123";
            byte[] loginEcnr = AES.Encrypt(Encoding.Default.GetBytes(login), aes, aesIV);
            byte[] passwordEcnr = AES.Encrypt(Encoding.Default.GetBytes(password), aes, aesIV);
            var loginLen = BitConverter.GetBytes(loginEcnr.Length);

            // 4 - for length of login
            var msg = new byte[4 + loginEcnr.Length + passwordEcnr.Length];

            Array.Copy(loginLen, 0, msg, 0, 4);
            Array.Copy(loginEcnr, 0, msg, 4, loginEcnr.Length);
            Array.Copy(passwordEcnr, 0, msg, 4 + loginEcnr.Length, passwordEcnr.Length);

            Connection.Send(client, TCPConnection.LOGIN, msg);
        }
    }

}
