using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Huffman
{
    public partial class Form1 : Form
    {
        CodareHuffman h = new CodareHuffman();
        Arbore arbore = new Arbore();
        string cale;
        string iesire;
        char[] InputArea;
        int[] FqInputArea = new int[256];
        string ExtensieFisier;

        public Form1()
        {
            InitializeComponent();
            if (checkBoxSimbol.Checked == true)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }

        }

        
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cale = openFileDialog1.FileName;
                iesire = cale + ".hs";
                
            }


        }

        private void btnEncodeFile_Click(object sender, EventArgs e)
        {
            h.Encode(cale, iesire);
            listBox1.DataSource = new BindingSource(h.caracterCod, null);
        }

        private void checkBoxSimbol_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxSimbol.Checked == true)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }
        }

        private void btnEncodeInputText_Click(object sender, EventArgs e)
        {

            string iesire =  "Input.hs";
            string intrare = "Input.txt";

            File.WriteAllText(intrare, textBox1.Text);
            InputArea = textBox1.Text.ToCharArray();
            
            
            for(var i = 0; i < InputArea.Length; i++)
            {   
                FqInputArea[InputArea[i]]++;
            }

            List<Arbore> arb = new List<Arbore>();
            arb = h.SortareArbore(FqInputArea);

            Arbore Huffman = new Arbore();
            Huffman = h.ArboreHuffman(arb);

            h.Codare("", Huffman.GetRoot());

            h.ScrieFisierCodat(intrare, iesire);
            listBox1.DataSource = new BindingSource(h.caracterCod, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "hs files (*.hs)|*.hs";
            openFileDialog2.RestoreDirectory = true;

            DateTime date = DateTime.Now;
            String d = date.ToShortDateString() + "-" + date.ToShortTimeString();
            Console.WriteLine(d);
            d = d.Replace('/', '-');
            d = d.Replace(":", "-");


            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                cale = openFileDialog2.FileName;
                ExtensieFisier = Path.GetExtension(cale);
                iesire = cale +"."+ d + ExtensieFisier;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h.Decode(cale, iesire);
        }
    }
}
