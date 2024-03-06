namespace Field_Service_Toolkit
{
    partial class Logon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logon));
            lblWelcome = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            btnConfirm = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblWelcome.Location = new System.Drawing.Point(72, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(226, 55);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblPassword.Location = new System.Drawing.Point(111, 64);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(375, 27);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Please enter your BSW Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPassword.Location = new System.Drawing.Point(111, 92);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(200, 32);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnConfirm.Location = new System.Drawing.Point(317, 94);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(90, 30);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button2.Location = new System.Drawing.Point(413, 94);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(90, 30);
            button2.TabIndex = 4;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Logon
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.WindowFrame;
            ClientSize = new System.Drawing.Size(600, 150);
            Controls.Add(button2);
            Controls.Add(btnConfirm);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblWelcome);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Logon";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Logon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button2;
    }
}