namespace LZW_Forms
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
            this.comboBoxNrBiti = new System.Windows.Forms.ComboBox();
            this.btnEncodeFile = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBoxTokens = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radioButtonFreeze = new System.Windows.Forms.RadioButton();
            this.radioButtonEmpty = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadEncodedFile = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(24, 157);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // comboBoxNrBiti
            // 
            this.comboBoxNrBiti.FormattingEnabled = true;
            this.comboBoxNrBiti.Location = new System.Drawing.Point(24, 25);
            this.comboBoxNrBiti.Name = "comboBoxNrBiti";
            this.comboBoxNrBiti.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNrBiti.TabIndex = 1;
            // 
            // btnEncodeFile
            // 
            this.btnEncodeFile.Location = new System.Drawing.Point(24, 202);
            this.btnEncodeFile.Name = "btnEncodeFile";
            this.btnEncodeFile.Size = new System.Drawing.Size(75, 23);
            this.btnEncodeFile.TabIndex = 3;
            this.btnEncodeFile.Text = "Encode";
            this.btnEncodeFile.UseVisualStyleBackColor = true;
            this.btnEncodeFile.Click += new System.EventHandler(this.btnEncodeFile_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(164, 157);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(140, 147);
            this.listBox1.TabIndex = 4;
            // 
            // checkBoxTokens
            // 
            this.checkBoxTokens.AutoSize = true;
            this.checkBoxTokens.Location = new System.Drawing.Point(164, 134);
            this.checkBoxTokens.Name = "checkBoxTokens";
            this.checkBoxTokens.Size = new System.Drawing.Size(88, 17);
            this.checkBoxTokens.TabIndex = 5;
            this.checkBoxTokens.Text = "Show tokens";
            this.checkBoxTokens.UseVisualStyleBackColor = true;
            this.checkBoxTokens.CheckStateChanged += new System.EventHandler(this.checkBoxTokens_CheckStateChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radioButtonFreeze
            // 
            this.radioButtonFreeze.AutoSize = true;
            this.radioButtonFreeze.Location = new System.Drawing.Point(216, 25);
            this.radioButtonFreeze.Name = "radioButtonFreeze";
            this.radioButtonFreeze.Size = new System.Drawing.Size(57, 17);
            this.radioButtonFreeze.TabIndex = 6;
            this.radioButtonFreeze.TabStop = true;
            this.radioButtonFreeze.Text = "Freeze";
            this.radioButtonFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonFreeze.UseVisualStyleBackColor = true;
            // 
            // radioButtonEmpty
            // 
            this.radioButtonEmpty.AutoSize = true;
            this.radioButtonEmpty.Location = new System.Drawing.Point(216, 49);
            this.radioButtonEmpty.Name = "radioButtonEmpty";
            this.radioButtonEmpty.Size = new System.Drawing.Size(54, 17);
            this.radioButtonEmpty.TabIndex = 7;
            this.radioButtonEmpty.TabStop = true;
            this.radioButtonEmpty.Text = "Empty";
            this.radioButtonEmpty.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // btnLoadEncodedFile
            // 
            this.btnLoadEncodedFile.Location = new System.Drawing.Point(582, 157);
            this.btnLoadEncodedFile.Name = "btnLoadEncodedFile";
            this.btnLoadEncodedFile.Size = new System.Drawing.Size(109, 23);
            this.btnLoadEncodedFile.TabIndex = 10;
            this.btnLoadEncodedFile.Text = "Load encoded file";
            this.btnLoadEncodedFile.UseVisualStyleBackColor = true;
            this.btnLoadEncodedFile.Click += new System.EventHandler(this.btnLoadEncodedFile_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(582, 201);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(109, 23);
            this.btnDecode.TabIndex = 11;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncodedFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonEmpty);
            this.Controls.Add(this.radioButtonFreeze);
            this.Controls.Add(this.checkBoxTokens);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnEncodeFile);
            this.Controls.Add(this.comboBoxNrBiti);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.ComboBox comboBoxNrBiti;
        private System.Windows.Forms.Button btnEncodeFile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBoxTokens;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioButtonFreeze;
        private System.Windows.Forms.RadioButton radioButtonEmpty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadEncodedFile;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

