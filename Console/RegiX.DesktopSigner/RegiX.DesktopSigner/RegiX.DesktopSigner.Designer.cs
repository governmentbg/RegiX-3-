using RegiX.DesktopSigner.Properties;
using System;
using System.Resources;

namespace RegiX.DesktopSigner
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblSignedFilePath = new System.Windows.Forms.Label();
            this.SignedFilePathButton = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SignButton = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtSignedFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileButton.Location = new System.Drawing.Point(548, 85);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(26, 23);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilePath.Location = new System.Drawing.Point(8, 64);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(84, 20);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Text = "File path:";
            this.lblFilePath.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSignedFilePath
            // 
            this.lblSignedFilePath.AutoSize = true;
            this.lblSignedFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSignedFilePath.Location = new System.Drawing.Point(8, 120);
            this.lblSignedFilePath.Name = "lblSignedFilePath";
            this.lblSignedFilePath.Size = new System.Drawing.Size(140, 20);
            this.lblSignedFilePath.TabIndex = 5;
            this.lblSignedFilePath.Text = "Signed file path:";
            this.lblSignedFilePath.Click += new System.EventHandler(this.SignedFilePathLabel_Click);
            // 
            // SignedFilePathButton
            // 
            this.SignedFilePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SignedFilePathButton.Location = new System.Drawing.Point(548, 141);
            this.SignedFilePathButton.Name = "SignedFilePathButton";
            this.SignedFilePathButton.Size = new System.Drawing.Size(26, 23);
            this.SignedFilePathButton.TabIndex = 4;
            this.SignedFilePathButton.Text = "...";
            this.SignedFilePathButton.UseVisualStyleBackColor = true;
            this.SignedFilePathButton.Click += new System.EventHandler(this.SignedFilePathButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // SignButton
            // 
            this.SignButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SignButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignButton.Location = new System.Drawing.Point(237, 207);
            this.SignButton.Name = "SignButton";
            this.SignButton.Size = new System.Drawing.Size(108, 37);
            this.SignButton.TabIndex = 7;
            this.SignButton.Text = "Sign";
            this.SignButton.UseVisualStyleBackColor = true;
            this.SignButton.Click += new System.EventHandler(this.SignButton_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(12, 87);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(530, 20);
            this.txtFilePath.TabIndex = 8;
            this.txtFilePath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtSignedFilePath
            // 
            this.txtSignedFilePath.AllowDrop = true;
            this.txtSignedFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSignedFilePath.Location = new System.Drawing.Point(12, 143);
            this.txtSignedFilePath.Name = "txtSignedFilePath";
            this.txtSignedFilePath.Size = new System.Drawing.Size(530, 20);
            this.txtSignedFilePath.TabIndex = 9;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.txtSignedFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.SignButton);
            this.Controls.Add(this.lblSignedFilePath);
            this.Controls.Add(this.SignedFilePathButton);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.SelectFileButton);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "RegiX.DesktopSigner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblSignedFilePath;
        private System.Windows.Forms.Button SignedFilePathButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button SignButton;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtSignedFilePath;
    }

}

