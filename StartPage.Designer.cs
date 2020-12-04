namespace SendGridApp
{
    partial class StartPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.CMBMyDB = new System.Windows.Forms.ComboBox();
            this.CMBDBType = new System.Windows.Forms.ComboBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.TxtServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCreateConnection = new System.Windows.Forms.Button();
            this.BtnCloseWindow = new System.Windows.Forms.Button();
            this.lblcreatedb = new System.Windows.Forms.Label();
            this.TxtNewDB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtNewDB);
            this.groupBox1.Controls.Add(this.lblcreatedb);
            this.groupBox1.Controls.Add(this.BtnConnect);
            this.groupBox1.Controls.Add(this.CMBMyDB);
            this.groupBox1.Controls.Add(this.CMBDBType);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.TxtUsername);
            this.groupBox1.Controls.Add(this.TxtServer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 421);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create DB Connection";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(232, 116);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(24, 23);
            this.BtnConnect.TabIndex = 10;
            this.BtnConnect.Text = "...";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // CMBMyDB
            // 
            this.CMBMyDB.FormattingEnabled = true;
            this.CMBMyDB.Location = new System.Drawing.Point(109, 140);
            this.CMBMyDB.Name = "CMBMyDB";
            this.CMBMyDB.Size = new System.Drawing.Size(221, 21);
            this.CMBMyDB.TabIndex = 9;
            this.CMBMyDB.SelectedIndexChanged += new System.EventHandler(this.CMBMyDB_SelectedIndexChanged);
            // 
            // CMBDBType
            // 
            this.CMBDBType.FormattingEnabled = true;
            this.CMBDBType.Location = new System.Drawing.Point(109, 26);
            this.CMBDBType.Name = "CMBDBType";
            this.CMBDBType.Size = new System.Drawing.Size(121, 21);
            this.CMBDBType.TabIndex = 8;
            this.CMBDBType.SelectedIndexChanged += new System.EventHandler(this.CMBDBType_SelectedIndexChanged);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(109, 116);
            this.TxtPassword.MaxLength = 20;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(121, 20);
            this.TxtPassword.TabIndex = 7;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(109, 88);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(121, 20);
            this.TxtUsername.TabIndex = 6;
            // 
            // TxtServer
            // 
            this.TxtServer.Location = new System.Drawing.Point(109, 57);
            this.TxtServer.Name = "TxtServer";
            this.TxtServer.Size = new System.Drawing.Size(121, 20);
            this.TxtServer.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Select DB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Server Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select DBType";
            // 
            // BtnCreateConnection
            // 
            this.BtnCreateConnection.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnCreateConnection.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateConnection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnCreateConnection.Location = new System.Drawing.Point(32, 258);
            this.BtnCreateConnection.Name = "BtnCreateConnection";
            this.BtnCreateConnection.Size = new System.Drawing.Size(145, 23);
            this.BtnCreateConnection.TabIndex = 2;
            this.BtnCreateConnection.Text = "Start";
            this.BtnCreateConnection.UseVisualStyleBackColor = false;
            this.BtnCreateConnection.Click += new System.EventHandler(this.BtnCreateConnection_Click);
            // 
            // BtnCloseWindow
            // 
            this.BtnCloseWindow.BackColor = System.Drawing.Color.Red;
            this.BtnCloseWindow.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCloseWindow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnCloseWindow.Location = new System.Drawing.Point(183, 258);
            this.BtnCloseWindow.Name = "BtnCloseWindow";
            this.BtnCloseWindow.Size = new System.Drawing.Size(75, 23);
            this.BtnCloseWindow.TabIndex = 3;
            this.BtnCloseWindow.Text = "Close";
            this.BtnCloseWindow.UseVisualStyleBackColor = false;
            this.BtnCloseWindow.Click += new System.EventHandler(this.BtnCloseWindow_Click);
            // 
            // lblcreatedb
            // 
            this.lblcreatedb.AutoSize = true;
            this.lblcreatedb.Location = new System.Drawing.Point(11, 175);
            this.lblcreatedb.Name = "lblcreatedb";
            this.lblcreatedb.Size = new System.Drawing.Size(56, 13);
            this.lblcreatedb.TabIndex = 11;
            this.lblcreatedb.Text = "Create DB";
            this.lblcreatedb.Visible = false;
            // 
            // TxtNewDB
            // 
            this.TxtNewDB.Location = new System.Drawing.Point(110, 172);
            this.TxtNewDB.MaxLength = 10;
            this.TxtNewDB.Name = "TxtNewDB";
            this.TxtNewDB.Size = new System.Drawing.Size(121, 20);
            this.TxtNewDB.TabIndex = 12;
            this.TxtNewDB.Visible = false;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(492, 308);
            this.Controls.Add(this.BtnCloseWindow);
            this.Controls.Add(this.BtnCreateConnection);
            this.Controls.Add(this.groupBox1);
            this.Name = "StartPage";
            this.Text = "My Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CMBMyDB;
        private System.Windows.Forms.ComboBox CMBDBType;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.TextBox TxtServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCreateConnection;
        private System.Windows.Forms.Button BtnCloseWindow;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtNewDB;
        private System.Windows.Forms.Label lblcreatedb;

    }
}