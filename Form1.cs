using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AudioEncryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string textFilePath = "";
        string WAVFilePath = "";
        string privateKeyPath = "";
        string publicKeyPath = "";

        private void btnGenKey_Click(object sender, EventArgs e)
        {
            try
            {
                KeyHelper.GenerateAndSaveKeys("public_key.xml", "private_key.xml");
                MessageBox.Show("Keys generated and loaded successfully in the app folder!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating keys: " + ex.Message);
            }
        }

        private void btnChooseWAV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "WAV files (*.wav)|*.wav";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    lblWAVpath.Text = fd.SafeFileName;
                    WAVFilePath = fd.FileName;
                }
            }
        }
        
        private void btnLoadPrivKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "XML files (*.xml)|*.xml";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    privateKeyPath = fd.FileName;
                    lblPrivateKey.Text = fd.SafeFileName;
                }
            }
        }

        private void btnLoadPublicKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "XML files (*.xml)|*.xml";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    publicKeyPath = fd.FileName;
                    lblPublicKey.Text = fd.SafeFileName;
                }
            }
        }

        private void btnChooseTextFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "All Files (*.*)|*.*";
                fd.Title = "Select Text File to Encrypt";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    textFilePath = fd.FileName;
                    lblTextFile.Text = fd.SafeFileName;
                }
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textFilePath))
            {
                MessageBox.Show("No text file given.");
                return;
            }
            if (string.IsNullOrEmpty(publicKeyPath))
            {
                MessageBox.Show("No public key given.");
                return;
            }

            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.Title = "Save Output File";
                fd.Filter = "WAV Files (*.wav)|*.wav";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Encryption.EncryptToAudio(textFilePath, KeyHelper.LoadKeyFromXml(publicKeyPath), fd.FileName);
                    MessageBox.Show("Encryption successful! Output saved.");
                }
            }
            
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WAVFilePath))
            {
                MessageBox.Show("No WAV file given.");
                return;
            }
            if (string.IsNullOrEmpty(privateKeyPath))
            {
                MessageBox.Show("No private key given.");
                return;
            }

            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.Title = "Save Output Text";
                fd.Filter = "All Files (*.*)|*.*";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    if (Encryption.DecryptFromAudio(WAVFilePath, KeyHelper.LoadKeyFromXml(privateKeyPath), fd.FileName))
                        MessageBox.Show("Decryption successful! Output saved.");
                    else {
                        MessageBox.Show("Decryption failed! Possibly wrong key or device error.");
                    }
                }
            }



        }

    }
}
