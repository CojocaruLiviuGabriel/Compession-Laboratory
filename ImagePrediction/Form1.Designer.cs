namespace Prediction
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.pozaOriginala = new System.Windows.Forms.PictureBox();
            this.btnPredict = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.matriceEroare = new System.Windows.Forms.PictureBox();
            this.scalareErrorMatrix = new System.Windows.Forms.NumericUpDown();
            this.btnShowErrorMatrix = new System.Windows.Forms.Button();
            this.pozaDecodata = new System.Windows.Forms.PictureBox();
            this.btnLoadEncoded = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnSaveDecoded = new System.Windows.Forms.Button();
            this.radio128 = new System.Windows.Forms.RadioButton();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioAplusBminusC = new System.Windows.Forms.RadioButton();
            this.radioAplusBminusCpeDoi = new System.Windows.Forms.RadioButton();
            this.radioBplusAminusCpeDoi = new System.Windows.Forms.RadioButton();
            this.radioAplusBpeDoi = new System.Windows.Forms.RadioButton();
            this.radioJpegLS = new System.Windows.Forms.RadioButton();
            this.radioOriginalHistograma = new System.Windows.Forms.RadioButton();
            this.radioErrorHistograma = new System.Windows.Forms.RadioButton();
            this.radioDecodedHistograma = new System.Windows.Forms.RadioButton();
            this.numericHistograma = new System.Windows.Forms.NumericUpDown();
            this.btnArataHistograma = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grupPredictie = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pozaOriginala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matriceEroare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalareErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozaDecodata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHistograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.grupPredictie.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 288);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // pozaOriginala
            // 
            this.pozaOriginala.Location = new System.Drawing.Point(12, 12);
            this.pozaOriginala.Name = "pozaOriginala";
            this.pozaOriginala.Size = new System.Drawing.Size(256, 256);
            this.pozaOriginala.TabIndex = 1;
            this.pozaOriginala.TabStop = false;
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(102, 287);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(75, 23);
            this.btnPredict.TabIndex = 2;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(193, 288);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(75, 23);
            this.btnStore.TabIndex = 3;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // matriceEroare
            // 
            this.matriceEroare.Location = new System.Drawing.Point(376, 12);
            this.matriceEroare.Name = "matriceEroare";
            this.matriceEroare.Size = new System.Drawing.Size(256, 256);
            this.matriceEroare.TabIndex = 4;
            this.matriceEroare.TabStop = false;
            // 
            // scalareErrorMatrix
            // 
            this.scalareErrorMatrix.Location = new System.Drawing.Point(376, 290);
            this.scalareErrorMatrix.Name = "scalareErrorMatrix";
            this.scalareErrorMatrix.Size = new System.Drawing.Size(50, 20);
            this.scalareErrorMatrix.TabIndex = 5;
            // 
            // btnShowErrorMatrix
            // 
            this.btnShowErrorMatrix.Location = new System.Drawing.Point(464, 288);
            this.btnShowErrorMatrix.Name = "btnShowErrorMatrix";
            this.btnShowErrorMatrix.Size = new System.Drawing.Size(123, 23);
            this.btnShowErrorMatrix.TabIndex = 6;
            this.btnShowErrorMatrix.Text = "Show error matrix";
            this.btnShowErrorMatrix.UseVisualStyleBackColor = true;
            this.btnShowErrorMatrix.Click += new System.EventHandler(this.btnShowErrorMatrix_Click);
            // 
            // pozaDecodata
            // 
            this.pozaDecodata.Location = new System.Drawing.Point(752, 12);
            this.pozaDecodata.Name = "pozaDecodata";
            this.pozaDecodata.Size = new System.Drawing.Size(256, 256);
            this.pozaDecodata.TabIndex = 7;
            this.pozaDecodata.TabStop = false;
            // 
            // btnLoadEncoded
            // 
            this.btnLoadEncoded.Location = new System.Drawing.Point(744, 287);
            this.btnLoadEncoded.Name = "btnLoadEncoded";
            this.btnLoadEncoded.Size = new System.Drawing.Size(85, 23);
            this.btnLoadEncoded.TabIndex = 8;
            this.btnLoadEncoded.Text = "Load encoded";
            this.btnLoadEncoded.UseVisualStyleBackColor = true;
            this.btnLoadEncoded.Click += new System.EventHandler(this.btnLoadEncoded_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(835, 287);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 9;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnSaveDecoded
            // 
            this.btnSaveDecoded.Location = new System.Drawing.Point(917, 287);
            this.btnSaveDecoded.Name = "btnSaveDecoded";
            this.btnSaveDecoded.Size = new System.Drawing.Size(91, 23);
            this.btnSaveDecoded.TabIndex = 10;
            this.btnSaveDecoded.Text = "Save decoded";
            this.btnSaveDecoded.UseVisualStyleBackColor = true;
            this.btnSaveDecoded.Click += new System.EventHandler(this.btnSaveDecoded_Click);
            // 
            // radio128
            // 
            this.radio128.AutoSize = true;
            this.radio128.Location = new System.Drawing.Point(6, 26);
            this.radio128.Name = "radio128";
            this.radio128.Size = new System.Drawing.Size(43, 17);
            this.radio128.TabIndex = 11;
            this.radio128.TabStop = true;
            this.radio128.Text = "128";
            this.radio128.UseVisualStyleBackColor = true;
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Location = new System.Drawing.Point(6, 49);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(32, 17);
            this.radioA.TabIndex = 12;
            this.radioA.TabStop = true;
            this.radioA.Text = "A";
            this.radioA.UseVisualStyleBackColor = true;
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(6, 73);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(32, 17);
            this.radioB.TabIndex = 13;
            this.radioB.TabStop = true;
            this.radioB.Text = "B";
            this.radioB.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Location = new System.Drawing.Point(6, 97);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(32, 17);
            this.radioC.TabIndex = 14;
            this.radioC.TabStop = true;
            this.radioC.Text = "C";
            this.radioC.UseVisualStyleBackColor = true;
            // 
            // radioAplusBminusC
            // 
            this.radioAplusBminusC.AutoSize = true;
            this.radioAplusBminusC.Location = new System.Drawing.Point(7, 121);
            this.radioAplusBminusC.Name = "radioAplusBminusC";
            this.radioAplusBminusC.Size = new System.Drawing.Size(67, 17);
            this.radioAplusBminusC.TabIndex = 15;
            this.radioAplusBminusC.TabStop = true;
            this.radioAplusBminusC.Text = "A + B - C";
            this.radioAplusBminusC.UseVisualStyleBackColor = true;
            // 
            // radioAplusBminusCpeDoi
            // 
            this.radioAplusBminusCpeDoi.AutoSize = true;
            this.radioAplusBminusCpeDoi.Location = new System.Drawing.Point(7, 145);
            this.radioAplusBminusCpeDoi.Name = "radioAplusBminusCpeDoi";
            this.radioAplusBminusCpeDoi.Size = new System.Drawing.Size(102, 17);
            this.radioAplusBminusCpeDoi.TabIndex = 16;
            this.radioAplusBminusCpeDoi.TabStop = true;
            this.radioAplusBminusCpeDoi.Text = "A + ( B - C )  /  2";
            this.radioAplusBminusCpeDoi.UseVisualStyleBackColor = true;
            // 
            // radioBplusAminusCpeDoi
            // 
            this.radioBplusAminusCpeDoi.AutoSize = true;
            this.radioBplusAminusCpeDoi.Location = new System.Drawing.Point(6, 169);
            this.radioBplusAminusCpeDoi.Name = "radioBplusAminusCpeDoi";
            this.radioBplusAminusCpeDoi.Size = new System.Drawing.Size(102, 17);
            this.radioBplusAminusCpeDoi.TabIndex = 17;
            this.radioBplusAminusCpeDoi.TabStop = true;
            this.radioBplusAminusCpeDoi.Text = "B + ( A - C )  /  2";
            this.radioBplusAminusCpeDoi.UseVisualStyleBackColor = true;
            // 
            // radioAplusBpeDoi
            // 
            this.radioAplusBpeDoi.AutoSize = true;
            this.radioAplusBpeDoi.Location = new System.Drawing.Point(6, 193);
            this.radioAplusBpeDoi.Name = "radioAplusBpeDoi";
            this.radioAplusBpeDoi.Size = new System.Drawing.Size(86, 17);
            this.radioAplusBpeDoi.TabIndex = 18;
            this.radioAplusBpeDoi.TabStop = true;
            this.radioAplusBpeDoi.Text = "( A + B )  /  2";
            this.radioAplusBpeDoi.UseVisualStyleBackColor = true;
            // 
            // radioJpegLS
            // 
            this.radioJpegLS.AutoSize = true;
            this.radioJpegLS.Location = new System.Drawing.Point(6, 217);
            this.radioJpegLS.Name = "radioJpegLS";
            this.radioJpegLS.Size = new System.Drawing.Size(58, 17);
            this.radioJpegLS.TabIndex = 19;
            this.radioJpegLS.TabStop = true;
            this.radioJpegLS.Text = "jpegLS";
            this.radioJpegLS.UseVisualStyleBackColor = true;
            // 
            // radioOriginalHistograma
            // 
            this.radioOriginalHistograma.AutoSize = true;
            this.radioOriginalHistograma.Location = new System.Drawing.Point(278, 447);
            this.radioOriginalHistograma.Name = "radioOriginalHistograma";
            this.radioOriginalHistograma.Size = new System.Drawing.Size(60, 17);
            this.radioOriginalHistograma.TabIndex = 20;
            this.radioOriginalHistograma.TabStop = true;
            this.radioOriginalHistograma.Text = "Original";
            this.radioOriginalHistograma.UseVisualStyleBackColor = true;
            // 
            // radioErrorHistograma
            // 
            this.radioErrorHistograma.AutoSize = true;
            this.radioErrorHistograma.Location = new System.Drawing.Point(278, 471);
            this.radioErrorHistograma.Name = "radioErrorHistograma";
            this.radioErrorHistograma.Size = new System.Drawing.Size(97, 17);
            this.radioErrorHistograma.TabIndex = 21;
            this.radioErrorHistograma.TabStop = true;
            this.radioErrorHistograma.Text = "Error Prediction";
            this.radioErrorHistograma.UseVisualStyleBackColor = true;
            // 
            // radioDecodedHistograma
            // 
            this.radioDecodedHistograma.AutoSize = true;
            this.radioDecodedHistograma.Location = new System.Drawing.Point(278, 495);
            this.radioDecodedHistograma.Name = "radioDecodedHistograma";
            this.radioDecodedHistograma.Size = new System.Drawing.Size(69, 17);
            this.radioDecodedHistograma.TabIndex = 22;
            this.radioDecodedHistograma.TabStop = true;
            this.radioDecodedHistograma.Text = "Decoded";
            this.radioDecodedHistograma.UseVisualStyleBackColor = true;
            // 
            // numericHistograma
            // 
            this.numericHistograma.Location = new System.Drawing.Point(278, 519);
            this.numericHistograma.Name = "numericHistograma";
            this.numericHistograma.Size = new System.Drawing.Size(50, 20);
            this.numericHistograma.TabIndex = 23;
            this.numericHistograma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnArataHistograma
            // 
            this.btnArataHistograma.Location = new System.Drawing.Point(278, 557);
            this.btnArataHistograma.Name = "btnArataHistograma";
            this.btnArataHistograma.Size = new System.Drawing.Size(97, 23);
            this.btnArataHistograma.TabIndex = 24;
            this.btnArataHistograma.Text = "Show Histogram";
            this.btnArataHistograma.UseVisualStyleBackColor = true;
            this.btnArataHistograma.Click += new System.EventHandler(this.btnArataHistograma_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(406, 344);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(687, 319);
            this.chart1.TabIndex = 25;
            this.chart1.Text = "histogramaReprezentata";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grupPredictie
            // 
            this.grupPredictie.Controls.Add(this.radioAplusBminusCpeDoi);
            this.grupPredictie.Controls.Add(this.radio128);
            this.grupPredictie.Controls.Add(this.radioA);
            this.grupPredictie.Controls.Add(this.radioB);
            this.grupPredictie.Controls.Add(this.radioC);
            this.grupPredictie.Controls.Add(this.radioAplusBminusC);
            this.grupPredictie.Controls.Add(this.radioBplusAminusCpeDoi);
            this.grupPredictie.Controls.Add(this.radioJpegLS);
            this.grupPredictie.Controls.Add(this.radioAplusBpeDoi);
            this.grupPredictie.Location = new System.Drawing.Point(12, 318);
            this.grupPredictie.Name = "grupPredictie";
            this.grupPredictie.Size = new System.Drawing.Size(200, 248);
            this.grupPredictie.TabIndex = 26;
            this.grupPredictie.TabStop = false;
            this.grupPredictie.Text = "Optiuni predictor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 675);
            this.Controls.Add(this.grupPredictie);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnArataHistograma);
            this.Controls.Add(this.numericHistograma);
            this.Controls.Add(this.radioDecodedHistograma);
            this.Controls.Add(this.radioErrorHistograma);
            this.Controls.Add(this.radioOriginalHistograma);
            this.Controls.Add(this.btnSaveDecoded);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncoded);
            this.Controls.Add(this.pozaDecodata);
            this.Controls.Add(this.btnShowErrorMatrix);
            this.Controls.Add(this.scalareErrorMatrix);
            this.Controls.Add(this.matriceEroare);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.pozaOriginala);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pozaOriginala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matriceEroare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalareErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozaDecodata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHistograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.grupPredictie.ResumeLayout(false);
            this.grupPredictie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox pozaOriginala;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.PictureBox matriceEroare;
        private System.Windows.Forms.NumericUpDown scalareErrorMatrix;
        private System.Windows.Forms.Button btnShowErrorMatrix;
        private System.Windows.Forms.PictureBox pozaDecodata;
        private System.Windows.Forms.Button btnLoadEncoded;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnSaveDecoded;
        private System.Windows.Forms.RadioButton radio128;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioAplusBminusC;
        private System.Windows.Forms.RadioButton radioAplusBminusCpeDoi;
        private System.Windows.Forms.RadioButton radioBplusAminusCpeDoi;
        private System.Windows.Forms.RadioButton radioAplusBpeDoi;
        private System.Windows.Forms.RadioButton radioJpegLS;
        private System.Windows.Forms.RadioButton radioOriginalHistograma;
        private System.Windows.Forms.RadioButton radioErrorHistograma;
        private System.Windows.Forms.RadioButton radioDecodedHistograma;
        private System.Windows.Forms.NumericUpDown numericHistograma;
        private System.Windows.Forms.Button btnArataHistograma;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox grupPredictie;
    }
}

