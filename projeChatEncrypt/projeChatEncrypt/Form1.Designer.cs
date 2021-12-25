
namespace projeChatEncrypt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdSPN = new MetroFramework.Controls.MetroRadioButton();
            this.rdSha = new MetroFramework.Controls.MetroRadioButton();
            this.txtCipher = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.btnSend = new MetroFramework.Controls.MetroButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewReceiver = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnUnZip = new MetroFramework.Controls.MetroButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listViewSender = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnSendFile = new MetroFramework.Controls.MetroButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnConnect = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(95, 57);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(63, 23);
            this.txtLocalPort.TabIndex = 1;
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(95, 86);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(63, 23);
            this.txtRemotePort.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(23, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 252);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(200)))), ((int)(((byte)(245)))));
            this.tabPage1.Controls.Add(this.rdSPN);
            this.tabPage1.Controls.Add(this.rdSha);
            this.tabPage1.Controls.Add(this.txtCipher);
            this.tabPage1.Controls.Add(this.metroLabel5);
            this.tabPage1.Controls.Add(this.metroLabel6);
            this.tabPage1.Controls.Add(this.metroLabel4);
            this.tabPage1.Controls.Add(this.txtPlain);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(433, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mesaj Gönderimi";
            // 
            // rdSPN
            // 
            this.rdSPN.AutoSize = true;
            this.rdSPN.Location = new System.Drawing.Point(315, 114);
            this.rdSPN.Name = "rdSPN";
            this.rdSPN.Size = new System.Drawing.Size(45, 15);
            this.rdSPN.TabIndex = 11;
            this.rdSPN.Text = "SPN";
            this.rdSPN.UseCustomBackColor = true;
            this.rdSPN.UseSelectable = true;
            // 
            // rdSha
            // 
            this.rdSha.AutoSize = true;
            this.rdSha.Checked = true;
            this.rdSha.Location = new System.Drawing.Point(315, 93);
            this.rdSha.Name = "rdSha";
            this.rdSha.Size = new System.Drawing.Size(63, 15);
            this.rdSha.TabIndex = 11;
            this.rdSha.TabStop = true;
            this.rdSha.Text = "Sha 256";
            this.rdSha.UseCustomBackColor = true;
            this.rdSha.UseSelectable = true;
            // 
            // txtCipher
            // 
            this.txtCipher.Location = new System.Drawing.Point(6, 79);
            this.txtCipher.Multiline = true;
            this.txtCipher.Name = "txtCipher";
            this.txtCipher.ReadOnly = true;
            this.txtCipher.Size = new System.Drawing.Size(296, 139);
            this.txtCipher.TabIndex = 1;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(6, 57);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(110, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Şifrelenmiş Mesaj";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(315, 57);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(112, 19);
            this.metroLabel6.TabIndex = 10;
            this.metroLabel6.Text = "Şifreleme Mantığı";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 9);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(43, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Mesaj";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // txtPlain
            // 
            this.txtPlain.Location = new System.Drawing.Point(6, 31);
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.Size = new System.Drawing.Size(296, 23);
            this.txtPlain.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(315, 144);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(112, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Gönder";
            this.btnSend.UseSelectable = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewReceiver);
            this.tabPage2.Controls.Add(this.btnUnZip);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(433, 224);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dosya Alımı";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewReceiver
            // 
            this.listViewReceiver.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewReceiver.GridLines = true;
            this.listViewReceiver.HideSelection = false;
            this.listViewReceiver.Location = new System.Drawing.Point(6, 6);
            this.listViewReceiver.Name = "listViewReceiver";
            this.listViewReceiver.Size = new System.Drawing.Size(421, 183);
            this.listViewReceiver.TabIndex = 0;
            this.listViewReceiver.UseCompatibleStateImageBehavior = false;
            this.listViewReceiver.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dosya Adı";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dosya Boyutu";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Durum";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Toplam Süre";
            this.columnHeader4.Width = 100;
            // 
            // btnUnZip
            // 
            this.btnUnZip.Location = new System.Drawing.Point(6, 195);
            this.btnUnZip.Name = "btnUnZip";
            this.btnUnZip.Size = new System.Drawing.Size(421, 23);
            this.btnUnZip.TabIndex = 9;
            this.btnUnZip.Text = "Dosya Ayrıştır";
            this.btnUnZip.UseSelectable = true;
            this.btnUnZip.Click += new System.EventHandler(this.btnUnZip_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listViewSender);
            this.tabPage3.Controls.Add(this.btnSendFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(433, 224);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dosya Gönder";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listViewSender
            // 
            this.listViewSender.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewSender.GridLines = true;
            this.listViewSender.HideSelection = false;
            this.listViewSender.Location = new System.Drawing.Point(6, 6);
            this.listViewSender.Name = "listViewSender";
            this.listViewSender.Size = new System.Drawing.Size(421, 183);
            this.listViewSender.TabIndex = 1;
            this.listViewSender.UseCompatibleStateImageBehavior = false;
            this.listViewSender.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dosya Adı";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dosya Boyutu";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Durum";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Toplam Süre";
            this.columnHeader8.Width = 100;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(6, 195);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(421, 23);
            this.btnSendFile.TabIndex = 8;
            this.btnSendFile.Text = "Dosya Gönder";
            this.btnSendFile.UseSelectable = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(320, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(63, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 15;
            this.lstMessage.Location = new System.Drawing.Point(470, 63);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(179, 304);
            this.lstMessage.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(164, 86);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Bağlan";
            this.btnConnect.UseSelectable = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(389, 86);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 6;
            this.metroButton2.Text = "Doğrula";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 86);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Uzak Port";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 57);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Yerel Port";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(268, 86);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(46, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Parola";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 400);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtLocalPort);
            this.Name = "Form1";
            this.Text = "Mesajlaşma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCipher;
        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListView listViewReceiver;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listViewSender;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private MetroFramework.Controls.MetroButton btnConnect;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton btnSend;
        private MetroFramework.Controls.MetroButton btnSendFile;
        private MetroFramework.Controls.MetroButton btnUnZip;
        private MetroFramework.Controls.MetroRadioButton rdSPN;
        private MetroFramework.Controls.MetroRadioButton rdSha;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}

