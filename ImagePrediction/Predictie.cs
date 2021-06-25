using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction
{
    class Predictie
    {
        const uint marimePoza = 256;
        const uint bitmapHeaderLungime = 1078;
        int[] bitmapHeaderDate = new int[bitmapHeaderLungime];
        int[,] matricePoza = new int[marimePoza, marimePoza];
        int[,] matriceEroare = new int[marimePoza, marimePoza];
        int[,] matricePredictie = new int[marimePoza, marimePoza];

        #region Antet
        public int[] CitesteAntetPoza(string pozaDeCitit)
        {
            using (BitReader br = new BitReader(pozaDeCitit))
            {
                for (int i = 0; i < bitmapHeaderLungime; i++)
                {
                    bitmapHeaderDate[i] = br.ReadNBits(8);
                }
            }

            return bitmapHeaderDate;
        }

        public void ScrieAntet(int[] antet, string cale)
        {
            using (BitWriter bw = new BitWriter(cale))
            {
                for (int i = 0; i < bitmapHeaderLungime; i++)
                {
                    bw.WriteNBits(antet[i], 8);
                }
            }
        }
        #endregion
        public int[,] CitesteMatricePoza(string pozaDeCitit)
        {

            using (BitReader br = new BitReader(pozaDeCitit))
            {
                for (int i = 0; i < bitmapHeaderLungime; i++)
                {
                    bitmapHeaderDate[i] = br.ReadNBits(8);
                }

                for (int i = 0; i < marimePoza; i++)
                {
                    for (int j = 0; j < marimePoza; j++)
                    {
                        matricePoza[i, j] = br.ReadNBits(8);
                    }
                }
            }

            return matricePoza;
        }

        public void ScrieMatriceEroareInFisier(int[,] matErr, string cale)
        {
            using (BitWriter bw = new BitWriter(cale))
            {
                for (int i = 0; i < marimePoza; i++)
                {
                    for (int j = 0; j < marimePoza; j++)
                    {
                        if (matriceEroare[i, j] >= 0)
                        {
                            bw.WriteBit(0);
                            bw.WriteNBits(matriceEroare[i, j], 8);
                        }
                        else
                        {
                            bw.WriteBit(1);
                            bw.WriteNBits(matriceEroare[i, j], 8);
                        }
                    }
                }
            }
        }
        #region Histograma
        public int[] ValoriHistograma(int[,] matrice, uint marimeMatrice)
        {
            int[] frecvente = new int[marimeMatrice];

            for (int i = 0; i < frecvente.Length; i++)
            {
                frecvente[i] = 0;
            }

            for (int i = 0; i < marimeMatrice; i++)
            {
                for (int j = 0; j < marimeMatrice; j++)
                {
                    int valoare = matrice[i, j];
                    if (valoare < 0)
                    {
                        valoare = 0;
                    }
                    else if (valoare > 255)
                    {
                        valoare = 255;
                    }
                    if (valoare != 0)
                    {
                        frecvente[valoare]++;
                    }

                }
            }

            return frecvente;
        }

        public int[] ValoriAxa()
        {
            int[] valori = new int[marimePoza];

            for (int i = 0; i < 256; i++)
            {
                valori[i] = i;
            }

            return valori;
        }
        #endregion
        public int[,] calculMatriceEroare(int[,] matricePoza)
        {

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceEroare[i, j] = matricePoza[i, j] - matricePredictie[i, j];
                }
            }

            return matriceEroare;
        }

        #region Codari
        public int[,] Predictie128(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[0, j] = matricePoza[0, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, 0] = matricePoza[i - 1, 0];
                    }
                    else if (i != 0 && j != 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }

            return matricePredictie;
        }

        public int[,] PredictieA(int[,] matricePoza)
        {

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }

            return matricePredictie;
        }

        public int[,] PredictieB(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }

        public int[,] PredictieC(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j - 1];
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }

        public int[,] PredictieAplusBminusC(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1]/*A*/ + matricePoza[i - 1, j]/*B*/ - matricePoza[i - 1, j - 1]/*C*/;
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }

        public int[,] PredictieAplusBminusCpeDoi(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = (matricePoza[i, j - 1]/*A*/ + (matricePoza[i - 1, j]/*B*/ - matricePoza[i - 1, j - 1])/*C*/) / 2;
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }

        public int[,] PredictieBPlusAminusCpeDoi(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = (matricePoza[i - 1, j]/*B*/ + (matricePoza[i, j - 1]/*A*/ - matricePoza[i - 1, j - 1])/*C*/) / 2;
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }

        public int[,] PredictieAplusBpeDoi(int[,] matricePoza)
        {
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        matricePredictie[i, j] = (matricePoza[i, j - 1]/*A*/ + matricePoza[i - 1, j]/*B*/) / 2;
                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }

        public int[,] PredictieJpegLS(int[,] matricePoza)
        {

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePredictie[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePredictie[i, j] = matricePoza[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePredictie[i, j] = matricePoza[i - 1, j];
                    }
                    else
                    {
                        int A = matricePoza[i, j - 1];
                        int B = matricePoza[i - 1, j];
                        int max = Math.Max(A, B);
                        int min = Math.Min(A, B);

                        if (matricePoza[i - 1, j - 1]/*C*/ <= min)
                        {
                            matricePredictie[i, j] = max;
                        }
                        if (matricePoza[i - 1, j - 1]/*C*/ >= max)
                        {
                            matricePredictie[i, j] = min;
                        }
                        else
                        {
                            matricePredictie[i, j] = A + B - matricePoza[i - 1, j - 1]/*C*/;
                        }

                    }
                    if (matricePredictie[i, j] > 255)
                    {
                        matricePredictie[i, j] = 255;
                    }
                    else if (matricePredictie[i, j] < 0)
                    {
                        matricePredictie[i, j] = 0;
                    }
                }
            }
            return matricePredictie;
        }
        #endregion

        #region Decodari
        public int[,] DecodareMatrice128(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[0, j] = matCodata[0, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, 0] = matCodata[i - 1, 0];
                    }
                    else if (i != 0 && j != 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for(int i = 0; i < marimePoza; i++)
            {
                for(int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceA(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceB(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceC(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = matCodata[i - 1, j - 1];
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceAplusBminusC(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = matCodata[i, j - 1]/*A*/ + matCodata[i - 1, j]/*B*/ - matCodata[i - 1, j - 1]/*C*/;
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceAplusBminusCpeDoi(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = (matCodata[i, j - 1]/*A*/ + (matCodata[i - 1, j]/*B*/ - matCodata[i - 1, j - 1])/*C*/) / 2;
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceBplusAminusCpeDoi(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = (matCodata[i - 1, j]/*B*/ + (matCodata[i, j - 1]/*A*/ - matCodata[i - 1, j - 1])/*C*/) / 2;
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceAplusBpeDoi(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        matricePred[i, j] = (matCodata[i, j - 1]/*A*/ + matCodata[i - 1, j]/*B*/) / 2;
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }

        public int[,] DecodareMatriceJpegLS(int[,] matCodata)
        {
            int[,] matricePred = new int[marimePoza, marimePoza];
            int[,] matriceDeAfisat = new int[marimePoza, marimePoza];
            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matricePred[i, j] = 128;
                    }
                    else if (i == 0 && j != 0)
                    {
                        matricePred[i, j] = matCodata[i, j - 1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        matricePred[i, j] = matCodata[i - 1, j];
                    }
                    else
                    {
                        int A = matCodata[i, j - 1];
                        int B = matCodata[i - 1, j];
                        int max = Math.Max(A, B);
                        int min = Math.Min(A, B);

                        if (matCodata[i - 1, j - 1]/*C*/ <= min)
                        {
                            matricePred[i, j] = max;
                        }
                        if (matCodata[i - 1, j - 1]/*C*/ >= max)
                        {
                            matricePred[i, j] = min;
                        }
                        else
                        {
                            matricePred[i, j] = A + B - matCodata[i - 1, j - 1]/*C*/;
                        }
                    }
                    if (matricePred[i, j] > 255)
                    {
                        matricePred[i, j] = 255;
                    }
                    else if (matricePred[i, j] < 0)
                    {
                        matricePred[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < marimePoza; i++)
            {
                for (int j = 0; j < marimePoza; j++)
                {
                    matriceDeAfisat[i, j] = matCodata[i, j] + matricePred[i, j];
                }
            }

            return matriceDeAfisat;
        }
        #endregion
    }
}
