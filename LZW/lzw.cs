using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW_Forms
{
    class lzw
    {
        public Dictionary<int, string> DictionarDeCaractere;
        public int Index;
        public int IndexMaxim;
        public bool Inghetare;

        public lzw() { }

        public lzw(bool Inghetare, int Index)
        {
            this.Inghetare = Inghetare;
            this.Index = Index;
            IndexMaxim = Convert.ToInt32(Math.Pow(2, Index) - 1);
            DictionarDeCaractere = new Dictionary<int, string>(IndexMaxim);


        }

        public void IncarcareParteFixa(Dictionary<int, string> dictionar)
        {
            char c;
            string temp;
            for(var i = 0; i < 256; i++)
            {
                c = (char)i;
                temp = c.ToString();
                dictionar.Add(i, temp);
            }
        }


        public void ReadInput(string FisierIntrare)
        {
            using (BitReader br = new BitReader(FisierIntrare))
            {
                FileInfo f = new FileInfo(FisierIntrare);
                var l = 8 * f.Length;

                string caracter = "";
                List<string> lista;

                int IndexStart = DictionarDeCaractere.Count;

                while(l > 0)
                {
                    int c = br.ReadNBits(8);
                    char cToChar = (char)c;
                    string cToCharToString = cToChar.ToString();

                    int IndexCaracter = IndexDinDictionar(DictionarDeCaractere, caracter + cToCharToString);

                    if((IndexCaracter < 0) && (IndexCaracter <= IndexMaxim))
                    {
                        caracter = caracter + cToCharToString;
                    }
                    else
                    {
                        if(DictionarDeCaractere.Count > IndexMaxim)
                        {
                            if(Inghetare == false)
                            {
                                DictionarDeCaractere.Clear();
                                IncarcareParteFixa(DictionarDeCaractere);
                            }
                        }

                        lista = new List<string>();
                        lista.Add(caracter + cToCharToString);
                        lista.Add(caracter);
                        string swaping = lista[0];
                        DictionarDeCaractere.Add(IndexStart, swaping);
                        IndexStart++;

                        caracter = cToCharToString;
                    }

                    l -= 8; 
                }
            }

        }

        public void ScrieInFisier(string fisier)
        {
            using (BitWriter bw = new BitWriter(fisier))
            {
                int valueIndex = 0;

                foreach (KeyValuePair<int, string> symbol in DictionarDeCaractere)
                {
                    int ele = 0;

                    if(symbol.Key != 256)
                    {
                         ele = symbol.Value[1];
                    }
                    else
                    {
                         ele = symbol.Value[0];
                    }

                    valueIndex = IndexDinDictionar(DictionarDeCaractere, ele.ToString());
                    bw.WriteNBits(valueIndex, Index);
                }
            }
        }

        private int IndexDinDictionar(Dictionary<int, string> DictionarDeCaractere, string v)
        {
            string aux; 

            foreach (KeyValuePair<int, string> symbol in DictionarDeCaractere)
            {
                aux = symbol.Value;

                if (aux == v)
                {
                    return symbol.Key;
                }
            }

            return -1;
        }

    }
}
