using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZW_Forms
{
    public partial class Form1 : Form
    {
        string CaleFisierIncarcat, CaleIesireFisierCodat, FsauE, CaleFisierCodat, CaleFisierDecodat;

        public Form1()
        {
            InitializeComponent();
            comboBoxNrBiti.Items.Add("Biti pentru lungime");

            for (int i = 9; i <= 15; i++)
            {
                comboBoxNrBiti.Items.Add(Convert.ToString(i));
            }
            comboBoxNrBiti.SelectedIndex = 0;

            if (checkBoxTokens.Checked == true)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }

            label1.Text = "";
            label2.Text = "";

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

        private void btnDecode_Click(object sender, EventArgs e)
        {
            int[] head = new int[2];
            using (BitReader br = new BitReader(CaleFisierCodat))
            {
                head[0] = br.ReadNBits(4);
                head[1] = br.ReadNBits(1);
            }

            using (BitWriter bw = new BitWriter(CaleFisierDecodat))
            {
                bw.WriteNBits(head[0], 4);
                bw.WriteNBits(head[1], 1);
            }
        }

        private void btnLoadEncodedFile_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "LZW files (*.LZW)|*.LZW";
            openFileDialog2.RestoreDirectory = true;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                CaleFisierCodat = openFileDialog2.FileName;
                CaleFisierDecodat = CaleFisierCodat + System.IO.Path.GetExtension(CaleFisierIncarcat);
                label2.Text = CaleFisierCodat;
            }
        }

        private void btnEncodeFile_Click(object sender, EventArgs e)
        {
            bool mod;

            if (radioButtonFreeze.Checked == true)
            {
                mod = true;
            }
            else
            {
                mod = false;
            }

            lzw obj = new lzw(mod, Convert.ToInt32(comboBoxNrBiti.SelectedIndex));

            using (BitWriter bw = new BitWriter(CaleIesireFisierCodat))
            {
                bw.WriteNBits(Convert.ToInt32(comboBoxNrBiti.SelectedIndex), 4);

                if (radioButtonFreeze.Checked == true)
                {
                    bw.WriteNBits(1, 1);
                }
                else
                {
                    bw.WriteNBits(0, 1);
                }

            }

            obj.ReadInput(CaleFisierIncarcat);

            listBox1.DataSource = new BindingSource(obj.DictionarDeCaractere, null);

            obj.ScrieInFisier(CaleIesireFisierCodat);

            using (BitWriter bw = new BitWriter(CaleIesireFisierCodat))
            {
                for(var i = 1; i <= 7; i++)
                {
                    bw.WriteNBits(1, 1);
                }
            }



        }
    
        

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            

            if(radioButtonFreeze.Checked == true)
            {
                FsauE = "f";
            }
            else if(radioButtonEmpty.Checked == true)
            {
                FsauE = "e";
            }

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CaleFisierIncarcat = openFileDialog1.FileName;
                CaleIesireFisierCodat = CaleFisierIncarcat + "." + FsauE + "l" + comboBoxNrBiti.SelectedItem.ToString() + ".LZW";
                label1.Text = CaleFisierIncarcat;
            }

        }
    }
}
