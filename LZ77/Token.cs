using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodareLZ
{
    class Token
    {
        public int pozitie;
        public int lungime;
        public char caracter;
        public Token() { }
        public Token(int pozitie, int lungime, char caracter)
        {
            this.pozitie = pozitie;
            this.lungime = lungime;
            this.caracter = caracter;
        }

        public int GetPozitie()
        {
            return pozitie;
        }

        public int GetLungime()
        {
            return lungime;
        }

        public char GetCaracter()
        {
            return caracter;
        }

        public void SetPozitie(int p)
        {
            pozitie = p;
        }

        public void SetLungime(int l)
        {
            lungime = l;
        }

        public void SetCaracter(char c)
        {
            caracter = c;
        }
    }
}
