namespace SendGridApp
{
    partial class MainPage
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
            this.chkSPlist = new System.Windows.Forms.CheckedListBox();
            this.Start = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSPlist
            // 
            this.chkSPlist.FormattingEnabled = true;
            this.chkSPlist.Location = new System.Drawing.Point(33, 40);
            this.chkSPlist.Name = "chkSPlist";
            this.chkSPlist.Size = new System.Drawing.Size(398, 244);
            this.chkSPlist.TabIndex = 2;
            this.chkSPlist.SelectedIndexChanged += new System.EventHandler(this.chkSPlist_SelectedIndexChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(33, 290);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(101, 23);
            this.Start.TabIndex = 3;
            this.Start.Text = "Display code";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Visible = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(149, 290);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 23);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(267, 329);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(145, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Changes";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(267, 290);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(145, 23);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copy Changes";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Location = new System.Drawing.Point(917, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 17);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(61, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "SP Content";
            this.lblMessage.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 34);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(501, 396);
            this.textBox3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(469, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 449);
            this.panel1.TabIndex = 6;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 501);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.chkSPlist);
            this.Name = "MainPage";
            this.Text = "Send Grid Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkSPlist;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
    }
}