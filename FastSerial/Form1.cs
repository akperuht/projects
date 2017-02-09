using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.IO;

namespace FastSerial
{
    public partial class FastSerial : Form
    {
        private SerialPort port;
        private Stopwatch kello;
        private String[] portit;
        private String nykyinenPortti;
        private PlotModel plotModel1;
        private LineSeries series1;
        private Thread controlThread = null;
        private Thread plotThread = null;
        private PlotUpdate updater;
        private bool livetracking = false;
        private string filename = null;
        private long deviceStart = 0;
        private List<DataPoint> data = new List<DataPoint> { };
        private Processing process = new Processing();
        public FastSerial()
        {
            alusta();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Start();
            timer.Tick += delegate { Opacity = 100; };
        }
        /// <summary>
        /// Alustaa koko paskan
        /// </summary>
        private void alusta()
        {
            LuoPlotterit();
            DefineSerial();
            Saikeet();
        }

        /// <summary>
        /// Tyhjentää kaikki ruudut
        /// </summary>
        /// <param name="series1"></param>
        /// <param name="series2"></param>
        /// <param name="plotModel1"></param>
        private void Clear()
        {
                series1.Points.Clear();
                plotModel1.InvalidatePlot(true);
                kello.Restart();
        }
        /// <summary>
        /// Alustetaan portit
        /// </summary>
        private void DefineSerial()
        {
            kello = new Stopwatch();
            portit = SerialPort.GetPortNames();
            if (portit.Length != 0)
            {
                nykyinenPortti = portit[0];
                ///Alustetaan usb-portti
                port = new SerialPort(nykyinenPortti, 115200);
                ///Tarvitaan Arduino Leonardolle
                port.RtsEnable = true;
                port.DtrEnable = true;
                port.Open();
                port.DataReceived += delegate
                {
                    AddNewData();
                };
            }
        }
        /// <summary>
        /// luo hakutut plotModelit
        /// </summary>
        private void LuoPlotterit()
        {
            this.InitializeComponent();
            plotModel1 = new PlotModel { Title = "Serial data" };

            plotModel1.Axes.Add(new LinearAxis {
                Position = AxisPosition.Bottom,
                Title = "Time (ms)",
                TicklineColor = OxyColors.White
            });
            plotModel1.Axes.Add(new LinearAxis {
                Position = AxisPosition.Left,
                Title = "Value",
                TicklineColor = OxyColors.White
            });

            series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                LineStyle = LineStyle.None,
                TextColor = OxyColors.White,
            };
            plotModel1.Background.IsInvisible();
            plotModel1.TextColor = OxyColors.White;
            plotModel1.TitleColor = OxyColors.LightGray;
            plotModel1.TitleFont = "Arial";
            plotModel1.TitleFontSize = 15;
            plotModel1.Updating += delegate{ livetracking = false; };
            plotModel1.Updated += delegate{ livetracking = true; };
            plotModel1.Series.Add(series1);
            plotModel1.PlotMargins = new OxyThickness(60, 20, 50, 50);
            this.plotView1.Model = plotModel1;
        }
        /// <summary>
        /// Lisää datapisteitä
        /// </summary>
        /// <param name="series1"></param>
        /// <param name="plotModel"></param>
        private void AddNewData()
        {
            if (port.IsOpen)
            {
                string luku = port.ReadLine();
                long aika = kello.ElapsedMilliseconds;
                /*if (deviceTime.Checked)
                {
                    try
                    {
                        luku = luku.Trim();
                        int paikka = luku.IndexOf(" ");
                        string s1 = luku.Substring(0, paikka);
                        //string s2 = luku.Substring(paikka, 11).Trim();
                        aika = (long)(DoubleParse(s1)-deviceStart);
                        luku = "500";
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show("Data cannot be read", "FastSerial 1.01", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        port.Close();
                    }
                }*/
                DataPoint piste = new DataPoint(aika, DoubleParse(luku));
                this.data.Add(piste);
                if (livetracking && checkBox1.Checked)
                {
                    updater.Notify(new DataPoint(aika, DoubleParse(luku)));
                }
            }    

        }
        /// <summary>
        /// Stop-nappi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, EventArgs e)
        {
            labelRun.Visible = false;
            try
            {
                if (port == null) DefineSerial();
                if (port.IsOpen) port.Close();
                points.Text = data.Count.ToString();
            }
            catch(NullReferenceException ex)
            {
                System.Windows.Forms.MessageBox.Show("No USB-devices detected", "FastSerial 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                Clear();
                try
                {
                    DecideDataProcess(sender,e);
                }
                catch(NullReferenceException ex) { System.Console.WriteLine(ex.Message); }
                finally { Normal(); }
                plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Start-nappi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (port == null) DefineSerial();
                if (port != null && !port.IsOpen) port.Open();
                Clear();
                kello.Start();
                if (nykyinenPortti != null) label2.Text = nykyinenPortti;
                data.Clear();
                plotModel1.ResetAllAxes();
                if (port == null)
                {
                    System.Windows.Forms.MessageBox.Show("No USB-devices detected", "FastSerial 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                labelRun.Visible = true;
            }
            catch (NullReferenceException ex)
            {
                System.Windows.Forms.MessageBox.Show("No USB-devices detected", "FastSerial 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mitä tehdään kun formi ladataan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Opacity = 0;
            ///lisätään comboboxiin tyylivalinnat
            comboBox1.Items.Add(LineStyle.None);
            comboBox1.Items.Add(LineStyle.Solid);
            comboBox1.Items.Add(LineStyle.Dot);
            comboBox1.Items.Add(LineStyle.Dash);
            /// Markertype combobox
            comboBox2.Items.Add(MarkerType.None);
            comboBox2.Items.Add(MarkerType.Circle);
            comboBox2.Items.Add(MarkerType.Cross);
            comboBox2.Items.Add(MarkerType.Plus);
            comboBox2.Items.Add(MarkerType.Triangle);
            comboBox2.Items.Add(MarkerType.Diamond);
            comboBox2.Items.Add(MarkerType.Square);
            ///kokovalinta
            markerSizeUP.Maximum = 10;
            markerSizeUP.Minimum = 0;
            ///Processing-valinta
            dataType.Items.Add("None");
            dataType.Items.Add("1st Derivative O(h2)");
            dataType.Items.Add("1st Derivative O(h4)");
            dataType.Items.Add("2nd Derivative O(h2)");
            dataType.Items.Add("2nd Derivative O(h4)");
            dataType.Items.Add("FFT");

            //sampling frequency valitsin
            samplFRQ.Value = 1000;
            samplFRQ.BackColor = Color.White;

            //Menu itemit
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter = ".txt|tekstitiedosto";
            saveMenuitem.ForeColor = Color.LightGray;
            colormenuCombo.Items.Add("Green");
            colormenuCombo.Items.Add("White");
            colormenuCombo.Items.Add("Blue");
            colormenuCombo.Items.Add("Red");
            colormenuCombo.Items.Add("Black");
            colormenuCombo.Items.Add("Gray");
            colormenuCombo2.Items.Add("Green");
            colormenuCombo2.Items.Add("White");
            colormenuCombo2.Items.Add("Blue");
            colormenuCombo2.Items.Add("Red");
            colormenuCombo2.Items.Add("Black");
            colormenuCombo2.Items.Add("Gray");
            horizontal.Select();
            ///mittaustyyppi
            comboBoxMesTyp.Items.Add("Position");
            comboBoxMesTyp.Items.Add("Sound level");
            comboBoxMesTyp.Items.Add("Light intensity");
            comboBoxMesTyp.Items.Add("undefined");
            vertical.Hide();
            horizontal.Hide();
            label12.Hide();
            ///massa
            numericUpDownMass.Hide();
            label10.Hide();
            //porttilabel
            if (nykyinenPortti != null) label2.Text = nykyinenPortti;
    }
        /// <summary>
        /// Käynnistää säikeet
        /// </summary>
        private void Saikeet()
        {
            updater = new PlotUpdate(plotModel1, series1);
            this.plotThread = new Thread(new ThreadStart(updater.UpdatePlotter));
            this.plotThread.IsBackground = true;
            this.plotThread.Start();
        }

        /// <summary>
        /// plotin klikkaus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plotView1_Click(object sender, EventArgs e)
        {
            //
        }
        /// <summary>
        /// Lukee merkkijonosta double-luvun. Välimerkkinä voi olla piste tai pilkku
        /// </summary>
        /// <param name="sana"> merkkijono, joka luetaan</param>
        /// <returns>merkkijonosta luetun luvun</returns>
        private static double DoubleParse(string sana)
        {
            try
            {
                if (sana.Contains(",")) return double.Parse(sana);
                return double.Parse(sana.Replace('.', ','));
            }
            catch (FormatException ex) { System.Console.WriteLine(ex.Message); return 0; }
            catch (ArgumentOutOfRangeException ex) { System.Console.WriteLine(ex.Message); return 0; }
            catch (ArgumentNullException ex) { System.Console.WriteLine(ex.Message); return 0; }
        }
        /// <summary>
        /// Vaihtaa livetrackingin arvoa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            livetracking = checkBox1.Checked;
        }
        /// <summary>
        /// Vaihtaa lineseriesin tyyliä
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            livetracking = false;
            series1.LineStyle = (LineStyle)comboBox1.SelectedItem;
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Vaihtaa lineseriesin tyyliä
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            livetracking = false;
            series1.MarkerType = (MarkerType)comboBox2.SelectedItem;
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Lisää datapisteet kuvaajaan käsittelemättä
        /// </summary>
        private void Normal()
        {
            Clear();
            series1.XAxis.Title = "Time(ms)";
            series1.YAxis.Title = "Value";
            if(comboBoxMesTyp.SelectedIndex==0) series1.YAxis.Title = "Position";
            if(comboBoxMesTyp.SelectedIndex == 1) series1.YAxis.Title = "Sound level";
            if (comboBoxMesTyp.SelectedIndex == 2) series1.YAxis.Title = "Light intensity";
            series1.LineStyle = LineStyle.None;
            plotModel1.ResetAllAxes();
            if (comboBox1.SelectedItem != null) series1.LineStyle = (LineStyle)comboBox1.SelectedItem;
            foreach (DataPoint piste in data) series1.Points.Add(piste);
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// prosessoi dataa
        /// </summary>
        private void DecideDataProcess(object sender, EventArgs e)
        {
            if (data.Count < 4)
            {
                MessageBox.Show("No data to plot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }       
            Clear();
            series1.XAxis.Title = "Time(ms)";
            series1.YAxis.Title = "Value";
            series1.LineStyle = LineStyle.None;
            plotModel1.ResetAllAxes();
            if (comboBox1.SelectedItem!=null) series1.LineStyle = (LineStyle)comboBox1.SelectedItem;
            double Fs = 0;
            double mass = 0;
            bool autosmpl = autoSample.Checked;
            int mtype = 1;
            bool suunta = horizontal.Checked;
            if (comboBoxMesTyp.SelectedIndex >= 0) mtype = comboBoxMesTyp.SelectedIndex;
            if (samplFRQ.Value != 0) Fs = (double)samplFRQ.Value;
            mass=(double)numericUpDownMass.Value;
            if (dataType.SelectedIndex > 0)
            {
                List<DataPoint> dataD1 = new List<DataPoint>();
                dataD1 = process.Calculate(dataType.SelectedIndex, Fs, mass, autosmpl, series1, data, mtype, suunta);
                foreach (DataPoint arvo in dataD1) series1.Points.Add(arvo);
                plotModel1.InvalidatePlot(true);
                dataD1.Clear();
            }
            if (dataType.SelectedIndex <= 0) Normal();
        }
        /// <summary>
        /// kokovalitsin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void markerSizeUP_ValueChanged(object sender, EventArgs e)
        {
            livetracking = false;
            series1.MarkerSize = (double)markerSizeUP.Value;
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// list-box valinnan käsittely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool auki=false;
            try
            {
                auki = port.IsOpen;
            }
            catch (NullReferenceException ex) { Console.WriteLine(ex.Message); }
            if (!auki)
            {
                Clear();
                DecideDataProcess(sender,e);
            }
            plotModel1.InvalidatePlot(true);
        }

        /// <summary>
        /// Muuttaa autosample asetuksia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoSample_CheckedChanged(object sender, EventArgs e)
        {
            samplFRQ.BackColor = Color.White;
            samplFRQ.ForeColor = Color.Black;
            if (autoSample.Checked)
            {
                samplFRQ.BackColor = Color.Gray;
                samplFRQ.ForeColor = Color.LightGray;
            }
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Tulostaa raakadatan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            filename = saveFileDialog1.FileName;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename))
            {
                file.WriteLine("#" + "Time(ms)" + "  " + "Value");
                foreach (DataPoint piste in data)
                {
                    file.WriteLine(piste.X + " " + piste.Y);
                }
            }
            MessageBox.Show("Data saved", "FastSerial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Tulostaa käsitellyn datan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            filename=saveFileDialog2.FileName;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename))
            {
                file.WriteLine("#"+series1.XAxis.Title+"  " + series1.YAxis.Title);
                foreach (DataPoint piste in series1.Points)
                {
                    file.WriteLine(piste.X + " " +piste.Y);
                }
            }
            MessageBox.Show("Data saved", "FastSerial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Save as-ikkunan avaaminen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(data.Count>0) saveFileDialog1.ShowDialog();
        }

        /// <summary>
        /// Tallentaa raakadatan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.Count > 0) saveFileDialog2.ShowDialog();
        }
        /// <summary>
        /// tarkistaa voiko tallentaa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (filename == null) saveMenuitem.ForeColor = Color.LightGray;
            if (filename != null) saveMenuitem.ForeColor = Color.Black;
            if (data.Count <= 0)
            {
                saveAsToolStripMenuItem.ForeColor = Color.LightGray;
                exportDataToolStripMenuItem.ForeColor = Color.LightGray;
            }
            if (data.Count > 0)
            {
                saveAsToolStripMenuItem.ForeColor = Color.Black;
                exportDataToolStripMenuItem.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Tallentaa tiedostoon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveMenuitem_Click(object sender, EventArgs e)
        {
            if (filename == null) return;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename))
            {
                file.WriteLine("#" + "Time(ms)" + "  " + "Value");
                foreach (DataPoint piste in data)
                {
                    file.WriteLine(piste.X + " " + piste.Y);
                }
            }
            MessageBox.Show("Data saved", "FastSerial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Avataan tiedoston valitsemisikkuna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                port.Close();

            }
            catch (NullReferenceException ex) { Console.WriteLine(ex.Message); }
            openFileDialog1.ShowDialog();
        }
        /// <summary>
        /// Avataan valittu tiedosto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
                 try
                 {
                     data.Clear();
                     using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                     {
                         string line;
                         while ((line = sr.ReadLine()) != null)
                         {
                            if (line.Contains("#")) continue;
                            double d1 = double.Parse(line.Substring(0, line.LastIndexOf(' ')).Trim());
                            StringBuilder s = new StringBuilder();
                            for(int i=line.LastIndexOf(' '); i < line.Length; i++)
                            {
                                s.Append(line[i]);
                            }
                        double d2 = double.Parse(s.ToString());
                        data.Add(new DataPoint(d1, d2));
                        }
                     }
                        filename = openFileDialog1.FileName;
                 }
                 catch (Exception ex)
                 {
                string error = "Cannot open datafile " + openFileDialog1.FileName + " because it is the wrong type of file or datatype is not supported";
                     MessageBox.Show(error,"FastSerial",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 }
            Normal();
            points.Text = data.Count.ToString();
        }
        /// <summary>
        /// line color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colormenuCombo_Click(object sender, EventArgs e)
        {
            switch ((string)colormenuCombo.SelectedItem)
            {
                case "Green":
                    series1.Color = OxyColors.Green;
                    break;
                case "Red":
                    series1.Color = OxyColors.Red;
                    break;
                case "Black":
                    series1.Color = OxyColors.Black;
                    break;
                case "Gray":
                    series1.Color = OxyColors.Gray;
                    break;
                case "Blue":
                    series1.Color = OxyColors.Blue;
                    break;
                case "White":
                    series1.Color = OxyColors.White;
                    break;
                default:
                    break;
            }
            livetracking = false;
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Point color 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colormenuCombo2_Click(object sender, EventArgs e)
        {
            switch ((string)colormenuCombo2.SelectedItem)
            {
                case "Green":
                    series1.MarkerFill = OxyColors.Green;
                    break;
                case "Red":
                    series1.MarkerFill = OxyColors.Red;
                    break;
                case "Black":
                    series1.MarkerFill = OxyColors.Black;
                    break;
                case "Gray":
                    series1.MarkerFill = OxyColors.Gray;
                    break;
                case "Blue":
                    series1.MarkerFill = OxyColors.Blue;
                    break;
                case "White":
                    series1.MarkerFill = OxyColors.White;
                    break;
                default:
                    break;
            }
            livetracking = false;
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Info-itetm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fastSerial101ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info(false);
            info.Show();
        }
        /// <summary>
        /// Vaihdetaan mittausta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMesTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMesTyp.SelectedIndex == 0)
            {
                series1.YAxis.Title = "Position";
                numericUpDownMass.Show();
                label10.Show();
                dataType.Items.Clear();
                dataType.Items.Add("None");
                dataType.Items.Add("1st Derivative O(h2)");
                dataType.Items.Add("1st Derivative O(h4)");
                dataType.Items.Add("2nd Derivative O(h2)");
                dataType.Items.Add("2nd Derivative O(h4)");
                dataType.Items.Add("FFT");
                dataType.Items.Add("Force");
                dataType.Items.Add("Power");
                vertical.Show();
                horizontal.Show();
                label12.Show();
            }
            else
            {
                numericUpDownMass.Hide();
                label10.Hide();
                dataType.Items.Clear();
                dataType.Items.Add("None");
                dataType.Items.Add("1st Derivative O(h2)");
                dataType.Items.Add("1st Derivative O(h4)");
                dataType.Items.Add("2nd Derivative O(h2)");
                dataType.Items.Add("2nd Derivative O(h4)");
                dataType.Items.Add("FFT");
                if (comboBoxMesTyp.SelectedIndex == 1) series1.YAxis.Title = "Sound level";
                if (comboBoxMesTyp.SelectedIndex == 2) series1.YAxis.Title = "Light intensity";
                vertical.Hide();
                horizontal.Hide();
                label12.Hide();
            }
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Sulkemispainike
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Minimointipainike
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Päivityspainike
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            DataType_SelectedIndexChanged(sender, e);
            plotModel1.InvalidatePlot(true);
        }
        /// <summary>
        /// Auto zoom-nappi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutozoomEvent(object sender, EventArgs e)
        {
            plotModel1.ResetAllAxes();
            plotModel1.InvalidatePlot(true);
        }


        //=====================================================
        //Turhia tapahtumankäsittelijöitä
        //=====================================================


        private void numericUpDownMass_ValueChanged(object sender, EventArgs e)
        {
            //
        }
        private void label2_Click(object sender, EventArgs e)
        {
            ///
        }

        private void colorlabel_Click(object sender, EventArgs e)
        {
            ///
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void samplFRQ_ValueChanged(object sender, EventArgs e)
        {
            //
        }

        private void label11_Click(object sender, EventArgs e)
        {
            //
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //
        }
    }

}

