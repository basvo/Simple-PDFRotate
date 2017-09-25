using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace joshaxey.PDFRotate
{
    public partial class Form1 : Form
    {
        public Stream MyFile;
        public string FinalFile;

        public Form1()
        {
            InitializeComponent();
            AllowDrop = true;
            DragEnter += Form1_DragEnter;
            DragDrop += Form1_DragDrop;
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
            foreach (string fileLoc in filePaths)
            {
                Console.WriteLine(fileLoc);

                if (!File.Exists(fileLoc)) continue;
                var stream = new FileStream(fileLoc, FileMode.Open);
                MyFile = StreamToMemory(stream);

                var str = fileLoc.Remove(fileLoc.Length - 3);

                FinalFile = str + " - Rotated.pdf";

                textBox1.Text = fileLoc;
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
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Select a PDF File",
                Multiselect = false
            };

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            MyFile = (openFileDialog1.OpenFile());

            FinalFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " - Rotated.pdf";
            textBox1.Text = openFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MyFile != null)
            {
                Program.RotatePDF90CCW(MyFile, FinalFile);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MyFile != null)
            {
                Program.RotatePDF90CW(MyFile, FinalFile);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MyFile != null)
            {
                Program.RotatePDF180(MyFile, FinalFile);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text;
        }
    }
}
