namespace Blocknote
{
    partial class QRCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.qr = new System.Windows.Forms.PictureBox();
            this.passwordFromQR = new System.Windows.Forms.TextBox();
            this.passwordQR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "QR Code";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // qr
            // 
            this.qr.Location = new System.Drawing.Point(76, 60);
            this.qr.Name = "qr";
            this.qr.Size = new System.Drawing.Size(248, 239);
            this.qr.TabIndex = 1;
            this.qr.TabStop = false;
            // 
            // passwordFromQR
            // 
            this.passwordFromQR.Location = new System.Drawing.Point(76, 331);
            this.passwordFromQR.Name = "passwordFromQR";
            this.passwordFromQR.Size = new System.Drawing.Size(248, 20);
            this.passwordFromQR.TabIndex = 2;
            this.passwordFromQR.TextChanged += new System.EventHandler(this.passwordFromQR_TextChanged);
            // 
            // passwordQR
            // 
            this.passwordQR.Location = new System.Drawing.Point(249, 382);
            this.passwordQR.Name = "passwordQR";
            this.passwordQR.Size = new System.Drawing.Size(75, 23);
            this.passwordQR.TabIndex = 3;
            this.passwordQR.Text = "Send";
            this.passwordQR.UseVisualStyleBackColor = true;
            this.passwordQR.Click += new System.EventHandler(this.passwordQR_Click);
            // 
            // QRCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 428);
            this.Controls.Add(this.passwordQR);
            this.Controls.Add(this.passwordFromQR);
            this.Controls.Add(this.qr);
            this.Controls.Add(this.label1);
            this.Name = "QRCodeForm";
            this.Text = "QRCode";
            ((System.ComponentModel.ISupportInitialize)(this.qr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox qr;
        private System.Windows.Forms.TextBox passwordFromQR;
        private System.Windows.Forms.Button passwordQR;
    }
}