using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.DesktopSigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.txtFilePath.DragDrop += new DragEventHandler(this.textBox1_DragDrop);
            this.txtFilePath.DragOver += new DragEventHandler(this.textBox1_DragOver);
            this.txtSignedFilePath.DragDrop += new DragEventHandler(this.textBox2_DragDrop);
            this.txtSignedFilePath.DragOver += new DragEventHandler(this.textBox2_DragOver);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://";
            openFileDialog1.Title = "Select file to be signed.";
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.xml)|*.pdf; *.xml";
            openFileDialog1.FilterIndex = 1;

            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        txtFilePath.Text = path;
                        var file = System.IO.File.ReadAllText(path, Encoding.UTF8);
                        string signedPath = path.Insert(path.Length - 4, "_signed");
                        txtSignedFilePath.Text = signedPath;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SignedFilePathLabel_Click(object sender, EventArgs e)
        {

        }

        private void SignedPathLabel_Click(object sender, EventArgs e)
        {

        }

        private void SignedFilePathButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtSignedFilePath.Text = dialog.FileName;
            }


            //openFileDialog2.InitialDirectory = PathLabel.Text;
            //openFileDialog2.Title = "Select signed file location";
            //openFileDialog2.Filter = "Select Valid Document(*.pdf; *.xml)|*.pdf; *.xml";
            //openFileDialog2.FilterIndex = 1;

            //try
            //{
            //    if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (openFileDialog2.CheckFileExists)
            //        {
            //            string path = System.IO.Path.GetFullPath(openFileDialog2.FileName);
            //            SignedPathLabel.Text = path;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Upload document.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            var signer = Composition.CompositionContainer.GetExportedValue<ISigner>();
            var text = File.ReadAllText(txtFilePath.Text);
            var signData = text.XmlDeserialize<ServiceResultData>();
            signer.Sign(signData);
            File.WriteAllText(txtSignedFilePath.Text, signData.XmlSerialize().ToXmlElement().OuterXml);
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Any())
            { 
                txtFilePath.Text = files.First();
                var path = files.First().ToString();
                var file = System.IO.File.ReadAllText(path, Encoding.UTF8);
                string signedPath = path.Insert(path.Length - 4, "_signed");
                txtSignedFilePath.Text = signedPath;
            }
        }

        private void textBox2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; 
            if (files != null && files.Any())
                txtSignedFilePath.Text = files.First();
            var path = files.First().ToString();
            var file = System.IO.File.ReadAllText(path, Encoding.UTF8);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
