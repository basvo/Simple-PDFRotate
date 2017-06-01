using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace me.AxeyWorks.PDFRotate
{
    public partial class Form1 : Form
    {
        public System.IO.Stream myFile;
        public string finalFile;

        public Form1()
        {
            InitializeComponent();
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    Console.WriteLine(fileLoc);

                    if (File.Exists(fileLoc))
                    {
                        var stream = new FileStream(fileLoc, FileMode.Open);
                        myFile = StreamToMemory(stream);

                        var str = fileLoc.Remove(fileLoc.Length - 3);

                        finalFile = str + " - Rotated.pdf";

                        textBox1.Text = fileLoc;
                    }

                }
            }
        }

        private MemoryStream StreamToMemory(FileStream fileStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.SetLength(fileStream.Length);
            fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);

            memoryStream.Flush();
            return memoryStream;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF Files|*.pdf";
            openFileDialog1.Title = "Select a PDF File";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                myFile = (openFileDialog1.OpenFile());

                finalFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " - Rotated.pdf";
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myFile != null)
            {
                Program.RotatePDF90CCW(myFile, finalFile);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (myFile != null)
            {
                Program.RotatePDF90CW(myFile, finalFile);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myFile != null)
            {
                Program.RotatePDF180(myFile, finalFile);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text;
        }
    }
}
