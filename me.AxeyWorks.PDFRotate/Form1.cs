using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF Files|*.pdf";
            openFileDialog1.Title = "Select a PDF File";
            openFileDialog1.Multiselect = false;

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .pdf file was selected, open it.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Assign PDF into program.cs file
                
                myFile = (openFileDialog1.OpenFile());

                finalFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " PAVS Markup.pdf";
                textBox1.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myFile != null)
            {
                myFile = (openFileDialog1.OpenFile());

                finalFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " PAVS Markup.pdf";
                textBox1.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                Program.RotatePDF90CCW(myFile, finalFile);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (myFile != null)
            {
                myFile = (openFileDialog1.OpenFile());

                finalFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " PAVS Markup.pdf";
                textBox1.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
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
                myFile = (openFileDialog1.OpenFile());

                finalFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + " PAVS Markup.pdf";
                textBox1.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                Program.RotatePDF180(myFile, finalFile);
            }
        }
    }
}
