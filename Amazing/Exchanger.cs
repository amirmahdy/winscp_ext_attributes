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
using System.Security.Cryptography;
using System.Collections;

namespace Amazing
{
    public partial class Exchanger : Form
    {
        public void GetRemoteFile(string Path)
        {
            if (Form1._Connected)
            {
                LWRemote.Items.Clear();
                RemoteDirectoryInfo directory = Form1.session.ListDirectory(Path);
                string str;
                foreach (RemoteFileInfo fileInfo in directory.Files)
                {
                    str = fileInfo.FileType.ToString() + fileInfo.FilePermissions.Text;
                    LWRemote.Items.Add(new ListViewItem(new string[] { fileInfo.Name, str }));
                }
            }
        }
        public void GetLocalFile(string Path)
        {
            if (Form1._Connected)
            {
                LWLocal.Items.Clear();
                DirectoryInfo drive = new DirectoryInfo(Path);
                string str;
                foreach (DirectoryInfo directinfo in drive.GetDirectories())
                {
                    str = directinfo.Attributes.ToString();
                    LWLocal.Items.Add(new ListViewItem(new string[] { directinfo.Name, str }));
                }
                
                foreach (FileInfo fileInfo in drive.GetFiles())
                {
                    str = fileInfo.Attributes.ToString();
                    LWLocal.Items.Add(new ListViewItem(new string[] { fileInfo.Name, str }));
                }
            }
        }
        public Exchanger()
        {
            InitializeComponent();
            labelLocal.Text = Form1.LocalPath;
            labelRemote.Text = Form1.RemotePath;
        }
        private void LWRemote_ItemActivate(object sender, EventArgs e)
        {
            RemoteDirectoryInfo directory = Form1.session.ListDirectory(Form1.RemotePath);
            foreach (RemoteFileInfo fileInfo in directory.Files)
            {
                if(LWRemote.FocusedItem.Text == fileInfo.Name)
                    if (fileInfo.FileType == 'd')
                    { Form1.RemotePath = Form1.RemotePath + "/" + LWRemote.FocusedItem.Text; GetRemoteFile(Form1.RemotePath); break; }
                    else
                        break;
            }

            labelLocal.Text = Form1.LocalPath;
            labelRemote.Text = Form1.RemotePath;
        }
        private void snd(object sender, EventArgs e)
        {
            try
            {
                if (LWLocal.FocusedItem.Text != null)
                {
                    Form1.session.PutFiles((Form1.LocalPath + "\\" + LWLocal.FocusedItem.Text), (Form1.RemotePath + "/" + LWLocal.FocusedItem.Text)).Check();
                }
            }
            catch (Exception er)
            {
                //er.Message;
            }
            GetRemoteFile(Form1.RemotePath);
        }
        private void RCV(object sender, EventArgs e)
        {
            try
            {
                if (LWRemote.FocusedItem.Text != null)
                {
                    Form1.session.GetFiles((Form1.RemotePath + "/" + LWRemote.FocusedItem.Text), (Form1.LocalPath + "\\" + LWRemote.FocusedItem.Text)).Check();
                }
            }
            catch
            {
                MessageBox.Show("No File is selected or Access is denied");
            }
            GetLocalFile(Form1.LocalPath);
        }
        private void LWLocal_ItemActivate(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Form1.LocalPath);
            foreach (DirectoryInfo directinfo in directory.GetDirectories())
            {
                if (LWLocal.FocusedItem.Text == directinfo.Name)
                { 
                    Form1.LocalPath = Form1.LocalPath + "\\" + LWLocal.FocusedItem.Text; GetLocalFile(Form1.LocalPath); break; 
                }
            }
            labelLocal.Text = Form1.LocalPath;
            labelRemote.Text = Form1.RemotePath;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo directory = Directory.GetParent(Form1.LocalPath);
                Form1.LocalPath = directory.FullName;
                GetLocalFile(Form1.LocalPath);
            }
            catch
            {
            }
            labelLocal.Text = Form1.LocalPath;
            labelRemote.Text = Form1.RemotePath;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.RemotePath = Form1.RemotePath.Substring(0, Form1.RemotePath.LastIndexOf('/'));
            if (Form1.RemotePath == "")
                Form1.RemotePath = "/";
            GetRemoteFile(Form1.RemotePath);
            labelLocal.Text = Form1.LocalPath;
            labelRemote.Text = Form1.RemotePath;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (LWRemote.FocusedItem != null)
            {
                Form1.session.ExecuteCommand("rm " + Form1.RemotePath + "/" + LWRemote.FocusedItem.Text);
                GetRemoteFile(Form1.RemotePath);
            }
        }
        public static string Encrypt(string data)
        {
            if (data == null)
            {
                return null;
            }
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(Properties.Settings.Default.pubkey);
            try
            {
                int keySize = rsa.KeySize / 8;
                byte[] bytes = Encoding.UTF32.GetBytes(data);
                int maxLength = keySize - 42;
                int dataLength = bytes.Length;
                int iterations = dataLength / maxLength;

                var stringBuilder = new StringBuilder();
                for (int i = 0; i <= iterations; i++)
                {
                    var tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];

                    Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                    byte[] encryptedBytes = rsa.Encrypt(tempBytes, true);
                    Array.Reverse(encryptedBytes);
                    stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

        }
        public static string decrypt(string data)
        {
            if (data == null)
            {
                return null;
            }
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(Properties.Settings.Default.pvtkey);
            try
            {
                int dwKeySize = rsa.KeySize;
                int blockSize = ((dwKeySize / 8) % 3 != 0) ? (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
                int iterations = data.Length / blockSize;

                var arrayList = new ArrayList();
                for (int i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(
                        data.Substring(blockSize * i, blockSize));

                    Array.Reverse(encryptedBytes);
                    arrayList.AddRange(rsa.Decrypt(encryptedBytes, true));
                }

                return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (LWRemote.FocusedItem != null)
            {
                RemoteDirectoryInfo directory = Form1.session.ListDirectory(Form1.RemotePath);
                foreach (RemoteFileInfo fileInfo in directory.Files)
                {
                    if (fileInfo.Name == LWRemote.FocusedItem.Text)
                    {
                        string TheSelected = Form1.RemotePath + "/" + LWRemote.FocusedItem.Text;
                        if (fileInfo.IsDirectory && fileInfo.Name != "." && fileInfo.Name != "..")
                            foldersign(TheSelected );
                        else if (fileInfo.Name != "." && fileInfo.Name != "..")
                            sign(TheSelected );
                        break;
                    }
                    
                
                }

                
            }
        }
        public void foldersign (string folder)
        {
            RemoteDirectoryInfo directory = Form1.session.ListDirectory( folder );
            foreach (RemoteFileInfo fileInfo in directory.Files)
                {
                    if (fileInfo.IsDirectory && fileInfo.Name != "." && fileInfo.Name != "..")
                        foldersign(folder + "/" + fileInfo.Name);
                    else if(fileInfo.Name != "." && fileInfo.Name != "..")
                        sign( folder + "/" +fileInfo.Name);
                
                }
        }
        public void sign(string file)
        {
            CommandExecutionResult RSLT = Form1.session.ExecuteCommand("sha1sum " +  file);
            if (RSLT.IsSuccess == true)
            {
                string[] SHA1 = RSLT.Output.Split(' ');
                SHA1[1] = Encrypt(SHA1[0]);
                //SHA1[1] = decrypt(SHA1[1]);
                RSLT = Form1.session.ExecuteCommand("setfattr -n user.owlds -v " + SHA1[1] + " " +  file);

            }
        }
    }
}
