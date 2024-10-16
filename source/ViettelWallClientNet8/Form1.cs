using System.Collections.Generic;
using System.Threading.Tasks;
using Vlc.DotNet.Forms;

namespace ViettelWallClientNet8
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
            ":avcodec-hw=dxva2"       // Sử dụng giải mã phần cứng nếu được hỗ trợ
        };
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                execute();
                retryPlay(3);
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
                foreach(var control in listControls())
                {
                    control.Pause();
                }
                button2.Text = "Play";
            }
            else if (button2.Text == "Play")
            {
                foreach (var control in listControls())
                {
                    control.Play();
                }
                button2.Text = "Pause";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(var control in listControls())
            {
                control.Stop();
                control.Dispose();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "rtsp://rtspstream:4f326532af202c55939aa209abb7d154@zephyr.rtsp.stream/movie";
        }

        private async Task execute()
        {
            foreach (var control in listControls()) {
                //control.VlcLibDirectory = new System.IO.DirectoryInfo(textBox2.Text);
                await Task.Run(() => control.Play(new Uri(textBox1.Text), mediaOptions));
            }
        }
        private List<Vlc.DotNet.Forms.VlcControl> listControls()
        {
            return new List<Vlc.DotNet.Forms.VlcControl>
            {
                vlcControl1,
                vlcControl2,
                vlcControl3,
                vlcControl4,
                vlcControl5,
                vlcControl6,
                vlcControl7,
                vlcControl8,
                vlcControl9,
                vlcControl10,
                vlcControl11,
                vlcControl12,
                vlcControl13,
                vlcControl14,
                vlcControl15,
                vlcControl16,
                vlcControl17,
                vlcControl18,
                vlcControl19,
                vlcControl20,
                vlcControl21,
                vlcControl22,
                vlcControl23,
                vlcControl24,
                vlcControl25,
                vlcControl26,
                vlcControl27,
                vlcControl28,
                vlcControl29,
                vlcControl30,
                vlcControl31,
                vlcControl32,
                vlcControl33,
                vlcControl34,
                vlcControl35,
                vlcControl36,
                vlcControl37,
                vlcControl38,
                vlcControl39,
                vlcControl40,
                vlcControl41,
                vlcControl42,
                vlcControl43,
                vlcControl44,
                vlcControl45,
                vlcControl46,
                vlcControl47,
                vlcControl48,
                vlcControl49,
                vlcControl50,
                vlcControl51,
                vlcControl52,
                vlcControl53,
                vlcControl54,
                vlcControl55,
                vlcControl56,
                vlcControl57,
                vlcControl58,
                vlcControl59,
                vlcControl60,
                vlcControl61,
                vlcControl62,
                vlcControl63,
                vlcControl64,
                vlcControl65,
                vlcControl66,
                vlcControl67,
                vlcControl68,
                vlcControl69,
                vlcControl70,
                vlcControl71,
                vlcControl72,
                vlcControl73,
                vlcControl74,
                vlcControl75,
                vlcControl76,
                vlcControl77,
                vlcControl78,
                vlcControl79,
                vlcControl80,
                vlcControl81,
                vlcControl82,
                vlcControl83,
                vlcControl84,
                vlcControl85,
                vlcControl86,
                vlcControl87,
                vlcControl88,
                vlcControl89,
                vlcControl90,
                vlcControl91,
                vlcControl92,
                vlcControl93,
                vlcControl94,
                vlcControl95,
                vlcControl96,
                vlcControl97,
                vlcControl98,
                vlcControl99,
                vlcControl100
            };
        }

        private async Task retryPlay(int retry)
        {
            foreach (var control in listControls()) {
                for (var i = 0; i < retry; i++) {
                    await Task.Delay(5000);
                    if (control.IsPlaying)
                    {
                        break;
                    } else
                    {
                        await Task.Run(() => control.Play(new Uri(textBox1.Text), mediaOptions));
                    }
                }
            }
        }
    }
}
