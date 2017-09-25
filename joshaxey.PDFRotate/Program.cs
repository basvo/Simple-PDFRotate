using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;

namespace joshaxey.PDFRotate
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void RotatePDF90CW(Stream inputFile, string outputFile)
        {
            using (FileStream outStream = new FileStream(outputFile, FileMode.Create))
            {
                PdfReader reader = new PdfReader(inputFile);
                PdfStamper stamper = new PdfStamper(reader, outStream);

                int pageCount = reader.NumberOfPages;

                for (int n = 1; n <= pageCount; n++)
                {
                    PdfDictionary pageDict = reader.GetPageN(n);
                    int desiredRot = 90; //
                    PdfNumber rotation = pageDict.GetAsNumber(PdfName.ROTATE);

                    if (rotation != null)
                    {
                        desiredRot += rotation.IntValue;
                        desiredRot %= 360; // must be 0, 90, 180, or 270
                    }
                    pageDict.Put(PdfName.ROTATE, new PdfNumber(desiredRot));
                }
                
                stamper.Close();
                reader.Close();
                MessageBox.Show("Rotated 90° clockwise and saved with PAVS extension!");
            }
        }

        public static void RotatePDF90CCW(Stream inputFile, string outputFile)
        {
            using (FileStream outStream = new FileStream(outputFile, FileMode.Create))
            {
                PdfReader reader = new PdfReader(inputFile);
                PdfStamper stamper = new PdfStamper(reader, outStream);

                int pageCount = reader.NumberOfPages;

                for (int n = 1; n <= pageCount; n++)
                {
                    PdfDictionary pageDict = reader.GetPageN(n);
                    int desiredRot =270; //
                    PdfNumber rotation = pageDict.GetAsNumber(PdfName.ROTATE);

                    if (rotation != null)
                    {
                        desiredRot += rotation.IntValue;
                        desiredRot %= 360; // must be 0, 90, 180, or 270
                    }
                    pageDict.Put(PdfName.ROTATE, new PdfNumber(desiredRot));
                }

                stamper.Close();
                reader.Close();
                MessageBox.Show("Rotated 90° counter-clockwise and saved with PAVS extension!");
            }
        }

        public static void RotatePDF180(Stream inputFile, string outputFile)
        {
            using (FileStream outStream = new FileStream(outputFile, FileMode.Create))
            {
                PdfReader reader = new PdfReader(inputFile);
                PdfStamper stamper = new PdfStamper(reader, outStream);

                int pageCount = reader.NumberOfPages;

                for (int n = 1; n <= pageCount; n++)
                {
                    PdfDictionary pageDict = reader.GetPageN(n);
                    int desiredRot = 180; //
                    PdfNumber rotation = pageDict.GetAsNumber(PdfName.ROTATE);

                    if (rotation != null)
                    {
                        desiredRot += rotation.IntValue;
                        desiredRot %= 360; // must be 0, 90, 180, or 270
                    }
                    pageDict.Put(PdfName.ROTATE, new PdfNumber(desiredRot));
                }

                stamper.Close();
                reader.Close();
                MessageBox.Show("Rotated 180° and saved with PAVS extension!");
            }
        }
    }
}