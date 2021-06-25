using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class CodareHuffman
    {
        private int[] Frecvente = new int[256];
        private int[] FrecventeDecodare = new int[256];
        private int MarimeFisierComprimat = 0;
        public Dictionary<int, string> caracterCod = new Dictionary<int, string>();
        
        public CodareHuffman()
        {
            for(int i = 0; i < Frecvente.Length; i++)
            {
                Frecvente[i] = 0;
                FrecventeDecodare[i] = 0;
            }
            
        }

        public void statistica(string fisierDeCitit)
        {     
            FileInfo f = new FileInfo(fisierDeCitit);
            long lungime = 8 * f.Length;
            using (var br = new BitReader(fisierDeCitit))
            {
                for (var i = lungime; i > 0; i -= 8)
                {
                    int c = br.ReadNBits(8);
                    Frecvente[c]++;
                }
            }       
        }

        public void CitesteStatisticaDinFisier(string f)
        {
            List<int> c = new List<int>();

            using (BitReader br = new BitReader(f))
            {
                for(var i = 0; i < FrecventeDecodare.Length; i++)
                {
                    FrecventeDecodare[i] = br.ReadBit();
                    if(FrecventeDecodare[i] == i)
                    {
                        c.Add(i);
                    }
                    MarimeFisierComprimat++;
                }

                for(var i = 0; i < c.Count; i++)
                {
                    FrecventeDecodare[i] = (int)br.ReadNBits(32);
                    MarimeFisierComprimat += 32;
                }
            }
        }

        public List<Arbore> adaugaFrecventeInListaNode(int[] frec)
        {
            List<Arbore> listaNoduri = new List<Arbore>();
            Node deBagatInLista;

            for(int i = 0; i < frec.Length; i++)
            {
                if(frec[i] != 0)
                {
                    deBagatInLista = new Node((char)i);
                    deBagatInLista.SetAparitie(Frecvente[i]);

                    listaNoduri.Add(new Arbore(deBagatInLista));
                }
            }

            return listaNoduri;
        }


        public List<Arbore> SortareArbore(int[] f /*List<Node> n*/)
        {
            List<Arbore> a = new List<Arbore>();
            a = adaugaFrecventeInListaNode(f);
            a.Sort((x, y) => x.GetRoot().GetAparitie().CompareTo(y.GetRoot().GetAparitie()));
            return a;
        }

        public Arbore ArboreHuffman(List <Arbore> nodes)
        {
            Arbore a;
            Node aux;

            while (nodes.Count != 1)
            {
                aux = new Node((char)(nodes.ElementAt(0).GetRoot().GetCaracter() + nodes.ElementAt(1).GetRoot().GetCaracter()));
                aux.SetAparitie(nodes.ElementAt(0).GetRoot().GetAparitie() + nodes.ElementAt(1).GetRoot().GetAparitie());
                aux.SetParinte(null);
                aux.SetLeftChild(nodes.ElementAt(0).GetRoot());
                aux.SetRightChild(nodes.ElementAt(1).GetRoot());

                a = new Arbore(aux);

                nodes.ElementAt(0).GetRoot().SetParinte(a.GetRoot());
                nodes.ElementAt(1).GetRoot().SetParinte(a.GetRoot());

                nodes.ElementAt(0).GetRoot().SetCod("0");
                nodes.ElementAt(1).GetRoot().SetCod("1");

                nodes.RemoveRange(0, 2);
                nodes.Insert(0, a);

                nodes.Sort((x, y) => x.GetRoot().GetAparitie().CompareTo(y.GetRoot().GetAparitie()));

            }

            return nodes.ElementAt(0);
        }

        private void ScrieAntet(string FisierIesire)
        {

            using (var bw = new BitWriter(FisierIesire))
            {
                for (var i = 0; i < Frecvente.Length; i++)
                {
                    if (Frecvente[i] == 0)
                    {
                        bw.WriteBit(0);
                    }
                    else
                    {
                        bw.WriteBit(1);
                    }
                }

                for (var i = 0; i < Frecvente.Length; i++)
                {
                    if (Frecvente[i] != 0)
                    {
                        bw.WriteNBits(Frecvente[i], 32);
                    }
                }
            }
            
        }

        public void Codare(string cod, Node n)
        {

            if (n == null)
            {
                return;
            }

            if (n.GetLeftChild() == null && n.GetRightChild() == null)
            {
                n.SetCod(cod);
                caracterCod.Add(n.GetCaracter(), n.GetCod());
                //Console.WriteLine(n.GetCaracter() + " - " + n.GetCod());
                return;
            }

            Codare(cod + "0", n.GetLeftChild());
            Codare(cod + "1", n.GetRightChild());

        }

        public void ScrieFisierCodat(string FisierIntrare, string FisierIesire)
        {
            

            FileInfo f = new FileInfo(FisierIntrare);
            var l = 8 * f.Length;
         
            ScrieAntet(FisierIesire);

            using (var br = new BitReader(FisierIntrare))
            {
                using (var bw = new BitWriter(FisierIesire))
                {
                    while (l > 0)
                    {
                        int c = br.ReadNBits(8);
                        bw.WriteNBits(caracterCod[c][0], caracterCod[c][0]);
                        l -= 8;
                    }

                    bw.WriteNBits(0, 7);
                }
            }
        }

        public void DecodeazaFisier(Arbore t, string intrare, string iesire)
        {
            Node node;
            
            FileInfo f = new FileInfo(intrare);
            var l = 8 * f.Length;

            int BitCurent;
            using (BitReader br = new BitReader(intrare))
            {
                for (var i = 0; i < MarimeFisierComprimat; i++)
                {
                    BitCurent = br.ReadBit();
                }
            }

            int noBitsToBeReadFromFile = 0;
            int noBitsRead = 0;
            bool endOfDataStream = true;

            List<int> charactersAppeared = new List<int>();
            using (BitReader bitReader = new BitReader(intrare))
            {
                using (BitWriter bitWriter = new BitWriter(iesire))
                {
                    while (endOfDataStream == true)
                    {
                        int noBitsOfCopmpressCode = 0; //pe cati biti e scris codul

                        node = t.GetRoot();

                        while( (node.GetLeftChild() != null) && (node.GetRightChild() != null ))
                        {
                            noBitsRead++;
                            noBitsOfCopmpressCode++;

                            BitCurent = bitReader.ReadBit();
                            if (BitCurent == 0)
                            {
                                node = node.GetLeftChild();
                            }
                            else
                            {
                                node = node.GetRightChild();
                            }
                        }

                        var character = node.GetCaracter();
                        var characterFrequency = FrecventeDecodare[character];

                        if (!charactersAppeared.Contains(character))
                        {
                            charactersAppeared.Add(character);
                            noBitsToBeReadFromFile += characterFrequency * noBitsOfCopmpressCode;
                        }

                        if (noBitsRead > noBitsToBeReadFromFile)
                        {
                            endOfDataStream = false;
                        }
                        else
                        {
                            bitWriter.WriteNBits(node.GetCaracter(), 8);
                        }

                    }
                }
            }
        }

        public void Encode(string FisierIntare, string FisierIesire)
        {
            statistica(FisierIntare);

            List<Arbore> arb = new List<Arbore>();
            arb = SortareArbore(Frecvente);

            Arbore Huffman = new Arbore();
            Huffman = ArboreHuffman(arb);

            Codare("", Huffman.GetRoot());

            ScrieFisierCodat(FisierIntare, FisierIesire);

        }

        public void decompress(string inputFile, string outputFile)
        {
            //1. Preluare statistica
            CitesteStatisticaDinFisier(inputFile);

            //2. Construire model
            List<Arbore> sortedListOfTrees = new List<Arbore>();
            sortedListOfTrees = SortareArbore(FrecventeDecodare);

            Arbore huffmanTree = new Arbore();
            huffmanTree = ArboreHuffman(sortedListOfTrees);

            //3. Creeaza fisier decomprimat
            DecodeazaFisier(huffmanTree,inputFile, outputFile);

        }

        public void Decode(string inputFile, string outputFile)
        {
            decompress(inputFile, outputFile);
        }



    }
}
