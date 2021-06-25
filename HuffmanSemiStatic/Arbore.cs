using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Arbore
    {
        Node radacina;

        public Arbore()
        {
            radacina = null;
        }

        public Arbore(char c)
        {
            radacina = new Node(c);
        }

        public Arbore(Node n)
        {
            radacina = n;
        }

        public Node GetRoot()
        {
            return radacina;
        }

        public void SetRoot(Node n)
        {
            radacina = n;
        }
    }
}
