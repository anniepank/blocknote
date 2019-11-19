using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blocknote
{
    public partial class QRCodeForm : Form
    {
        public string Password;
        public Image QRPic
        {
            get
            {
                return this.qr.Image;
            }
            set
            {
                this.qr.Image = value;
            }
        }

        public QRCodeForm()
        {
            InitializeComponent();
        }

        private void passwordFromQR_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
