using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastSerial
{
    public partial class Info : Form
    {
        public Info(Boolean aloitus)
        {
            InitializeComponent();
            if (aloitus)
            {
                progressBarload.PerformStep();
                progressBarload.Show();
                buttonOk.Hide();
                progressBarload.Step = 100;
                progressBarload.PerformStep();
                System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
                timer2.Interval = 1;
                timer2.Start();
                timer2.Tick += delegate {
                    progressBarload.PerformStep();
                    progressBarload.Update();
                };
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Start();
                timer.Tick += delegate { Close(); };
            }
            if (!aloitus)
            {
                progressBarload.Hide();
                buttonOk.Show();
            }

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
