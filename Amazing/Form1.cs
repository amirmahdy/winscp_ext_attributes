using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

namespace Amazing
{

    public partial class Form1 : Form
    {
        public static SessionOptions sessionOptions;
        public static Session session;
        public static bool _Connected;
        public static string RemotePath;
        public static string LocalPath;

        public Form1()
        {
            if (Properties.Settings.Default.SSHKEY == "")
                Properties.Settings.Default.SSHKEY = "ssh-rsa 2048 11:11:11:11:11:11:11:11:11:11:11:11:11:11:11:11";
            InitializeComponent();
            if (Properties.Settings.Default.pvtkey == "")
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                Properties.Settings.Default.pvtkey = rsa.ToXmlString(true);  // Private Key
                Properties.Settings.Default.pubkey = rsa.ToXmlString(false);  // Public Key
                Properties.Settings.Default.Save();

                var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var fullFileName = Path.Combine(desktopFolder, "PvtKey.xml");
                System.IO.File.WriteAllText(fullFileName, Properties.Settings.Default.pvtkey);
            }
            ipadd_text.Text = "192.168.1.10";
            user_text.Text = "user";
            pass_text.Text = "password";
        }

        public bool Connect()
        {
        _RETRY:
            try
            {
                sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = ipadd_text.Text,
                    UserName = user_text.Text,
                    Password = pass_text.Text,
                    SshHostKeyFingerprint = Properties.Settings.Default.SSHKEY
                };
                session = new Session();
                session.Open(sessionOptions);
            }
            catch (Exception e)
            {
                string[] str = e.Message.Split('"');
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                if (str[0] == "Host key does not match configured key ")
                {
                    result = MessageBox.Show("New SSH Key is available from server do you trust this server?", "SSH Key", buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        str = e.InnerException.Message.Split('\r', '.', ' ');
                        Properties.Settings.Default.SSHKEY = str[4] + " " + str[5] + " " + str[6];
                        Properties.Settings.Default.Save();
                        goto _RETRY;
                    }
                }
                else
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Connect() == true)
            {
                _Connected = true;
                Exchanger newobj = new Exchanger();
                newobj.Show();
                RemotePath = "/home/";// +user_text.Text;
                LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                newobj.GetRemoteFile(RemotePath);
                newobj.GetLocalFile(LocalPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.pubkey == null)
                MessageBox.Show("No Public Key assigned");
            else
            {
                var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var fullFileName = Path.Combine(desktopFolder, "PubKey.xml");
                System.IO.File.WriteAllText(fullFileName, Properties.Settings.Default.pubkey);
            }
        }

    }
}
