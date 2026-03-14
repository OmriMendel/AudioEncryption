namespace AudioEncryption
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
            this.btnGenKey = new System.Windows.Forms.Button();
            this.btnChooseWAV = new System.Windows.Forms.Button();
            this.lblWAVpath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnLoadPrivKey = new System.Windows.Forms.Button();
            this.btnLoadPublicKey = new System.Windows.Forms.Button();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnChooseTextFile = new System.Windows.Forms.Button();
            this.lblTextFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenKey
            // 
            this.btnGenKey.Location = new System.Drawing.Point(19, 236);
            this.btnGenKey.Name = "btnGenKey";
            this.btnGenKey.Size = new System.Drawing.Size(120, 23);
            this.btnGenKey.TabIndex = 0;
            this.btnGenKey.Text = "Generate Keys";
            this.btnGenKey.UseVisualStyleBackColor = true;
            this.btnGenKey.Click += new System.EventHandler(this.btnGenKey_Click);
            // 
            // btnChooseWAV
            // 
            this.btnChooseWAV.Location = new System.Drawing.Point(200, 64);
            this.btnChooseWAV.Name = "btnChooseWAV";
            this.btnChooseWAV.Size = new System.Drawing.Size(138, 23);
            this.btnChooseWAV.TabIndex = 1;
            this.btnChooseWAV.Text = "Choose WAV file";
            this.btnChooseWAV.UseVisualStyleBackColor = true;
            this.btnChooseWAV.Click += new System.EventHandler(this.btnChooseWAV_Click);
            // 
            // lblWAVpath
            // 
            this.lblWAVpath.AutoSize = true;
            this.lblWAVpath.Location = new System.Drawing.Point(204, 90);
            this.lblWAVpath.Name = "lblWAVpath";
            this.lblWAVpath.Size = new System.Drawing.Size(23, 13);
            this.lblWAVpath.TabIndex = 2;
            this.lblWAVpath.Text = "null";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "ENCRYPT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "DECRYPT";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(200, 181);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnLoadPrivKey
            // 
            this.btnLoadPrivKey.Location = new System.Drawing.Point(200, 126);
            this.btnLoadPrivKey.Name = "btnLoadPrivKey";
            this.btnLoadPrivKey.Size = new System.Drawing.Size(120, 23);
            this.btnLoadPrivKey.TabIndex = 6;
            this.btnLoadPrivKey.Text = "Load Private Key";
            this.btnLoadPrivKey.UseVisualStyleBackColor = true;
            this.btnLoadPrivKey.Click += new System.EventHandler(this.btnLoadPrivKey_Click);
            // 
            // btnLoadPublicKey
            // 
            this.btnLoadPublicKey.Location = new System.Drawing.Point(19, 126);
            this.btnLoadPublicKey.Name = "btnLoadPublicKey";
            this.btnLoadPublicKey.Size = new System.Drawing.Size(120, 23);
            this.btnLoadPublicKey.TabIndex = 7;
            this.btnLoadPublicKey.Text = "Load Public Key";
            this.btnLoadPublicKey.UseVisualStyleBackColor = true;
            this.btnLoadPublicKey.Click += new System.EventHandler(this.btnLoadPublicKey_Click);
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(205, 155);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(23, 13);
            this.lblPrivateKey.TabIndex = 8;
            this.lblPrivateKey.Text = "null";
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.AutoSize = true;
            this.lblPublicKey.Location = new System.Drawing.Point(23, 155);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(23, 13);
            this.lblPublicKey.TabIndex = 9;
            this.lblPublicKey.Text = "null";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(19, 181);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 10;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnChooseTextFile
            // 
            this.btnChooseTextFile.Location = new System.Drawing.Point(19, 64);
            this.btnChooseTextFile.Name = "btnChooseTextFile";
            this.btnChooseTextFile.Size = new System.Drawing.Size(138, 23);
            this.btnChooseTextFile.TabIndex = 11;
            this.btnChooseTextFile.Text = "Choose Text file";
            this.btnChooseTextFile.UseVisualStyleBackColor = true;
            this.btnChooseTextFile.Click += new System.EventHandler(this.btnChooseTextFile_Click);
            // 
            // lblTextFile
            // 
            this.lblTextFile.AutoSize = true;
            this.lblTextFile.Location = new System.Drawing.Point(23, 90);
            this.lblTextFile.Name = "lblTextFile";
            this.lblTextFile.Size = new System.Drawing.Size(23, 13);
            this.lblTextFile.TabIndex = 12;
            this.lblTextFile.Text = "null";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(405, 277);
            this.Controls.Add(this.lblTextFile);
            this.Controls.Add(this.btnChooseTextFile);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.lblPublicKey);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.btnLoadPublicKey);
            this.Controls.Add(this.btnLoadPrivKey);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWAVpath);
            this.Controls.Add(this.btnChooseWAV);
            this.Controls.Add(this.btnGenKey);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Audio Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenKey;
        private System.Windows.Forms.Button btnChooseWAV;
        private System.Windows.Forms.Label lblWAVpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnLoadPrivKey;
        private System.Windows.Forms.Button btnLoadPublicKey;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnChooseTextFile;
        private System.Windows.Forms.Label lblTextFile;
    }
}

