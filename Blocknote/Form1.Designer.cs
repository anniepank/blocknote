namespace Blocknote
{
    partial class Form1
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
            this.serverMessageLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.serverResponse = new System.Windows.Forms.Label();
            this.serverText = new System.Windows.Forms.TextBox();
            this.getSessionKeyButton = new System.Windows.Forms.Button();
            this.generateRSAButton = new System.Windows.Forms.Button();
            this.connectToServerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverMessageLabel
            // 
            this.serverMessageLabel.AutoSize = true;
            this.serverMessageLabel.Location = new System.Drawing.Point(283, 38);
            this.serverMessageLabel.Name = "serverMessageLabel";
            this.serverMessageLabel.Size = new System.Drawing.Size(133, 20);
            this.serverMessageLabel.TabIndex = 0;
            this.serverMessageLabel.Text = "Server responses";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serverResponse
            // 
            this.serverResponse.AutoSize = true;
            this.serverResponse.Location = new System.Drawing.Point(403, 87);
            this.serverResponse.Name = "serverResponse";
            this.serverResponse.Size = new System.Drawing.Size(51, 20);
            this.serverResponse.TabIndex = 2;
            this.serverResponse.Text = "label1";
            this.serverResponse.Click += new System.EventHandler(this.label1_Click);
            // 
            // serverText
            // 
            this.serverText.Location = new System.Drawing.Point(407, 130);
            this.serverText.Name = "serverText";
            this.serverText.Size = new System.Drawing.Size(100, 26);
            this.serverText.TabIndex = 3;
            // 
            // getSessionKeyButton
            // 
            this.getSessionKeyButton.Location = new System.Drawing.Point(42, 26);
            this.getSessionKeyButton.Name = "getSessionKeyButton";
            this.getSessionKeyButton.Size = new System.Drawing.Size(177, 48);
            this.getSessionKeyButton.TabIndex = 4;
            this.getSessionKeyButton.Text = "Get AES";
            this.getSessionKeyButton.UseVisualStyleBackColor = true;
            this.getSessionKeyButton.Click += new System.EventHandler(this.getSessionKeyButton_Click);
            // 
            // generateRSAButton
            // 
            this.generateRSAButton.Location = new System.Drawing.Point(42, 107);
            this.generateRSAButton.Name = "generateRSAButton";
            this.generateRSAButton.Size = new System.Drawing.Size(177, 49);
            this.generateRSAButton.TabIndex = 5;
            this.generateRSAButton.Text = "Generate RSA";
            this.generateRSAButton.UseVisualStyleBackColor = true;
            this.generateRSAButton.Click += new System.EventHandler(this.generateRSAButton_Click);
            // 
            // connectToServerButton
            // 
            this.connectToServerButton.Location = new System.Drawing.Point(42, 184);
            this.connectToServerButton.Name = "connectToServerButton";
            this.connectToServerButton.Size = new System.Drawing.Size(177, 51);
            this.connectToServerButton.TabIndex = 6;
            this.connectToServerButton.Text = "Connect to server";
            this.connectToServerButton.UseVisualStyleBackColor = true;
            this.connectToServerButton.Click += new System.EventHandler(this.connectToServerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectToServerButton);
            this.Controls.Add(this.generateRSAButton);
            this.Controls.Add(this.getSessionKeyButton);
            this.Controls.Add(this.serverText);
            this.Controls.Add(this.serverResponse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serverMessageLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverMessageLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label serverResponse;
        private System.Windows.Forms.TextBox serverText;
        private System.Windows.Forms.Button getSessionKeyButton;
        private System.Windows.Forms.Button generateRSAButton;
        private System.Windows.Forms.Button connectToServerButton;
    }
}

