using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testVLC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "rtsp://demo:demo@ipvmdemo.dyndns.org:5541/onvif-media/media.amp?profile=profile_1_h264&sessiontimeout=60&streamtype=unicast";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                vlcControl1.Play(new Uri(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Pause")
            {
                vlcControl1.Pause();
                button2.Text = "Play";
            }
            else if (button2.Text == "Play")
            {
                vlcControl1.Play();
                button2.Text = "Pause";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vlcControl1.Stop();
        }
    }
}
