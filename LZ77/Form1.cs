using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodareLZ
{
    public partial class Form1 : Form
    {
        LZ77 obj = new LZ77();
        string CaleFisierIncarcat, FisierCodatIesire, CaleFisierCodat, CaleFisierDecodat;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Biti pentru pozitie");
            comboBox2.Items.Add("Biti pentru lungime");

            for (int i = 3; i <= 15; i++)
            {
                comboBox1.Items.Add(Convert.ToString(i));
            }
            for (int i = 2; i <= 7; i++)
            {
                comboBox2.Items.Add(Convert.ToString(i));
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            labelPathFisierIncarcat.Text = "";
            labelPathFisierCodat.Text = "";

            if (checkBoxTokens.Checked == true)
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
                CaleFisierIncarcat = openFileDialog1.FileName;
                FisierCodatIesire = CaleFisierIncarcat+".ext"+".o"+ comboBox1.SelectedIndex.ToString() + "l" + comboBox2.SelectedIndex.ToString() + ".lz77"; 
                labelPathFisierIncarcat.Text = CaleFisierIncarcat;
            }
        }

        private void checkBoxTokens_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxTokens.Checked == true)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }
        }

        private void btnDecodeFile_Click(object sender, EventArgs e)
        {
            obj.CitesteAntetCodat(CaleFisierCodat);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            obj.ScrieAntet(Convert.ToInt32(comboBox1.SelectedIndex), Convert.ToInt32(comboBox2.SelectedIndex), FisierCodatIesire);
            obj.Encode(Convert.ToInt32(comboBox1.SelectedIndex),Convert.ToInt32(comboBox2.SelectedIndex),CaleFisierIncarcat,FisierCodatIesire);
            listBox1.DataSource = new BindingSource(obj.listaT, null);
        }

        private void btnLoadEncodedFile_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "lz77 files (*.lz77)|*.lz77";
            openFileDialog2.RestoreDirectory = true;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                CaleFisierCodat = openFileDialog2.FileName;
                CaleFisierDecodat = CaleFisierCodat + System.IO.Path.GetExtension(CaleFisierIncarcat);
                labelPathFisierCodat.Text = CaleFisierCodat;
            }
        }
    }
}
