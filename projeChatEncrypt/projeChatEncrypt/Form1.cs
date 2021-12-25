using ChatEncrypt;
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
    public partial class Form1 : MetroFramework.Forms.MetroForm
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
                //converting byte to string
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                string receivedMessage = uTF8Encoding.GetString(receivedData);
                string[] messages = receivedMessage.Split("---");

                if (messages[0] == "sha256")
                {
                    Sha256 sha256 = new Sha256();
                    localMessageEncrypt = sha256.Sha256_Encrypting(password);
                    txtCipher.Text = localMessageEncrypt;
                    if (sha256Verify(messages[1]))
                    {
                        lstMessage.Items.Add("Karşım: " + messages[2]);
                    }
                    else
                        MessageBox.Show("Mesajınızı doğrulayınız...", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (messages[0] == "spn")
                {
                    if (messages[1].Trim() == "")
                    {
                        MessageBox.Show("Boş mesaj döndü.");
                        return;
                    }
                    else if (password == "")
                    {
                        MessageBox.Show("Parola boş geçilemez.");
                        return;
                    }
                    else if (password.Length != 8)
                    {
                        MessageBox.Show("Parola 8 uzunluğunda giriniz.");
                        return;
                    }
                    else
                    {
                        txtCipher.Text = messages[1];
                        SPN spn = new SPN(password);
                        lstMessage.Items.Add("Karşım: " + spn.Decryption(txtCipher.Text));
                    }
                }
                else
                    MessageBox.Show("Boş döndü");
                buffer = new byte[2048];
                socketMessage.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            byte[] sendingMessage = new byte[2048];
            if (txtPlain.Text == "")
            {
                MessageBox.Show("Mesajı boş geçilemez.");
                return;
            }
            else if (password == "")
            {
                MessageBox.Show("Parola boş geçilemez");
                return;
            }
            if (rdSha.Checked)
            {
                Sha256 sha256 = new Sha256();
                localMessageEncrypt = sha256.Sha256_Encrypting(password);
                sendingMessage = uTF8Encoding.GetBytes("sha256" + "---" + localMessageEncrypt + "---" + txtPlain.Text);
            }
            else if (rdSPN.Checked)
            {
                if (password.Length != 8)
                {
                    MessageBox.Show("Parola 8 uzunluğunda giriniz.");
                    return;
                }
                else
                {
                    while (true)
                    {
                        if (txtPlain.Text.Length % 2 == 1)
                            txtPlain.Text += " ";
                        else
                        {
                            SPN spn = new SPN();
                            spn.binaryMessage = spn.StrToBin(txtPlain.Text);
                            spn.binaryPassword = spn.StrToBin(password);
                            localMessageEncrypt = spn.Encryption();
                            if (localMessageEncrypt != "")
                                break;
                        }
                    }
                }
                sendingMessage = uTF8Encoding.GetBytes("spn" + "---" + localMessageEncrypt);
            }
            else
                MessageBox.Show("Lütfen şifreleme mantığı seçiniz.");
            lstMessage.Items.Add("Ben: " + txtPlain.Text);
            txtCipher.Text = localMessageEncrypt;
            socketMessage.Send(sendingMessage);
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
                    sifreleAsync(fileName);
                    string[] splitDosya = fileName.Split(".");
                    string filePath = splitDosya[0] + ".zip";
                    MessageBox.Show("Dosya başarıyla gönderildi.");
                    new Thread(() =>
                    {
                        Sender.Send(ipAddress, port, filePath);
                    }).Start();
                }
            file.Dispose();
        }

        private async void sifreleAsync(string dosya)
        {
            try
            {
                this.Enabled = false; // Lock Main Window
                await Task.Run(() => Crypt.EncryptFile(password, dosya, dosya + ".ae"));
                string sourceFolder = dosya + ".ae";
                string[] splitDosya = dosya.Split('.');
                string[] pathDosya = splitDosya[0].Split("\\");
                string path = "";
                for (int i = 0; i < pathDosya.Length - 1; i++)
                    path += (pathDosya[i] + "\\");
                string targetZipFile = splitDosya[0] + ".zip";

                using (ZipArchive archive = ZipFile.Open(targetZipFile, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(sourceFolder, "NewEntry.ae");
                }
                File.Delete(sourceFolder);
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
                string[] pathDosya = sourceZipFile.Split("\\");
                string path = "";
                for (int i = 0; i < pathDosya.Length; i++)
                {
                    string[] ayir = pathDosya[i].Split(".");
                    if (ayir[ayir.Length - 1] == "zip")
                        pathDosya[i] = pathDosya[i].Split(".")[0];
                    path += (pathDosya[i] + @"\");
                }
                string targetFolder = path;

                ZipFile.ExtractToDirectory(sourceZipFile, targetFolder);

                string pathFolder = targetFolder + @"\NewEntry.ae";

                await Task.Run(() => Crypt.DecryptFile(password, pathFolder, targetFolder + pathDosya[pathDosya.Length - 1] + ".txt"));
                File.Delete(pathFolder);
                File.Delete(sourceZipFile);
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

        private void btnUnZip_Click(object sender, EventArgs e)
        {
            var file = new SaveFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
                foreach (string fileName in file.FileNames)
                {
                    cozAsync(fileName);
                }
            file.Dispose();
            MessageBox.Show("Dosya başarıyla ayrıştırıldı.");
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
