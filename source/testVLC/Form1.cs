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
        private string[] mediaOptions = {
            ":network-caching=1000",  // Tăng bộ đệm mạng lên 1000ms (1 giây)
            ":rtsp-tcp",              // Sử dụng giao thức TCP để tăng độ ổn định cho RTSP
            ":skip-frames",           // Bỏ qua khung hình bị trễ nếu máy không đủ khả năng xử lý
            ":sout-mux-caching=500",  // Giảm độ trễ của luồng khi mux (tạo luồng liên tục)
            ":clock-jitter=0",        // Loại bỏ hiện tượng jitter
            ":live-caching=1000",     // Giảm độ trễ của các luồng live (như RTSP)
            ":hwdec=auto"             // Sử dụng giải mã phần cứng nếu được hỗ trợ
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => vlcControl1.Play(new Uri(textBox1.Text), mediaOptions));
                Task.Run(() => vlcControl2.Play(new Uri(textBox1.Text), mediaOptions));
                Task.Run(() => vlcControl3.Play(new Uri(textBox1.Text), mediaOptions));
                Task.Run(() => vlcControl4.Play(new Uri(textBox1.Text), mediaOptions));
                Task.Run(() => vlcControl5.Play(new Uri(textBox1.Text), mediaOptions));
                Task.Run(() => vlcControl6.Play(new Uri(textBox1.Text), mediaOptions));
                Task.Run(() => vlcControl7.Play(new Uri(textBox1.Text), mediaOptions));
                //may gam 8gb hien tai chi chay duoc 7
                //Task.Run(() => vlcControl8.Play(new Uri(textBox1.Text), mediaOptions));
                //Task.Run(() => vlcControl9.Play(new Uri(textBox1.Text), mediaOptions));
                //Task.Run(() => vlcControl10.Play(new Uri(textBox1.Text), mediaOptions));
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
                vlcControl2.Pause();
                vlcControl3.Pause();
                vlcControl4.Pause();
                vlcControl5.Pause();
                vlcControl6.Pause();
                vlcControl7.Pause();
                vlcControl8.Pause();
                vlcControl9.Pause();
                vlcControl10.Pause();
                button2.Text = "Play";
            }
            else if (button2.Text == "Play")
            {
                vlcControl1.Play();
                vlcControl2.Play();
                vlcControl3.Play();
                vlcControl4.Play();
                vlcControl5.Play();
                vlcControl6.Play();
                vlcControl7.Play();
                vlcControl8.Play();
                vlcControl9.Play();
                vlcControl10.Play();
                button2.Text = "Pause";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vlcControl1.Stop();
            vlcControl2.Stop();
            vlcControl3.Stop();
            vlcControl4.Stop();
            vlcControl5.Stop();
            vlcControl6.Stop();
            vlcControl7.Stop();
            vlcControl8.Stop();
            vlcControl9.Stop();
            vlcControl10.Stop();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            textBox1.Text = "rtsp://rtspstream:6acb6fa2a35f76becacd7161d80361ee@zephyr.rtsp.stream/movie";
        }
    }
}
