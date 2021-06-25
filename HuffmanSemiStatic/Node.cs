using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Node
    {
        Node parinte, left, right;
        int aparatie;
        char caracter;
        string cod;

        public Node(char NodNou)
        {
            
            parinte = null;
            left = null;
            right = null;
            aparatie = 0;
            caracter = NodNou;
        }


        public Node GetParinte()
        {
            return parinte;
        }

        public void SetParinte(Node n)
        {
            parinte = n;
        }

        public Node GetLeftChild()
        {
            return left;
        }

        public void SetLeftChild(Node n)
        {
            left = n;
        }

        public Node GetRightChild()
        {
            return right;
        }

        public void SetRightChild(Node n)
        {
            right = n;
        }

        public int GetAparitie()
        {
            return aparatie;
        }

        public void SetAparitie(int a)
        {
            aparatie = a;
        }

        public char GetCaracter()
        {
            return caracter;
        }

        public void SetCaracter(char c)
        {
            caracter = c;
        }

        public string GetCod()
        {
            return cod;
        }

        public void SetCod(string s)
        {
            cod = s;
        }

    }
}
