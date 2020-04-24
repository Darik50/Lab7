using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            string R = trackBar1.Value.ToString("X");
            string G = trackBar2.Value.ToString("X");
            string B = trackBar3.Value.ToString("X");
            if(R.Length == 1)
            {
                R = "0" + R;
            }
            if (G.Length == 1)
            {
                G = "0" + G;
            }
            if (B.Length == 1)
            {
                B = "0" + B;
            }
            toolTip1.Show("#" + R + G + B, panel1);
            Clipboard.SetText("#" + R + G + B);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(panel1);
        }
    }
}
