namespace SignalAudio_Recognition
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button recordNewSound;
		private System.Windows.Forms.TextBox nameAudio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox settingSAR;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button refreshDevice;
		private System.Windows.Forms.ListView listDevices;
		private System.Windows.Forms.ColumnHeader sDevice;
		private System.Windows.Forms.ColumnHeader sChannel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox soundList;
		private System.Windows.Forms.Button DeleteSoundDB;
		private System.Windows.Forms.Button PlaySoundDB;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button nomalizeBT;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button fourierBT;


		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		private void InitializeComponent(){
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recordNewSound = new System.Windows.Forms.Button();
            this.nameAudio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingSAR = new System.Windows.Forms.GroupBox();
            this.listDevices = new System.Windows.Forms.ListView();
            this.sDevice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshDevice = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nomalizeBT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DeleteSoundDB = new System.Windows.Forms.Button();
            this.PlaySoundDB = new System.Windows.Forms.Button();
            this.soundList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fourierRecord = new System.Windows.Forms.Button();
            this.recordTwo = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fourierBT = new System.Windows.Forms.Button();
            this.equalsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.settingSAR.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recordNewSound);
            this.groupBox1.Controls.Add(this.nameAudio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Añadir palabras al reconocimiento";
            // 
            // recordNewSound
            // 
            this.recordNewSound.Location = new System.Drawing.Point(194, 62);
            this.recordNewSound.Name = "recordNewSound";
            this.recordNewSound.Size = new System.Drawing.Size(75, 23);
            this.recordNewSound.TabIndex = 2;
            this.recordNewSound.Text = "Grabar";
            this.recordNewSound.UseVisualStyleBackColor = true;
            this.recordNewSound.Click += new System.EventHandler(this.RecordNewSoundClick);
            // 
            // nameAudio
            // 
            this.nameAudio.Location = new System.Drawing.Point(129, 34);
            this.nameAudio.Name = "nameAudio";
            this.nameAudio.Size = new System.Drawing.Size(140, 20);
            this.nameAudio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Palabra / Silaba / Letra:";
            // 
            // settingSAR
            // 
            this.settingSAR.Controls.Add(this.listDevices);
            this.settingSAR.Controls.Add(this.refreshDevice);
            this.settingSAR.Controls.Add(this.label2);
            this.settingSAR.Location = new System.Drawing.Point(12, 12);
            this.settingSAR.Name = "settingSAR";
            this.settingSAR.Size = new System.Drawing.Size(291, 146);
            this.settingSAR.TabIndex = 1;
            this.settingSAR.TabStop = false;
            this.settingSAR.Text = "Ajustes";
            // 
            // listDevices
            // 
            this.listDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sDevice,
            this.sChannel});
            this.listDevices.Location = new System.Drawing.Point(9, 34);
            this.listDevices.MultiSelect = false;
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(272, 66);
            this.listDevices.TabIndex = 3;
            this.listDevices.UseCompatibleStateImageBehavior = false;
            this.listDevices.View = System.Windows.Forms.View.Details;
            // 
            // sDevice
            // 
            this.sDevice.Text = "Dispositivo:";
            this.sDevice.Width = 152;
            // 
            // sChannel
            // 
            this.sChannel.Text = "Canales:";
            this.sChannel.Width = 105;
            // 
            // refreshDevice
            // 
            this.refreshDevice.Location = new System.Drawing.Point(9, 106);
            this.refreshDevice.Name = "refreshDevice";
            this.refreshDevice.Size = new System.Drawing.Size(84, 30);
            this.refreshDevice.TabIndex = 2;
            this.refreshDevice.Text = "Refrescar";
            this.refreshDevice.UseVisualStyleBackColor = true;
            this.refreshDevice.Click += new System.EventHandler(this.RefreshDeviceClick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dispositivos de captura:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nomalizeBT);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.DeleteSoundDB);
            this.groupBox2.Controls.Add(this.PlaySoundDB);
            this.groupBox2.Controls.Add(this.soundList);
            this.groupBox2.Location = new System.Drawing.Point(309, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 243);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base de Datos";
            // 
            // nomalizeBT
            // 
            this.nomalizeBT.Location = new System.Drawing.Point(257, 20);
            this.nomalizeBT.Name = "nomalizeBT";
            this.nomalizeBT.Size = new System.Drawing.Size(75, 23);
            this.nomalizeBT.TabIndex = 4;
            this.nomalizeBT.Text = "Normalizar";
            this.nomalizeBT.UseVisualStyleBackColor = true;
            this.nomalizeBT.Visible = false;
            this.nomalizeBT.Click += new System.EventHandler(this.NomalizeBTClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(176, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 182);
            this.panel1.TabIndex = 3;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(289, 176);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            this.chart1.Visible = false;
            // 
            // DeleteSoundDB
            // 
            this.DeleteSoundDB.Location = new System.Drawing.Point(396, 20);
            this.DeleteSoundDB.Name = "DeleteSoundDB";
            this.DeleteSoundDB.Size = new System.Drawing.Size(75, 23);
            this.DeleteSoundDB.TabIndex = 2;
            this.DeleteSoundDB.Text = "Borrar";
            this.DeleteSoundDB.UseVisualStyleBackColor = true;
            this.DeleteSoundDB.Click += new System.EventHandler(this.DeleteSoundDBClick);
            // 
            // PlaySoundDB
            // 
            this.PlaySoundDB.Location = new System.Drawing.Point(176, 20);
            this.PlaySoundDB.Name = "PlaySoundDB";
            this.PlaySoundDB.Size = new System.Drawing.Size(75, 23);
            this.PlaySoundDB.TabIndex = 1;
            this.PlaySoundDB.Text = "Reproducir";
            this.PlaySoundDB.UseVisualStyleBackColor = true;
            this.PlaySoundDB.Click += new System.EventHandler(this.PlaySoundDBClick);
            // 
            // soundList
            // 
            this.soundList.FormattingEnabled = true;
            this.soundList.Location = new System.Drawing.Point(6, 19);
            this.soundList.Name = "soundList";
            this.soundList.Size = new System.Drawing.Size(158, 212);
            this.soundList.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.equalsButton);
            this.groupBox3.Controls.Add(this.fourierRecord);
            this.groupBox3.Controls.Add(this.recordTwo);
            this.groupBox3.Controls.Add(this.chart2);
            this.groupBox3.Controls.Add(this.fourierBT);
            this.groupBox3.Location = new System.Drawing.Point(12, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(774, 270);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reconocimiento de Voz";
            // 
            // fourierRecord
            // 
            this.fourierRecord.Location = new System.Drawing.Point(138, 19);
            this.fourierRecord.Name = "fourierRecord";
            this.fourierRecord.Size = new System.Drawing.Size(125, 23);
            this.fourierRecord.TabIndex = 3;
            this.fourierRecord.Text = "Fourier Grabacion";
            this.fourierRecord.UseVisualStyleBackColor = true;
            this.fourierRecord.Click += new System.EventHandler(this.FourierRecord_Click);
            // 
            // recordTwo
            // 
            this.recordTwo.Location = new System.Drawing.Point(269, 19);
            this.recordTwo.Name = "recordTwo";
            this.recordTwo.Size = new System.Drawing.Size(75, 23);
            this.recordTwo.TabIndex = 2;
            this.recordTwo.Text = "Grabar";
            this.recordTwo.UseVisualStyleBackColor = true;
            this.recordTwo.Click += new System.EventHandler(this.RecordTwo_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            this.chart2.Location = new System.Drawing.Point(9, 44);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(344, 220);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // fourierBT
            // 
            this.fourierBT.Location = new System.Drawing.Point(18, 19);
            this.fourierBT.Name = "fourierBT";
            this.fourierBT.Size = new System.Drawing.Size(114, 23);
            this.fourierBT.TabIndex = 1;
            this.fourierBT.Text = "Fourier señal BD";
            this.fourierBT.UseVisualStyleBackColor = true;
            this.fourierBT.Click += new System.EventHandler(this.FourierBTClick);
            // 
            // equalsButton
            // 
            this.equalsButton.Location = new System.Drawing.Point(359, 19);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(117, 23);
            this.equalsButton.TabIndex = 4;
            this.equalsButton.Text = "Comparar con BD";
            this.equalsButton.UseVisualStyleBackColor = true;
            this.equalsButton.Click += new System.EventHandler(this.EqualsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 552);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.settingSAR);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "SAR by Charlie Melchiori";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.settingSAR.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button recordTwo;
        private System.Windows.Forms.Button fourierRecord;
        private System.Windows.Forms.Button equalsButton;
    }
}