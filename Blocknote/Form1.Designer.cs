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
            this.getSessionKeyButton = new System.Windows.Forms.Button();
            this.generateRSAButton = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverMessageLabel
            // 
            this.serverMessageLabel.AutoSize = true;
            this.serverMessageLabel.Location = new System.Drawing.Point(460, 287);
            this.serverMessageLabel.Name = "serverMessageLabel";
            this.serverMessageLabel.Size = new System.Drawing.Size(133, 20);
            this.serverMessageLabel.TabIndex = 0;
            this.serverMessageLabel.Text = "Server responses";
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
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(302, 40);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(48, 20);
            this.labelLogin.TabIndex = 7;
            this.labelLogin.Text = "Login";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(302, 90);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(78, 20);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(433, 40);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(280, 26);
            this.textBoxLogin.TabIndex = 9;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(433, 90);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(280, 26);
            this.textBoxPassword.TabIndex = 10;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(433, 149);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(280, 32);
            this.loginButton.TabIndex = 11;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.generateRSAButton);
            this.Controls.Add(this.getSessionKeyButton);
            this.Controls.Add(this.serverMessageLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverMessageLabel;
        private System.Windows.Forms.Button getSessionKeyButton;
        private System.Windows.Forms.Button generateRSAButton;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button loginButton;
    }
}

