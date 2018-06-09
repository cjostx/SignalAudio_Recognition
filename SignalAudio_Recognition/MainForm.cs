using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using Accord.Audio;
using Accord.Audio.Formats;
using System.Numerics;
using Accord.Audio.Windows;
using Accord.Math;
using Accord.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.Audio.ComplexFilters;
using System.Linq;
using System.Collections;

namespace SignalAudio_Recognition
{
    public partial class MainForm : Form
    {


        //Recorder
        WaveIn sourceStream = null;
        WaveFileWriter waveWriter = null;

        //Play
        WaveFileReader wave = null;
        DirectSoundOut output = null;
        WaveChannel32 wavechannel = null;
        //Plotting
        WaveChannel32 waveSignal = null;
    
        //Fourier
        WaveChannel32 waveSignalRecord = null;

        const int fs = 16384; // Potencia de 2
        const int channel = 1;
        const int secondsRecord = 1;


        const int filter = 2000; //Hz*2
        const int minfilter = 0; //Hz*2

        public MainForm()
		{
			InitializeComponent();
			RefreshListDB();
			DeviceRefreshMethod();
		}
		
		public void RefreshListDB() {
			if (!Directory.Exists("./Sounds")) return;
			soundList.Items.Clear();
			string[] dir_Sounds = Directory.GetFiles("./Sounds");
			foreach (var sound in dir_Sounds)
            {
				if (!(sound.Contains("temp.wav")) && (sound.Contains(".wav"))) {
					soundList.Items.Add(sound.Replace("./Sounds", "").Replace(".wav", "").Replace(((char)92).ToString(), ""));
				}
            }
		}
		
		public void RefreshDeviceClick(object sender, EventArgs e)
		{
			DeviceRefreshMethod();
	        // disable once SuggestUseVarKeywordEvident
		}
		
		private void DeviceRefreshMethod() {
			List<WaveInCapabilities> sources = new List<WaveInCapabilities>();

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                sources.Add(WaveIn.GetCapabilities(i));
            }

            listDevices.Items.Clear();

            foreach (var source in sources)
            {
                var item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                listDevices.Items.Add(item);
            }
		}
		
		void RecordNewSoundClick(object sender, EventArgs e)
		{
			if (listDevices.SelectedItems.Count == 0) {
				MessageBox.Show("Debe Seleccionar algun metodo de captura de la lista.");
				return;
			}
			
			if (nameAudio.Text.Trim() == "") {
				MessageBox.Show("Debe escribir un nombre para el audio.");
				return;
			}
			
			if (!Directory.Exists("./Sounds")) {
				Directory.CreateDirectory("./Sounds");
			}
            
            DisposeWaveRecord();
        
			int deviceNumber = listDevices.SelectedItems[0].Index;

            sourceStream = new WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new WaveFormat(fs, channel);
			sourceStream.DataAvailable += sourceStream_DataAvailable;
			sourceStream.RecordingStopped += sourceStream_sStopped;
			string sfile = nameAudio.Text.Trim();
            waveWriter = new WaveFileWriter("./Sounds/"+sfile+"_raw.wav", sourceStream.WaveFormat);
            sourceStream.StartRecording();
		}
		
		
		void sourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
		    if (waveWriter.Position > sourceStream.WaveFormat.AverageBytesPerSecond * secondsRecord)
		    {
		        sourceStream.StopRecording();
		    }
            waveWriter.Flush();

        }
		
		void sourceStream_sStopped(object sender, StoppedEventArgs e) {
			DisposeWaveRecord();
			//Normalizar señal.
			string sfile = nameAudio.Text.Trim();
			NormalizeSignalFile("./Sounds/"+sfile+"_raw.wav", "./Sounds/"+sfile+".wav");
			File.Delete("./Sounds/"+sfile+"_raw.wav");
			RefreshListDB();			
			MessageBox.Show("Audio Grabado.");
		}

        void sourceStream_sStoppedRecord(object sender, StoppedEventArgs e)
        {
            DisposeWaveRecord();
           // Normalizar señal.
            NormalizeSignalFile("./Sounds/temp_raw.wav", "./Sounds/temp.wav");
            File.Delete("./Sounds/temp_raw.wav");
            RefreshListDB();
            MessageBox.Show("Audio Grabado.");
        }



        void PlaySoundDBClick(object sender, EventArgs e)
		{
			if (soundList.SelectedItems.Count == 0) return;
			if (waveWriter != null) return;
			DisposeWavePlay();
			string sFile = soundList.SelectedItem.ToString();
	       	wave = new WaveFileReader("./Sounds/"+ sFile + ".wav");
	       	waveSignal =  new WaveChannel32(new WaveFileReader("./Sounds/"+ sFile + ".wav"));
            output = new DirectSoundOut();
            wavechannel = new WaveChannel32(wave);          

            chart1.Visible = true;
            chart1.Series.Clear();
            chart1.Series.Add("wave");
            chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series["wave"].ChartArea = "ChartArea1";
            byte[] buffer = new byte[1024];
            int read = 0;          
            while (waveSignal.Position < waveSignal.Length)
            {
                read = waveSignal.Read(buffer, 0, 1024);

                for (int i = 0; i < read / 4; i++)
                {
                    chart1.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
                }
            }
            buffer = null;
            read = 0;
            
            output.Init(wavechannel);
            output.Play();
		}
		
		void DeleteSoundDBClick(object sender, EventArgs e)
		{
			if (soundList.SelectedItems.Count == 0) return;
			try {
				DisposeWavePlay();
				File.Delete("./Sounds/"+ soundList.SelectedItem + ".wav");
			} catch (Exception x) {
				MessageBox.Show("Error al eliminar el archivo wav. "+ x.Message);
			}
			RefreshListDB();
		}
		
		
		private void DisposeWavePlay()
        {
            if (output != null)
            {
                if (output.PlaybackState == PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (wave != null)
            {
                wave.Dispose();
                wave = null;
            }
            if (wavechannel != null) {
            	wavechannel.Dispose();
				wavechannel = null;
            }
            if (waveSignal != null) {
            	waveSignal.Dispose();
            	waveSignal = null;
            }
        }
		
		private void DisposeWaveRecord(){
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
		}
		
		
		private void NormalizeSignalFile(string inPath, string outPath) {
			float max = 0;
			
			using (var reader = new AudioFileReader(inPath))
			{
			    // find the max peak
			    float[] buffer = new float[reader.WaveFormat.SampleRate];
			    int read;
			    do
			    {
			        read = reader.Read(buffer, 0, buffer.Length);
			        for (int n = 0; n < read; n++)
			        {
			            var abs = Math.Abs(buffer[n]);
			            if (abs > max) max = abs;
			        }
			    } while (read > 0);
			    Console.WriteLine("Max sample value: "+max);
			
			    if (max == 0 || max > 1.0f)
			        throw new InvalidOperationException("File cannot be normalized");
			
			    // rewind and amplify
			    reader.Position = 0;
			    reader.Volume = 1.0f / max;
			
			    // write out to a new WAV file
			    WaveFileWriter.CreateWaveFile16(outPath, reader);
                reader.Dispose();
			}
		}
		
		
		void NomalizeBTClick(object sender, EventArgs e)
		{
			if (soundList.SelectedItems.Count == 0) return;
			if (waveWriter != null) return;
			
			string sFile = soundList.SelectedItem.ToString();
			
			NormalizeSignalFile("./Sounds/"+sFile+".wav", "./Sounds/"+sFile+"_n.wav");
			
		}
        void FourierBTClick(object sender, EventArgs e)
        {
            if (soundList.SelectedItems.Count == 0) return;
            if (waveWriter != null) return;

            string sFile = soundList.SelectedItem.ToString();

            ComplexSignal sComplex = FFTComplex(sFile);

            Complex[] channel = sComplex.GetChannel(0);

            chart2.Series.Clear();
            chart2.Series.Add("FFT");
            chart2.Series["FFT"].ChartType = SeriesChartType.FastLine;
            chart2.Series["FFT"].ChartArea = "ChartArea1";


            double[] power = FilterVoiceHz(Accord.Audio.Tools.GetMagnitudeSpectrum(channel));
            double[] freqv = FilterVoiceHz(Accord.Audio.Tools.GetFrequencyVector(sComplex.Length, sComplex.SampleRate));

            for (int i = 1; i < power.Length; i++)
            {
                chart2.Series["FFT"].Points.AddXY(freqv[i], power[i]);
            }


        }

        private void RecordTwo_Click(object sender, EventArgs e)
        {
            if (listDevices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar algun metodo de captura de la lista.");
                return;
            }

            if (!Directory.Exists("./Sounds"))
            {
                Directory.CreateDirectory("./Sounds");
            }

            DisposeWaveRecord();

            int deviceNumber = listDevices.SelectedItems[0].Index;

            sourceStream = new WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new WaveFormat(fs, channel);
            sourceStream.DataAvailable += sourceStream_DataAvailable;
            sourceStream.RecordingStopped += sourceStream_sStoppedRecord;
            string sfile = nameAudio.Text.Trim();
            waveWriter = new WaveFileWriter("./Sounds/temp_raw.wav", sourceStream.WaveFormat);
            sourceStream.StartRecording();

        }

        private void FourierRecord_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./Sounds/temp.wav"))
            {
                return;
            }


            ComplexSignal sComplex = FFTComplex("temp");

            Complex[] channel = sComplex.GetChannel(0);

            chart2.Series.Clear();
            chart2.Series.Add("FFT");
            chart2.Series["FFT"].ChartType = SeriesChartType.FastLine;
            chart2.Series["FFT"].ChartArea = "ChartArea1";


            double[] power = FilterVoiceHz(Accord.Audio.Tools.GetMagnitudeSpectrum(channel));
            double[] freqv = FilterVoiceHz(Accord.Audio.Tools.GetFrequencyVector(sComplex.Length, sComplex.SampleRate));

            for (int i = 1; i < power.Length; i++)
            {
                chart2.Series["FFT"].Points.AddXY(freqv[i] ,power[i]);
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {

            Dictionary<double, string> icorrelation = new Dictionary<double, string>();

            if (!Directory.Exists("./Sounds")) return;
            string[] dir_Sounds = Directory.GetFiles("./Sounds");
            double max = 0;
            foreach (var sound in dir_Sounds)
            {
                if (!(sound.Contains("temp.wav")) && (sound.Contains(".wav")))
                {
                    string name = sound.Replace("./Sounds", "").Replace(".wav", "").Replace(((char)92).ToString(), "");

                    ComplexSignal recordSignal = FFTComplex("temp");
                    Complex[] recordChannel = recordSignal.GetChannel(0);

                    ComplexSignal bd = FFTComplex(name);
                    Complex[] bdchannel = bd.GetChannel(0);

                    double[] rpower = NormalizeStretch(FilterVoiceHz(Accord.Audio.Tools.GetMagnitudeSpectrum(recordChannel)), 0, 1);
                    double[] bdpower = NormalizeStretch(FilterVoiceHz(Accord.Audio.Tools.GetMagnitudeSpectrum(bdchannel)), 0, 1);
                    double corr = ComputeCoeff(bdpower, rpower);
                    Console.WriteLine(name+":"+ corr);
                    icorrelation.Add(corr, name);
                    if (corr >= max)
                    {
                        max = corr;
                    }
                }
            }

            foreach (KeyValuePair<double, string> pair in icorrelation)
            {
                if (pair.Key == max) {
                    MessageBox.Show(pair.Value);
                }
            }

        }

        public ComplexSignal FFTComplex(string sFile)
        {
            WaveDecoder signalwav = new WaveDecoder("./Sounds/" + sFile + ".wav");
            Signal sourceSignal = signalwav.Decode();
            BlackmanWindow window = new BlackmanWindow(fs);
            Signal[] windows = sourceSignal.Split(window, fs);
            Signal wSignal = window.Apply(sourceSignal, fs);
            ComplexSignal sComplex = wSignal.ToComplex();
            sComplex.ForwardFourierTransform();
            signalwav.Close();
            return sComplex;
        }

        public double ComputeCoeff(double[] values1, double[] values2)
        {
            if (values1.Length != values2.Length)
                throw new ArgumentException("values must be the same length");

            var avg1 = values1.Average();
            var avg2 = values2.Average();

            var sum1 = values1.Zip(values2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = values1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = values2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;
        }

        public double[] FilterVoiceHz(double[] complex)
        {
            double[] x = new double[filter-minfilter];
            for (int i = minfilter; i <= filter-1; i++)
            {
                x[i-minfilter] = complex[i];
               //Console.WriteLine(i - minfilter);
            }
            return x;
            //return NormalizeStretch(x, 0, 1);
        }

        public double[] NormalizeStretch(double[] array, double newMin, double newMax)
        {
            return array;
            double minValue = double.MaxValue;
            double maxValue = double.MinValue;

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] < minValue) minValue = array[index];
                if (array[index] > maxValue) maxValue = array[index];
            }

            double scaler = (newMax - newMin) / (maxValue - minValue);

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = (array[index] - minValue) * scaler + newMin;
            }

            return array;
        }

    }
}
