namespace CodareLZ
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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelPathFisierIncarcat = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnEncodeFile = new System.Windows.Forms.Button();
            this.checkBoxTokens = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnLoadEncodedFile = new System.Windows.Forms.Button();
            this.btnDecodeFile = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.labelPathFisierCodat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(35, 242);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelPathFisierIncarcat
            // 
            this.labelPathFisierIncarcat.AutoSize = true;
            this.labelPathFisierIncarcat.Location = new System.Drawing.Point(41, 371);
            this.labelPathFisierIncarcat.Name = "labelPathFisierIncarcat";
            this.labelPathFisierIncarcat.Size = new System.Drawing.Size(35, 13);
            this.labelPathFisierIncarcat.TabIndex = 1;
            this.labelPathFisierIncarcat.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(159, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // btnEncodeFile
            // 
            this.btnEncodeFile.Location = new System.Drawing.Point(35, 271);
            this.btnEncodeFile.Name = "btnEncodeFile";
            this.btnEncodeFile.Size = new System.Drawing.Size(75, 23);
            this.btnEncodeFile.TabIndex = 4;
            this.btnEncodeFile.Text = "Encode file";
            this.btnEncodeFile.UseVisualStyleBackColor = true;
            this.btnEncodeFile.Click += new System.EventHandler(this.Button1_Click);
            // 
            // checkBoxTokens
            // 
            this.checkBoxTokens.AutoSize = true;
            this.checkBoxTokens.Location = new System.Drawing.Point(180, 162);
            this.checkBoxTokens.Name = "checkBoxTokens";
            this.checkBoxTokens.Size = new System.Drawing.Size(92, 17);
            this.checkBoxTokens.TabIndex = 5;
            this.checkBoxTokens.Text = "Show Tokens";
            this.checkBoxTokens.UseVisualStyleBackColor = true;
            this.checkBoxTokens.CheckStateChanged += new System.EventHandler(this.checkBoxTokens_CheckStateChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(180, 186);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 108);
            this.listBox1.TabIndex = 6;
            // 
            // btnLoadEncodedFile
            // 
            this.btnLoadEncodedFile.Location = new System.Drawing.Point(590, 242);
            this.btnLoadEncodedFile.Name = "btnLoadEncodedFile";
            this.btnLoadEncodedFile.Size = new System.Drawing.Size(109, 23);
            this.btnLoadEncodedFile.TabIndex = 7;
            this.btnLoadEncodedFile.Text = "Load encoded file";
            this.btnLoadEncodedFile.UseVisualStyleBackColor = true;
            this.btnLoadEncodedFile.Click += new System.EventHandler(this.btnLoadEncodedFile_Click);
            // 
            // btnDecodeFile
            // 
            this.btnDecodeFile.Location = new System.Drawing.Point(590, 270);
            this.btnDecodeFile.Name = "btnDecodeFile";
            this.btnDecodeFile.Size = new System.Drawing.Size(109, 23);
            this.btnDecodeFile.TabIndex = 8;
            this.btnDecodeFile.Text = "Decode file";
            this.btnDecodeFile.UseVisualStyleBackColor = true;
            this.btnDecodeFile.Click += new System.EventHandler(this.btnDecodeFile_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // labelPathFisierCodat
            // 
            this.labelPathFisierCodat.AutoSize = true;
            this.labelPathFisierCodat.Location = new System.Drawing.Point(590, 370);
            this.labelPathFisierCodat.Name = "labelPathFisierCodat";
            this.labelPathFisierCodat.Size = new System.Drawing.Size(35, 13);
            this.labelPathFisierCodat.TabIndex = 9;
            this.labelPathFisierCodat.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelPathFisierCodat);
            this.Controls.Add(this.btnDecodeFile);
            this.Controls.Add(this.btnLoadEncodedFile);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.checkBoxTokens);
            this.Controls.Add(this.btnEncodeFile);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelPathFisierIncarcat);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelPathFisierIncarcat;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnEncodeFile;
        private System.Windows.Forms.CheckBox checkBoxTokens;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnLoadEncodedFile;
        private System.Windows.Forms.Button btnDecodeFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label labelPathFisierCodat;
    }
}

