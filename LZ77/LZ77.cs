using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodareLZ
{
    class LZ77
    {
        Token token = new Token();
        Token temp;
        List<char> buff = new List<char>();
        public List<Token> listaT = new List<Token>();

        public void CitesteFisier(string FisierIntrare)
        {
            using (BitReader br = new BitReader(FisierIntrare))
            {
                FileInfo f = new FileInfo(FisierIntrare);
                var l = 8 * f.Length;

                while (l > 0)
                {
                    int c = br.ReadNBits(8);
                    buff.Add(Convert.ToChar(c));
                    l -= 8;
                }
            }
        }

        public void ScrieAntet(int ValoarePozitie,int ValoareLungime, string FisierIesire)
        {
            using (BitWriter bw = new BitWriter(FisierIesire))
            {
                bw.WriteNBits(ValoarePozitie, 4);
                bw.WriteNBits(ValoareLungime, 3);
            }
        }

        public void Encode(int NrBitiPozitie, int NrBitiLungime, string FisierIntrare ,string FisierIesire)
        {

            CitesteFisier(FisierIntrare);

            char[] sb = new char[buff.Count];
            int indexLAB = 0;

            while (indexLAB < buff.Count - 1)
            {
                if (sb.Contains(buff[indexLAB]))
                {
                    
                    token.lungime++;
                    token.pozitie++;

                    for (var i = token.pozitie; i < sb.Length; i++)
                    {
                        var aux = indexLAB;
                        if (sb[i] == buff[aux])
                        {
                            token.lungime++;
                        }
                    }
                    indexLAB++;
                }
                else
                {
                    using (BitWriter bw = new BitWriter(FisierIesire))
                    {
                        bw.WriteNBits(token.pozitie, NrBitiPozitie);
                        bw.WriteNBits(token.lungime, NrBitiLungime);
                        bw.WriteNBits(buff[indexLAB], 8);
                    }

                    temp = new Token(token.GetPozitie(), token.GetLungime(), token.GetCaracter());
                    listaT.Add(temp);
                    sb[indexLAB] += buff[indexLAB];
                    token.lungime = 0;
                    token.pozitie = 0;
                    indexLAB++;

                }

                


            }

            using (BitWriter bw = new BitWriter(FisierIesire))
            {
                bw.WriteNBits(0, 7);
            }
        }

        public void CitesteAntetCodat(string FisierIntrare)
        {
            int BitiPozitie;
            int BitiLungime;

            List<int> InfoAntet = new List<int>();

            using (BitReader br = new BitReader(FisierIntrare))
            {
                BitiPozitie = br.ReadNBits(4);
                InfoAntet.Add(BitiPozitie);
                BitiLungime = br.ReadNBits(3);
                InfoAntet.Add(BitiLungime);
            }
        }

        public void ScrieFisierDecodat(int BitiPentruPozitie, int BitiPentruLungime)
        {

        }
    }
}
