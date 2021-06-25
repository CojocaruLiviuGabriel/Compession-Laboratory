
namespace jpeg
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ImagineOriginala = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ReconstructedColorPicture = new System.Windows.Forms.PictureBox();
            this.ErrorColorPicture = new System.Windows.Forms.PictureBox();
            this.btnTransDirect = new System.Windows.Forms.Button();
            this.rbPrimaMetoda = new System.Windows.Forms.RadioButton();
            this.rbDouaMetoda = new System.Windows.Forms.RadioButton();
            this.rbTreiaMetoda = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnTransformareInversa = new System.Windows.Forms.Button();
            this.btnCalculEroare = new System.Windows.Forms.Button();
            this.tbContrast = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagineOriginala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReconstructedColorPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorColorPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagineOriginala
            // 
            this.ImagineOriginala.Location = new System.Drawing.Point(34, 32);
            this.ImagineOriginala.Name = "ImagineOriginala";
            this.ImagineOriginala.Size = new System.Drawing.Size(256, 256);
            this.ImagineOriginala.TabIndex = 0;
            this.ImagineOriginala.TabStop = false;
            this.ImagineOriginala.Click += new System.EventHandler(this.ImagineOriginala_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(34, 316);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ReconstructedColorPicture
            // 
            this.ReconstructedColorPicture.Location = new System.Drawing.Point(558, 32);
            this.ReconstructedColorPicture.Name = "ReconstructedColorPicture";
            this.ReconstructedColorPicture.Size = new System.Drawing.Size(256, 256);
            this.ReconstructedColorPicture.TabIndex = 2;
            this.ReconstructedColorPicture.TabStop = false;
            // 
            // ErrorColorPicture
            // 
            this.ErrorColorPicture.Location = new System.Drawing.Point(1072, 32);
            this.ErrorColorPicture.Name = "ErrorColorPicture";
            this.ErrorColorPicture.Size = new System.Drawing.Size(256, 256);
            this.ErrorColorPicture.TabIndex = 3;
            this.ErrorColorPicture.TabStop = false;
            // 
            // btnTransDirect
            // 
            this.btnTransDirect.Location = new System.Drawing.Point(126, 315);
            this.btnTransDirect.Name = "btnTransDirect";
            this.btnTransDirect.Size = new System.Drawing.Size(117, 23);
            this.btnTransDirect.TabIndex = 4;
            this.btnTransDirect.Text = "Transformare Directa";
            this.btnTransDirect.UseVisualStyleBackColor = true;
            this.btnTransDirect.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbPrimaMetoda
            // 
            this.rbPrimaMetoda.AutoSize = true;
            this.rbPrimaMetoda.Location = new System.Drawing.Point(300, 319);
            this.rbPrimaMetoda.Name = "rbPrimaMetoda";
            this.rbPrimaMetoda.Size = new System.Drawing.Size(59, 17);
            this.rbPrimaMetoda.TabIndex = 5;
            this.rbPrimaMetoda.TabStop = true;
            this.rbPrimaMetoda.Text = "ZigZag";
            this.rbPrimaMetoda.UseVisualStyleBackColor = true;
            // 
            // rbDouaMetoda
            // 
            this.rbDouaMetoda.AutoSize = true;
            this.rbDouaMetoda.Location = new System.Drawing.Point(300, 354);
            this.rbDouaMetoda.Name = "rbDouaMetoda";
            this.rbDouaMetoda.Size = new System.Drawing.Size(91, 17);
            this.rbDouaMetoda.TabIndex = 6;
            this.rbDouaMetoda.TabStop = true;
            this.rbDouaMetoda.Text = "MatriceSimpla";
            this.rbDouaMetoda.UseVisualStyleBackColor = true;
            // 
            // rbTreiaMetoda
            // 
            this.rbTreiaMetoda.AutoSize = true;
            this.rbTreiaMetoda.Location = new System.Drawing.Point(300, 391);
            this.rbTreiaMetoda.Name = "rbTreiaMetoda";
            this.rbTreiaMetoda.Size = new System.Drawing.Size(82, 17);
            this.rbTreiaMetoda.TabIndex = 7;
            this.rbTreiaMetoda.TabStop = true;
            this.rbTreiaMetoda.Text = "FactorJPEG";
            this.rbTreiaMetoda.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(400, 319);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(400, 354);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(400, 390);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 10;
            // 
            // btnTransformareInversa
            // 
            this.btnTransformareInversa.Location = new System.Drawing.Point(126, 347);
            this.btnTransformareInversa.Name = "btnTransformareInversa";
            this.btnTransformareInversa.Size = new System.Drawing.Size(117, 23);
            this.btnTransformareInversa.TabIndex = 11;
            this.btnTransformareInversa.Text = "Transformare Invers";
            this.btnTransformareInversa.UseVisualStyleBackColor = true;
            this.btnTransformareInversa.Click += new System.EventHandler(this.btnTransformareInversa_Click);
            // 
            // btnCalculEroare
            // 
            this.btnCalculEroare.Location = new System.Drawing.Point(1072, 350);
            this.btnCalculEroare.Name = "btnCalculEroare";
            this.btnCalculEroare.Size = new System.Drawing.Size(117, 23);
            this.btnCalculEroare.TabIndex = 12;
            this.btnCalculEroare.Text = "Calcul Eroare";
            this.btnCalculEroare.UseVisualStyleBackColor = true;
            this.btnCalculEroare.Click += new System.EventHandler(this.btnCalculEroare_Click);
            // 
            // tbContrast
            // 
            this.tbContrast.Location = new System.Drawing.Point(1121, 313);
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(100, 20);
            this.tbContrast.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1069, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Contrast";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1164, 382);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 17;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1164, 411);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1092, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "MSE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1092, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "SNR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y DCT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(624, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Y Refacut";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(914, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Cuantizare";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(12, 514);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(179, 112);
            this.textBox6.TabIndex = 25;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(253, 514);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(179, 112);
            this.textBox7.TabIndex = 26;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(567, 514);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(179, 112);
            this.textBox8.TabIndex = 27;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(856, 514);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(179, 112);
            this.textBox9.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(531, 367);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(682, 367);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(528, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Original";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(682, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Refacut";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 661);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbContrast);
            this.Controls.Add(this.btnCalculEroare);
            this.Controls.Add(this.btnTransformareInversa);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rbTreiaMetoda);
            this.Controls.Add(this.rbDouaMetoda);
            this.Controls.Add(this.rbPrimaMetoda);
            this.Controls.Add(this.btnTransDirect);
            this.Controls.Add(this.ErrorColorPicture);
            this.Controls.Add(this.ReconstructedColorPicture);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.ImagineOriginala);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImagineOriginala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReconstructedColorPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorColorPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagineOriginala;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox ReconstructedColorPicture;
        private System.Windows.Forms.PictureBox ErrorColorPicture;
        private System.Windows.Forms.Button btnTransDirect;
        private System.Windows.Forms.RadioButton rbPrimaMetoda;
        private System.Windows.Forms.RadioButton rbDouaMetoda;
        private System.Windows.Forms.RadioButton rbTreiaMetoda;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnTransformareInversa;
        private System.Windows.Forms.Button btnCalculEroare;
        private System.Windows.Forms.TextBox tbContrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

