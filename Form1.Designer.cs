namespace Field_Service_Toolkit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblAssetTag = new System.Windows.Forms.Label();
            txtAssetTag = new System.Windows.Forms.TextBox();
            btnPing = new System.Windows.Forms.Button();
            lblResults = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            commonSoftwareFixesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printerOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            computerMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            techMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            txtUserName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnClear = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblAssetTag
            // 
            lblAssetTag.AutoSize = true;
            lblAssetTag.BackColor = System.Drawing.Color.Transparent;
            lblAssetTag.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblAssetTag.ForeColor = System.Drawing.Color.Yellow;
            lblAssetTag.Location = new System.Drawing.Point(14, 55);
            lblAssetTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAssetTag.Name = "lblAssetTag";
            lblAssetTag.Size = new System.Drawing.Size(119, 19);
            lblAssetTag.TabIndex = 0;
            lblAssetTag.Text = "Computer Name";
            // 
            // txtAssetTag
            // 
            txtAssetTag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAssetTag.Location = new System.Drawing.Point(19, 81);
            txtAssetTag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAssetTag.Name = "txtAssetTag";
            txtAssetTag.Size = new System.Drawing.Size(244, 29);
            txtAssetTag.TabIndex = 1;
            // 
            // btnPing
            // 
            btnPing.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnPing.Location = new System.Drawing.Point(573, 80);
            btnPing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPing.Name = "btnPing";
            btnPing.Size = new System.Drawing.Size(150, 29);
            btnPing.TabIndex = 2;
            btnPing.Text = "Ping Workstation";
            btnPing.UseVisualStyleBackColor = true;
            btnPing.Click += btnPing_Click;
            // 
            // lblResults
            // 
            lblResults.BackColor = System.Drawing.Color.Black;
            lblResults.ForeColor = System.Drawing.Color.Lime;
            lblResults.Location = new System.Drawing.Point(16, 126);
            lblResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblResults.Name = "lblResults";
            lblResults.Size = new System.Drawing.Size(373, 235);
            lblResults.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { commonSoftwareFixesToolStripMenuItem, printerOptionsToolStripMenuItem, computerMaintenanceToolStripMenuItem, techMenuToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1381, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // commonSoftwareFixesToolStripMenuItem
            // 
            commonSoftwareFixesToolStripMenuItem.Name = "commonSoftwareFixesToolStripMenuItem";
            commonSoftwareFixesToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            commonSoftwareFixesToolStripMenuItem.Text = "Common Software Fixes";
            // 
            // printerOptionsToolStripMenuItem
            // 
            printerOptionsToolStripMenuItem.Name = "printerOptionsToolStripMenuItem";
            printerOptionsToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            printerOptionsToolStripMenuItem.Text = "Printer Options";
            // 
            // computerMaintenanceToolStripMenuItem
            // 
            computerMaintenanceToolStripMenuItem.Name = "computerMaintenanceToolStripMenuItem";
            computerMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            computerMaintenanceToolStripMenuItem.Text = "Computer Maintenance";
            // 
            // techMenuToolStripMenuItem
            // 
            techMenuToolStripMenuItem.Name = "techMenuToolStripMenuItem";
            techMenuToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            techMenuToolStripMenuItem.Text = "Tech Menu";
            // 
            // txtUserName
            // 
            txtUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtUserName.Location = new System.Drawing.Point(295, 82);
            txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new System.Drawing.Size(244, 29);
            txtUserName.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.Yellow;
            label1.Location = new System.Drawing.Point(290, 55);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 19);
            label1.TabIndex = 5;
            label1.Text = "User Name";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClear
            // 
            btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnClear.Location = new System.Drawing.Point(781, 80);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(120, 29);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1381, 913);
            Controls.Add(btnClear);
            Controls.Add(txtUserName);
            Controls.Add(label1);
            Controls.Add(lblResults);
            Controls.Add(btnPing);
            Controls.Add(txtAssetTag);
            Controls.Add(lblAssetTag);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "FS Maintenance Toolkit";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAssetTag;
        private System.Windows.Forms.TextBox txtAssetTag;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem commonSoftwareFixesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printerOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem techMenuToolStripMenuItem;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
    }
}

