using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jpeg
{
    public partial class Form1 : Form
    {
        string CalePozaOriginala = "";
        const int DimensiunePoza = 256;
        const double PI = 3.1415;
        static double[,] MatriceCosinus = new double[8, 8];
        byte[,] MatriceYorig = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] MatriceCborig = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] MatriceCrorig = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] MatriceYsubesantionare = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] MatriceCbsubesantionare = new byte[128, 128];
        byte[,] MatriceCrsubesantionare = new byte[128, 128];
        double[,] MatriceDCTY = new double[DimensiunePoza, DimensiunePoza];
        double[,] MatriceDCTCb = new double[128, 128];
        double[,] MatriceDCTCr = new double[128, 128];
        double[,] MatriceIDCTY = new double[DimensiunePoza, DimensiunePoza];
        double[,] MatriceIDCTCb = new double[128, 128];
        double[,] MatriceIDCTCr = new double[128, 128];
        int[,] MatriceDCTYcuantizata = new int[DimensiunePoza, DimensiunePoza];
        int[,] MatriceDCTCbcuantizata = new int[128, 128];
        int[,] MatriceDCTCrcuantizata = new int[128, 128];
        int[,] MatriceDCTYcuantizataReverse = new int[DimensiunePoza, DimensiunePoza];
        int[,] MatriceDCTCbcuantizataReverse = new int[128, 128];
        int[,] MatriceDCTCrcuantizataReverse = new int[128, 128];

        byte[,] MatriceZigZag = {{0,1,5,6,14,15,27,28},
                                 {2,4,7,13,16,26,29,42},
                                 {3,8,12,17,25,30,41,43},
                                 {9,11,18,24,31,40,44,53},
                                 {10,19,23,32,39,45,52,54},
                                 {20,22,33,38,46,51,55,60},
                                 {21,34,37,47,50,56,59,61},
                                 {35,36,48,49,57,58,62,63}};

        public int[,] matriceLuminantaY = {{16,11,10,16,24,40,51,61},
                                           {12,12,14,19,26,58,60,55},
                                           {14,13,16,24,40,57,69,56},
                                           {14,17,22,29,51,87,80,62},
                                           {18,22,37,56,68,109,103,77},
                                           {24,35,55,64,81,104,113,92},
                                           {49,64,78,87,103,121,120,101},
                                           {72,92,95,98,112,100,103,99}};

        public int[,] matriceCrominantaCbCr = {{17,18,24,47,99,99,99,99},
                                               {18,21,26,66,99,99,99,99},
                                               {24,26,56,99,99,99,99,99},
                                               {47,66,99,99,99,99,99,99},
                                               {99,99,99,99,99,99,99,99},
                                               {99,99,99,99,99,99,99,99},
                                               {99,99,99,99,99,99,99,99},
                                               {99,99,99,99,99,99,99,99}};

        int[,] matriceCuantizareY = new int[8, 8];
        int[,] matriceCuantizareCbCr = new int[8, 8];
        byte[,] MatriceYsubesantionareReverse = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] MatriceCbsubesantionareReverse = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] MatriceCrsubesantionareReverse = new byte[DimensiunePoza, DimensiunePoza];
        //-------------------------------------
        byte[,] RosuRefacut = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] VerdeRefacut = new byte[DimensiunePoza, DimensiunePoza];
        byte[,] AlbastruRefacut = new byte[DimensiunePoza, DimensiunePoza];
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "bmp files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CalePozaOriginala = openFileDialog.FileName;
                FileStream fs = new FileStream(CalePozaOriginala, FileMode.Open, FileAccess.Read);
                ImagineOriginala.Image = Image.FromStream(fs);
                fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulareMatriceCosinus(MatriceCosinus);
            RGBtoYBCR();
            Subesantionare();
            DCT();
        }

        public double cx(double t)
        {
            bool conditie = t == 0;
            t = conditie ? 1.0 / Math.Sqrt(2) : 1;
            return t;
        }

        public void PopulareMatriceCosinus(double[,] matcos)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matcos[i, j] = Math.Cos((2 * i + 1) * j * PI) / 16;
                }
            }
        }

        public void RGBtoYBCR()
        {

            Bitmap CuloriPoza = new Bitmap(CalePozaOriginala);

            for (int i = 0; i < DimensiunePoza; i++)
            {
                for (int j = 0; j < DimensiunePoza; j++)
                {
                    MatriceYorig[i, j] = (byte)(0.299 * CuloriPoza.GetPixel(i, j).R + 0.587 * CuloriPoza.GetPixel(i, j).G + 0.114 * CuloriPoza.GetPixel(i, j).B);
                    MatriceCborig[i, j] = (byte)(-0.1687 * CuloriPoza.GetPixel(i, j).R - 0.3313 * CuloriPoza.GetPixel(i, j).G + 0.5 * CuloriPoza.GetPixel(i, j).B + 128);
                    MatriceCrorig[i, j] = (byte)(0.5 * CuloriPoza.GetPixel(i, j).R - 0.4187 * CuloriPoza.GetPixel(i, j).G - 0.0813 * CuloriPoza.GetPixel(i, j).B + 128);
                }
            }
        }

        public void Subesantionare()
        {
            MatriceYsubesantionare = MatriceYorig;

            for (int i = 0; i < 128; i = i + 2)
            {
                for (int j = 0; j < 128; j = j + 2)
                {
                    MatriceCbsubesantionare[i, j] = (byte)((MatriceCborig[i, j]
                                                         + MatriceCborig[i + 1, j]
                                                         + MatriceCborig[i, j + 1]
                                                         + MatriceCborig[i + 1, j + 1]) / 4);

                    MatriceCrsubesantionare[i, j] = (byte)((MatriceCrorig[i, j]
                                                         + MatriceCrorig[i + 1, j]
                                                         + MatriceCrorig[i, j + 1]
                                                         + MatriceCrorig[i + 1, j + 1]) / 4);
                }
            }
        }

        public void DCT()
        {
            for (int i = 0; i < 256; i= i+8)
            {
                for (int j = 0; j < 256; j=j+8)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            MatriceDCTY[i, j] += MatriceYsubesantionare[i, j] * MatriceCosinus[k, i % 8] * MatriceCosinus[p, j % 8];
                        }
                    }
                    MatriceDCTY[i, j] = MatriceDCTY[i, j] * 1 / 4 * cx(i % 8) * cx(j % 8);
                }
            }

            for (int i = 0; i < 128; i = i + 8)
            {
                for (int j = 0; j < 128; j = j + 8)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            MatriceDCTCb[i, j] += MatriceCbsubesantionare[i, j] * MatriceCosinus[k, i % 8] * MatriceCosinus[p, j % 8];
                            MatriceDCTCr[i, j] += MatriceCrsubesantionare[i, j] * MatriceCosinus[k, i % 8] * MatriceCosinus[p, j % 8];
                        }
                    }
                    MatriceDCTCb[i, j] = MatriceDCTCb[i, j] * 1 / 4 * cx(i % 8) * cx(j % 8);
                    MatriceDCTCr[i, j] = MatriceDCTCr[i, j] * 1 / 4 * cx(i % 8) * cx(j % 8);
                }
            }
        }

        public void MetodaZigZag()
        {
            byte aux = Convert.ToByte((textBox1.Text));

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (aux > MatriceZigZag[i, j])
                    {
                        matriceCuantizareY[i, j] = (byte)MatriceDCTY[i,j];
                        matriceCuantizareCbCr[i, j] = (byte)MatriceDCTCb[i, j];
                    }
                    else
                    {
                        matriceCuantizareY[i, j] = 0;
                        matriceCuantizareCbCr[i, j] = 0;

                    }

                    if (matriceCuantizareY[i, j] == 0) matriceCuantizareY[i, j] = 1;
                    if (matriceCuantizareCbCr[i, j] == 0) matriceCuantizareCbCr[i, j] = 1;
                }
            }

            Cuantizare();
        }

        public void MetodaMatriceSimplaCalculata()
        {
            int aux = Convert.ToInt32((textBox2.Text));

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    matriceCuantizareY[x, y] = 1 + (x + y) * aux;
                    matriceCuantizareCbCr[x, y] = 1 + (x + y) * aux;

                }
            }

            Cuantizare();
        }

        public void MetodaFactorJPEG()
        {
            int aux = Convert.ToInt32((textBox3.Text));

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (aux > 0 && aux < 51)
                    {
                        matriceCuantizareY[i, j] = 50 / aux * matriceLuminantaY[i, j];
                        matriceCuantizareCbCr[i, j] = 50 / aux * matriceCrominantaCbCr[i, j];
                    }
                    else if (aux > 50 && aux < 100)
                    {
                        matriceCuantizareY[i, j] = (2 - (aux / 50)) * matriceLuminantaY[i, j];
                        matriceCuantizareCbCr[i, j] = (2 - (aux / 50)) * matriceCrominantaCbCr[i, j];
                    }
                    else
                    {
                        matriceCuantizareY[i, j] = 1;
                        matriceCuantizareCbCr[i, j] = 1;
                    }

                    if (matriceCuantizareY[i, j] == 0) matriceCuantizareY[i, j] = 1;
                    if (matriceCuantizareCbCr[i, j] == 0) matriceCuantizareCbCr[i, j] = 1;
                }
            }

            Cuantizare();
        }

        private void btnTransformareInversa_Click(object sender, EventArgs e)
        {
            if (rbPrimaMetoda.Checked)
            {
                MetodaZigZag();
                CuantizareReverse();
                ReverseDCT();
                ReverseSubesantionare();
                YBCRtoRGB();
            }
            else if (rbDouaMetoda.Checked)
            {
                MetodaMatriceSimplaCalculata();
                CuantizareReverse();
                ReverseDCT();
                ReverseSubesantionare();
                YBCRtoRGB();
            }
            else if (rbTreiaMetoda.Checked)
            {
                MetodaFactorJPEG();
                CuantizareReverse();
                ReverseDCT();
                ReverseSubesantionare();
                YBCRtoRGB();
            }
        }

        private void Cuantizare()
        {
            for (int i = 0; i < DimensiunePoza - 1; i++)
            {
                for (int j = 0; j < DimensiunePoza - 1; j++)
                {

                    MatriceDCTYcuantizata[i, j] = Convert.ToInt32(Math.Round(MatriceDCTY[i, j] / matriceCuantizareY[i % 8, j % 8]));
                }
            }

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    MatriceDCTCbcuantizata[i, j] = Convert.ToInt32(Math.Round(MatriceDCTCb[i, j] / matriceCuantizareCbCr[i % 8, j % 8]));
                    MatriceDCTCrcuantizata[i, j] = Convert.ToInt32(Math.Round(MatriceDCTCr[i, j] / matriceCuantizareCbCr[i % 8, j % 8]));
                }
            }
        }

        private void CuantizareReverse()
        {
            for (int i = 0; i < DimensiunePoza; i++)
            {
                for (int j = 0; j < DimensiunePoza; j++)
                {
                    MatriceDCTYcuantizataReverse[i, j] = MatriceDCTYcuantizata[i, j] * matriceCuantizareY[i % 8, j % 8];
                }
            }

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    MatriceDCTCbcuantizataReverse[i, j] = MatriceDCTCbcuantizata[i, j] * matriceCuantizareY[i % 8, j % 8];
                    MatriceDCTCrcuantizataReverse[i, j] = MatriceDCTCrcuantizata[i, j] * matriceCuantizareCbCr[i % 8, j % 8];
                }
            }
        }

        private void ReverseDCT()
        {
            for (int i = 0; i < DimensiunePoza; i = i + 8)
            {
                for (int j = 0; j < DimensiunePoza; j = j + 8)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            MatriceIDCTY[i, j] += MatriceDCTYcuantizataReverse[i, j] * MatriceCosinus[k, i % 8] * MatriceCosinus[p, j % 8];
                        }
                    }
                    MatriceIDCTY[i, j] = MatriceIDCTY[i, j] * 1 / 4 * cx(i % 8) * cx(j % 8);
                }
            }

            for (int i = 0; i < 128; i=i+8)
            {
                for (int j = 0; j < 128; j = j + 8)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            MatriceIDCTCb[i, j] += MatriceDCTCbcuantizataReverse[i, j] * MatriceCosinus[k, i % 8] * MatriceCosinus[p, j % 8];
                            MatriceIDCTCr[i, j] += MatriceDCTCrcuantizataReverse[i, j] * MatriceCosinus[k, i % 8] * MatriceCosinus[p, j % 8];
                        }
                    }
                    MatriceIDCTCb[i, j] = MatriceIDCTCb[i, j] * 1 / 4 * cx(i % 8) * cx(j % 8);
                    MatriceIDCTCr[i, j] = MatriceIDCTCr[i, j] * 1 / 4 * cx(i % 8) * cx(j % 8);
                }
            }
        }

        private void ReverseSubesantionare()
        {
            for (int i = 0; i < DimensiunePoza; i++)
            {
                for (int j = 0; j < DimensiunePoza; j++)
                {
                    MatriceYsubesantionareReverse[i, j] = (byte)(MatriceIDCTY[i, j]);

                }
            }

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    MatriceCbsubesantionareReverse[i, j] = (byte)(MatriceIDCTCb[i, j]);
                    MatriceCbsubesantionareReverse[i * 2 + 1, j * 2 + 1] = (byte)(MatriceIDCTCb[i, j]);
                    MatriceCrsubesantionareReverse[i, j] = (byte)(MatriceIDCTCr[i, j]);
                    MatriceCrsubesantionareReverse[i * 2 + 1, j * 2 + 1] = (byte)(MatriceIDCTCr[i, j]);
                }
            }
        }

        private void YBCRtoRGB()
        {

            Bitmap PozaRefacuta = new Bitmap(DimensiunePoza, DimensiunePoza);
            Color culoare;

            for (int i = 0; i < DimensiunePoza; i++)
            {
                for (int j = 0; j < DimensiunePoza; j++)
                {
                    RosuRefacut[i, j] = (byte)(MatriceYsubesantionareReverse[i, j] + (1.402 * (MatriceCrsubesantionareReverse[i, j] - 128)));
                    VerdeRefacut[i, j] = (byte)(MatriceYsubesantionareReverse[i, j] - (0.34414 * (MatriceCbsubesantionareReverse[i, j] - 128)) - (0.71414 * (MatriceCrsubesantionareReverse[i, j] - 128)));
                    AlbastruRefacut[i, j] = (byte)(MatriceYsubesantionareReverse[i, j] + (1.772 * (MatriceCbsubesantionareReverse[i, j] - 128)));

                    culoare = Color.FromArgb(RosuRefacut[i, j], VerdeRefacut[i, j], AlbastruRefacut[i, j]);
                    PozaRefacuta.SetPixel(i, j, culoare);
                }
            }
            ReconstructedColorPicture.Image = PozaRefacuta;
        }

        private void btnCalculEroare_Click(object sender, EventArgs e)
        {
            Bitmap Eroare = new Bitmap(256, 256);
            byte factor = Convert.ToByte(tbContrast.Text);
            Color original, refacut;
            double MSE = 0;
            double SNR = 0;
            double numaratorSNR = 0;
            for (int i = 0; i < DimensiunePoza; i++)
            {
                for (int j = 0; j < DimensiunePoza; j++)
                {
                    original = ((Bitmap)ImagineOriginala.Image).GetPixel(i, j);
                    refacut = ((Bitmap)ReconstructedColorPicture.Image).GetPixel(i, j);
                    int pixelOriginal = original.R + original.G + original.B;
                    int pixelRefacut = refacut.R + refacut.G + refacut.B;
                    MSE = MSE + Math.Pow(pixelOriginal - pixelRefacut, 2);
                    numaratorSNR = numaratorSNR + Math.Pow(pixelOriginal, 2);

                    byte RosuEroare = (byte)((original.R - refacut.R) * factor + 128);
                    byte VerdeEroare = (byte)((original.G - refacut.G) * factor + 128);
                    byte AlbastruEroare = (byte)((original.B - refacut.B) * factor + 128);

                    Eroare.SetPixel(i, j, Color.FromArgb(RosuEroare, VerdeEroare, AlbastruEroare));
                }
            }

            textBox4.Text = MSE.ToString();
            SNR = 10 * Math.Log10(numaratorSNR / MSE);
            textBox5.Text = SNR.ToString();
            ErrorColorPicture.Image = Eroare;
        }

        private void ImagineOriginala_Click(object sender, EventArgs e)
        {
            Bitmap original = new Bitmap(8, 8);
            Bitmap refacut = new Bitmap(8, 8);

            for (int x = MousePosition.X; x < MousePosition.X + 8; x++)
            {
                for (int y = MousePosition.Y; y < MousePosition.Y + 8; y++)
                {
                    textBox6.Text += MatriceYorig[x % 8, y % 8].ToString() + " ";
                    textBox7.Text += MatriceDCTY[x % 8, y % 8].ToString() + " ";
                    textBox8.Text += MatriceYsubesantionareReverse[x % 8, y % 8].ToString() + " ";
                    textBox9.Text += matriceCuantizareY[x % 8, y % 8].ToString() + " ";

                    original.SetPixel(x % 8, y % 8, ((Bitmap)ImagineOriginala.Image).GetPixel(x % 8, y % 8));
                    refacut.SetPixel(x % 8, y % 8, ((Bitmap)ReconstructedColorPicture.Image).GetPixel(x % 8, y % 8));
                }
                textBox6.Text += "\r\n";
                textBox7.Text += "\r\n";
                textBox8.Text += "\r\n";
                textBox9.Text += "\r\n";
            }

            pictureBox1.Image = original;
            pictureBox2.Image = refacut;
        }

      
    }
}
