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

namespace Prediction
{
    public partial class Form1 : Form
    {
        Predictie predictie = new Predictie();
        string cale = "";
        string caleCodata = "";
        int[] antetPoza = new int[1078];
        int[,] matricePozaOriginala;
        int[,] matricePozaPredictie;
        int[,] matricePozaEroare;
        int[,] matricePozaDecodare;

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.Minimum = -256;
            chart1.ChartAreas[0].AxisX.Maximum = 256;
            chart1.ChartAreas[0].AxisY.Maximum = 300;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cale = openFileDialog1.FileName;
                FileStream fs = new FileStream(cale, FileMode.Open, FileAccess.Read);
                pozaOriginala.Image = Image.FromStream(fs);
                fs.Close();
                antetPoza = predictie.CitesteAntetPoza(cale);
                matricePozaOriginala = predictie.CitesteMatricePoza(cale);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int OptiuneHistograma()
        {
            if (radioOriginalHistograma.Checked)
            {
                return 1;
            }
            else if (radioErrorHistograma.Checked)
            {
                return 2;
            }
            else if (radioDecodedHistograma.Checked)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        private void btnArataHistograma_Click(object sender, EventArgs e)
        {
            int optiune = OptiuneHistograma();
            int[] frecvente = null;
            int[] valoriAxa = null;

            switch (optiune)
            {
                case 1:
                    {
                        frecvente = predictie.ValoriHistograma(matricePozaOriginala, 256);
                        valoriAxa = predictie.ValoriAxa();
                        break;
                    }
                case 2:
                    {
                        frecvente = predictie.ValoriHistograma(matricePozaEroare, 256);
                        valoriAxa = predictie.ValoriAxa();
                        break;
                    }
                case 3:
                    {
                        frecvente = predictie.ValoriHistograma(matricePozaDecodare, 256);
                        valoriAxa = predictie.ValoriAxa();
                        break;
                    }

            }
            
            chart1.Series[0].Points.DataBindXY(valoriAxa, frecvente);
        }

        private int OptiunePredictie()
        {
            if (radio128.Checked)
            {
                return 1;
            }
            else if (radioA.Checked)
            {
                return 2;
            }
            else if (radioB.Checked)
            {
                return 3;
            }
            else if (radioC.Checked)
            {
                return 4;
            }
            else if (radioAplusBminusC.Checked)
            {
                return 5;
            }
            else if (radioAplusBminusCpeDoi.Checked)
            {
                return 6;
            }
            else if (radioBplusAminusCpeDoi.Checked)
            {
                return 7;
            }
            else if (radioAplusBpeDoi.Checked)
            {
                return 8;
            }
            else if (radioJpegLS.Checked)
            {
                return 9;
            }
            else
            {
                return 0;
            }
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            int optiune = OptiunePredictie();

            switch (optiune)
            {
                case 1:
                    {
                        matricePozaPredictie = predictie.Predictie128(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 2:
                    {
                        matricePozaPredictie = predictie.PredictieA(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 3:
                    {
                        matricePozaPredictie = predictie.PredictieB(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 4:
                    {
                        matricePozaPredictie = predictie.PredictieC(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 5:
                    {
                        matricePozaPredictie = predictie.PredictieAplusBminusC(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 6:
                    {
                        matricePozaPredictie = predictie.PredictieAplusBminusCpeDoi(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 7:
                    {
                        matricePozaPredictie = predictie.PredictieBPlusAminusCpeDoi(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 8:
                    {
                        matricePozaPredictie = predictie.PredictieAplusBpeDoi(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
                case 9:
                    {
                        matricePozaPredictie = predictie.PredictieJpegLS(matricePozaOriginala);
                        matricePozaEroare = predictie.calculMatriceEroare(matricePozaOriginala);
                        break;
                    }
            }
        }

        private void btnShowErrorMatrix_Click(object sender, EventArgs e)
        {
            float scalar = (float)scalareErrorMatrix.Value;
            Bitmap bitmap = new Bitmap(256, 256);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    Color t = Color.FromArgb((byte)(128 + matricePozaEroare[i, j] * scalar),
                                             (byte)(128 + matricePozaEroare[i, j] * scalar),
                                             (byte)(128 + matricePozaEroare[i, j] * scalar));

                    bitmap.SetPixel(i, j, t);
                }
            }
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
            matriceEroare.Image = bitmap;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            int optiune = OptiunePredictie();
            cale = cale + "[" + (optiune - 1).ToString() + "].pre";

            predictie.ScrieAntet(antetPoza, cale);

            using (BitWriter bw = new BitWriter(cale))
            {
                bw.WriteNBits((optiune - 1), 4);
            }

            predictie.ScrieMatriceEroareInFisier(matricePozaEroare, cale);

        }

        private void btnLoadEncoded_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "pre files (*.pre)|*.pre";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                caleCodata = openFileDialog.FileName;
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            int optiune = OptiunePredictie();

            switch (optiune)
            {
                case 1:
                    {
                        matricePozaDecodare = predictie.DecodareMatrice128(matricePozaEroare);
                        break;
                    }
                case 2:
                    {
                        matricePozaDecodare = predictie.PredictieA(matricePozaEroare);
                        break;
                    }
                case 3:
                    {
                        matricePozaDecodare = predictie.PredictieB(matricePozaEroare);
                        break;
                    }
                case 4:
                    {
                        matricePozaDecodare = predictie.PredictieC(matricePozaEroare);
                        break;
                    }
                case 5:
                    {
                        matricePozaDecodare = predictie.PredictieAplusBminusC(matricePozaEroare);
                        break;
                    }
                case 6:
                    {
                        matricePozaDecodare = predictie.PredictieAplusBminusCpeDoi(matricePozaEroare);
                        break;
                    }
                case 7:
                    {
                        matricePozaDecodare = predictie.PredictieBPlusAminusCpeDoi(matricePozaEroare);
                        break;
                    }
                case 8:
                    {
                        matricePozaDecodare = predictie.PredictieAplusBpeDoi(matricePozaEroare);
                        break;
                    }
                case 9:
                    {
                        matricePozaDecodare = predictie.PredictieJpegLS(matricePozaEroare);
                        break;
                    }
            }
        }

        private void btnSaveDecoded_Click(object sender, EventArgs e)
        {
            caleCodata = caleCodata + ".decoded";
            Bitmap bitmap = new Bitmap(256, 256);

            using (BitWriter bw = new BitWriter(cale))
            {
                for (int i = 0; i < 1078; i++)
                {
                    bw.WriteNBits(antetPoza[i], 8);
                }

                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        bw.WriteNBits(matricePozaDecodare[i, j], 8);
                        Color t = Color.FromArgb((byte)(matricePozaDecodare[i, j]),
                                                 (byte)(matricePozaDecodare[i, j]),
                                                 (byte)(matricePozaDecodare[i, j]));

                        bitmap.SetPixel(i, j, t);
                    }
                }
            }

            bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pozaDecodata.Image = bitmap;
        }
    }
}
