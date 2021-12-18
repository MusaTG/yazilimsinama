using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeChatEncrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        Socket socketMessage;
        EndPoint epLocal, epRemote;
        byte[] buffer;
        string localMessageEncrypt = "";
        string password;

        private void Form1_Load(object sender, EventArgs e)
        {
            socketMessage = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketMessage.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            epLocal = new IPEndPoint(IPAddress.Parse(GetLocalIp()), Convert.ToInt32(txtLocalPort.Text));
            socketMessage.Bind(epLocal);

            epRemote = new IPEndPoint(IPAddress.Parse(GetLocalIp()), Convert.ToInt32(txtRemotePort.Text));
            socketMessage.Connect(epRemote);

            buffer = new byte[2048];
            socketMessage.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

            try
            {
                Listen.Start(int.Parse(txtRemotePort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MessageCallBack(IAsyncResult ar)
        {
            try
            {
                byte[] receivedData = new byte[2048];
                receivedData = (byte[])ar.AsyncState;
                Sha256 sha256 = new Sha256();
                localMessageEncrypt = sha256.SHA_256_Encrypting(password);
                //converting byte to string
                ASCIIEncoding uTF8Encoding = new ASCIIEncoding();
                string receivedMessage = uTF8Encoding.GetString(receivedData);
                string[] messages = receivedMessage.Split("---");
                foreach (var item in messages)
                {
                    MessageBox.Show(item);
                }

                if (messages[0] == "sha256")
                {
                    if (sha256Verify(messages[1]))
                    {
                        lstMessage.Items.Add("Karşım: " + messages[2]);
                    }
                    else
                        MessageBox.Show("Mesajınızı doğrulayınız...", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    buffer = new byte[2048];
                    socketMessage.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                }
                else if (messages[0] == "spn")
                {
                    SPN spn = new SPN(password);
                    string dene = spn.decrypt(messages[1]);
                    MessageBox.Show(dene);
                    lstMessage.Items.Add(dene);
                }
                else
                    MessageBox.Show("boş döndü");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding uTF8Encoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[2048];
            if (chckSha.Checked)
            {
                Sha256 sha256 = new Sha256();
                localMessageEncrypt = sha256.SHA_256_Encrypting(password);
                sendingMessage = uTF8Encoding.GetBytes("sha256" + "---" + localMessageEncrypt + "---" + txtPlain.Text);
            }
            else if (chckSPN.Checked)
            {
                txtPlain.Text = non_T_Chars(txtPlain.Text);
                if (txtPlain.Text == "") { MessageBox.Show("Mesajı boş geçilemez.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (password == "") { MessageBox.Show("Parola boş geçilemez.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (password.Length != 8) { MessageBox.Show("Parola 8 uzunluğunda giriniz.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else
                {
                    if (txtPlain.Text.Length % 2 == 1)
                        txtPlain.Text += " ";
                    else
                    {
                        while (true)
                        {
                            SPN spn = new SPN(txtPlain.Text, password);
                            localMessageEncrypt = spn.encrypt().Trim();
                            MessageBox.Show("----" + localMessageEncrypt + "----");
                            if (localMessageEncrypt != "" || localMessageEncrypt != " ")
                                break;
                        }
                    }
                }
                sendingMessage = uTF8Encoding.GetBytes("spn" + "---" + localMessageEncrypt);
            }
            else
                MessageBox.Show("Lütfen şifreleme mantığı seçiniz.");

            txtCipher.Text = localMessageEncrypt;

            socketMessage.Send(sendingMessage);
            lstMessage.Items.Add("Ben: " + txtPlain.Text);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            password = txtPassword.Text;
        }

        private string GetLocalIp()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private bool sha256Verify(string password)
        {
            for (var i = 0; i < password.Length; i++)
            {
                if (password[i] != localMessageEncrypt[i])
                    return false;
            }
            return true;
        }

        private string non_T_Chars(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            return text;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(GetLocalIp());
            int port = int.Parse(txtLocalPort.Text);

            var file = new OpenFileDialog();
            file.Multiselect = true;
            file.Title = "Select Files";

            if (file.ShowDialog() == DialogResult.OK)
                foreach (string fileName in file.FileNames)
                {
                    new Thread(() =>
                    {
                        Sender.Send(ipAddress, port, fileName);
                    }).Start();
                }
            file.Dispose();
        }

        private async void sifreleAsync(string dosya)
        {
            try
            {
                this.Enabled = false; // Lock Main Window
                await Task.Run(() => Crypt.EncryptFile("musa", dosya, dosya + ".ae"));
                MessageBox.Show("Şifreleme başarılı!");
                string sourceFolder = dosya + ".ae";
                string[] splitDosya = dosya.Split('.');
                string[] pathDosya = splitDosya[0].Split("\\");
                string path = "";
                for (int i = 0; i < pathDosya.Length - 1; i++)
                    path += (pathDosya[i] + "\\");
                MessageBox.Show(path);
                string targetZipFile = splitDosya[0] + ".zip";

                //string targetFolder = @"D:\Dersler\Yazılım Sınama\unZippedProje";
                //string sourceZipFile = @"D:\Dersler\Yazılım Sınama\zipProje.zip";

                //ZipFile.ExtractToDirectory(sourceZipFile, targetFolder);

                //ZipFile.CreateFromDirectory(sourceFolder, targetZipFile);

                using (ZipArchive archive = ZipFile.Open(targetZipFile, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(sourceFolder, "NewEntry.ae");
                    //archive.ExtractToDirectory(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); // Error MessageBox
            }
            this.Enabled = true; // Unlock Main Window
        }

        private async void cozAsync(string dosya)
        {
            try
            {
                this.Enabled = false; // Lock Main Window
                string sourceZipFile = dosya;
                string[] splitDosya = dosya.Split('.');
                string[] pathDosya = splitDosya[0].Split("\\");
                string path = "";
                for (int i = 0; i < pathDosya.Length - 1; i++)
                    path += (pathDosya[i] + @"\");
                MessageBox.Show(path);
                string targetFolder = path + "unZip";

                ZipFile.ExtractToDirectory(sourceZipFile, targetFolder);

                //string targetFolder = @"D:\Dersler\Yazılım Sınama\unZippedProje";
                //string sourceZipFile = @"D:\Dersler\Yazılım Sınama\zipProje.zip";

                string pathFolder = targetFolder + @"\NewEntry.ae";
                MessageBox.Show(pathFolder + "\n" + targetFolder);
                //ZipFile.CreateFromDirectory(sourceFolder, targetZipFile);
                await Task.Run(() => Crypt.DecryptFile("musa", pathFolder, targetFolder + @"\unZip.txt"));
                MessageBox.Show("Çözme başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); // Error MessageBox
            }
            this.Enabled = true; // Unlock Main Window
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Listen.Stop();
            Sender.Close();
            Environment.Exit(0);
        }

        private void init()
        {
            CheckForIllegalCrossThreadCalls = false;

            Listen.AddListViewItem = addlistViewReceiverItem;
            Sender.AddListViewItem = addlistViewSenderItem;

            if (!Directory.Exists("Downloads"))
            {
                Directory.CreateDirectory("Downloads");
            }
        }

        private void addlistViewReceiverItem(ListViewItem lvi)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    listViewReceiver.Items.Insert(0, lvi);
                });
                lstMessage.Items.Add("Karşım: Dosya Gönderdi.");
            }
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            file.Multiselect = true;
            file.Title = "Select Files";

            if (file.ShowDialog() == DialogResult.OK)
                foreach (string fileName in file.FileNames)
                {
                    sifreleAsync(fileName);
                }
            file.Dispose();
        }

        private void btnUnZip_Click(object sender, EventArgs e)
        {
            var file = new SaveFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
                foreach (string fileName in file.FileNames)
                {
                    cozAsync(fileName);
                }
            file.Dispose();
        }

        private void addlistViewSenderItem(ListViewItem lvi)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    listViewSender.Items.Insert(0, lvi);
                });
                lstMessage.Items.Add("Ben: Dosya Gönderildi.");
            }
        }
    }
}
