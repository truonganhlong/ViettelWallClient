using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.WindowState = FormWindowState.Maximized;
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
                foreach (var control in listControls())
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
            foreach (var control in listControls())
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
            //foreach (var control in listControls())
            //{
            //    await Task.Run(() => control.Play(new Uri(textBox1.Text), mediaOptions));
            //}
            //for (int i = 1; i < listControls().Count; i++) {
            //    string url = ((TextBox)Controls["textBox" + i]).Text;
            //    if (!string.IsNullOrEmpty(url))
            //    {
            //        await Task.Run(() => listControls()[i].Play(new Uri(url), mediaOptions));
            //        //await Task.Run(() => listControls)
            //    }
            //    else
            //    {
            //        MessageBox.Show($"TextBox {i} không có URL hợp lệ.");
            //    }
            //}

            for (int i = 0; i < listControls().Count; i++) {
                if (!string.IsNullOrWhiteSpace(listTextBox()[i].Text)){
                    await Task.Run(() => listControls()[i].Play(new Uri(listTextBox()[i].Text), mediaOptions));
                }
            }


            //if (!string.IsNullOrWhiteSpace(textBox1.Text))
            //{
            //    await Task.Run(() => listControls()[0].Play(new Uri(textBox1.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox2.Text))
            //{
            //    await Task.Run(() => listControls()[1].Play(new Uri(textBox2.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox3.Text))
            //{
            //    await Task.Run(() => listControls()[2].Play(new Uri(textBox3.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox4.Text))
            //{
            //    await Task.Run(() => listControls()[3].Play(new Uri(textBox4.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox5.Text))
            //{
            //    await Task.Run(() => listControls()[4].Play(new Uri(textBox5.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox6.Text))
            //{
            //    await Task.Run(() => listControls()[5].Play(new Uri(textBox6.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox7.Text))
            //{
            //    await Task.Run(() => listControls()[6].Play(new Uri(textBox7.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox8.Text))
            //{
            //    await Task.Run(() => listControls()[7].Play(new Uri(textBox8.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox9.Text))
            //{
            //    await Task.Run(() => listControls()[8].Play(new Uri(textBox9.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox10.Text))
            //{
            //    await Task.Run(() => listControls()[9].Play(new Uri(textBox10.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox11.Text))
            //{
            //    await Task.Run(() => listControls()[10].Play(new Uri(textBox11.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox12.Text))
            //{
            //    await Task.Run(() => listControls()[11].Play(new Uri(textBox12.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox13.Text))
            //{
            //    await Task.Run(() => listControls()[12].Play(new Uri(textBox13.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox14.Text))
            //{
            //    await Task.Run(() => listControls()[13].Play(new Uri(textBox14.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox15.Text))
            //{
            //    await Task.Run(() => listControls()[14].Play(new Uri(textBox15.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox16.Text))
            //{
            //    await Task.Run(() => listControls()[15].Play(new Uri(textBox16.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox17.Text))
            //{
            //    await Task.Run(() => listControls()[16].Play(new Uri(textBox17.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox18.Text))
            //{
            //    await Task.Run(() => listControls()[17].Play(new Uri(textBox18.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox19.Text))
            //{
            //    await Task.Run(() => listControls()[18].Play(new Uri(textBox19.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox20.Text))
            //{
            //    await Task.Run(() => listControls()[19].Play(new Uri(textBox20.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox21.Text))
            //{
            //    await Task.Run(() => listControls()[20].Play(new Uri(textBox21.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox22.Text))
            //{
            //    await Task.Run(() => listControls()[21].Play(new Uri(textBox22.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox23.Text))
            //{
            //    await Task.Run(() => listControls()[22].Play(new Uri(textBox23.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox24.Text))
            //{
            //    await Task.Run(() => listControls()[23].Play(new Uri(textBox24.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox25.Text))
            //{
            //    await Task.Run(() => listControls()[24].Play(new Uri(textBox25.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox26.Text))
            //{
            //    await Task.Run(() => listControls()[25].Play(new Uri(textBox26.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox27.Text))
            //{
            //    await Task.Run(() => listControls()[26].Play(new Uri(textBox27.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox28.Text))
            //{
            //    await Task.Run(() => listControls()[27].Play(new Uri(textBox28.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox29.Text))
            //{
            //    await Task.Run(() => listControls()[28].Play(new Uri(textBox29.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox30.Text))
            //{
            //    await Task.Run(() => listControls()[29].Play(new Uri(textBox30.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox31.Text))
            //{
            //    await Task.Run(() => listControls()[30].Play(new Uri(textBox31.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox32.Text))
            //{
            //    await Task.Run(() => listControls()[31].Play(new Uri(textBox32.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox33.Text))
            //{
            //    await Task.Run(() => listControls()[32].Play(new Uri(textBox33.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox34.Text))
            //{
            //    await Task.Run(() => listControls()[33].Play(new Uri(textBox34.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox35.Text))
            //{
            //    await Task.Run(() => listControls()[34].Play(new Uri(textBox35.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox36.Text))
            //{
            //    await Task.Run(() => listControls()[35].Play(new Uri(textBox36.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox37.Text))
            //{
            //    await Task.Run(() => listControls()[36].Play(new Uri(textBox37.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox38.Text))
            //{
            //    await Task.Run(() => listControls()[37].Play(new Uri(textBox38.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox39.Text))
            //{
            //    await Task.Run(() => listControls()[38].Play(new Uri(textBox39.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox40.Text))
            //{
            //    await Task.Run(() => listControls()[39].Play(new Uri(textBox40.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox41.Text))
            //{
            //    await Task.Run(() => listControls()[40].Play(new Uri(textBox41.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox42.Text))
            //{
            //    await Task.Run(() => listControls()[41].Play(new Uri(textBox42.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox43.Text))
            //{
            //    await Task.Run(() => listControls()[42].Play(new Uri(textBox43.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox44.Text))
            //{
            //    await Task.Run(() => listControls()[43].Play(new Uri(textBox44.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox45.Text))
            //{
            //    await Task.Run(() => listControls()[44].Play(new Uri(textBox45.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox46.Text))
            //{
            //    await Task.Run(() => listControls()[45].Play(new Uri(textBox46.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox47.Text))
            //{
            //    await Task.Run(() => listControls()[46].Play(new Uri(textBox47.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox48.Text))
            //{
            //    await Task.Run(() => listControls()[47].Play(new Uri(textBox48.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox49.Text))
            //{
            //    await Task.Run(() => listControls()[48].Play(new Uri(textBox49.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox50.Text))
            //{
            //    await Task.Run(() => listControls()[49].Play(new Uri(textBox50.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox51.Text))
            //{
            //    await Task.Run(() => listControls()[50].Play(new Uri(textBox51.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox52.Text))
            //{
            //    await Task.Run(() => listControls()[51].Play(new Uri(textBox52.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox53.Text))
            //{
            //    await Task.Run(() => listControls()[52].Play(new Uri(textBox53.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox54.Text))
            //{
            //    await Task.Run(() => listControls()[53].Play(new Uri(textBox54.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox55.Text))
            //{
            //    await Task.Run(() => listControls()[54].Play(new Uri(textBox55.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox56.Text))
            //{
            //    await Task.Run(() => listControls()[55].Play(new Uri(textBox56.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox57.Text))
            //{
            //    await Task.Run(() => listControls()[56].Play(new Uri(textBox57.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox58.Text))
            //{
            //    await Task.Run(() => listControls()[57].Play(new Uri(textBox58.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox59.Text))
            //{
            //    await Task.Run(() => listControls()[58].Play(new Uri(textBox59.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox60.Text))
            //{
            //    await Task.Run(() => listControls()[59].Play(new Uri(textBox60.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox61.Text))
            //{
            //    await Task.Run(() => listControls()[60].Play(new Uri(textBox61.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox62.Text))
            //{
            //    await Task.Run(() => listControls()[61].Play(new Uri(textBox62.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox63.Text))
            //{
            //    await Task.Run(() => listControls()[62].Play(new Uri(textBox63.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox64.Text))
            //{
            //    await Task.Run(() => listControls()[63].Play(new Uri(textBox64.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox65.Text))
            //{
            //    await Task.Run(() => listControls()[64].Play(new Uri(textBox65.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox66.Text))
            //{
            //    await Task.Run(() => listControls()[65].Play(new Uri(textBox66.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox67.Text))
            //{
            //    await Task.Run(() => listControls()[66].Play(new Uri(textBox67.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox68.Text))
            //{
            //    await Task.Run(() => listControls()[67].Play(new Uri(textBox68.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox69.Text))
            //{
            //    await Task.Run(() => listControls()[68].Play(new Uri(textBox69.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox70.Text))
            //{
            //    await Task.Run(() => listControls()[69].Play(new Uri(textBox70.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox71.Text))
            //{
            //    await Task.Run(() => listControls()[70].Play(new Uri(textBox71.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox72.Text))
            //{
            //    await Task.Run(() => listControls()[71].Play(new Uri(textBox72.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox73.Text))
            //{
            //    await Task.Run(() => listControls()[72].Play(new Uri(textBox73.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox74.Text))
            //{
            //    await Task.Run(() => listControls()[73].Play(new Uri(textBox74.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox75.Text))
            //{
            //    await Task.Run(() => listControls()[74].Play(new Uri(textBox75.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox76.Text))
            //{
            //    await Task.Run(() => listControls()[75].Play(new Uri(textBox76.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox77.Text))
            //{
            //    await Task.Run(() => listControls()[76].Play(new Uri(textBox77.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox78.Text))
            //{
            //    await Task.Run(() => listControls()[77].Play(new Uri(textBox78.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox79.Text))
            //{
            //    await Task.Run(() => listControls()[78].Play(new Uri(textBox79.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox80.Text))
            //{
            //    await Task.Run(() => listControls()[79].Play(new Uri(textBox80.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox81.Text))
            //{
            //    await Task.Run(() => listControls()[80].Play(new Uri(textBox81.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox82.Text))
            //{
            //    await Task.Run(() => listControls()[81].Play(new Uri(textBox82.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox83.Text))
            //{
            //    await Task.Run(() => listControls()[82].Play(new Uri(textBox83.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox84.Text))
            //{
            //    await Task.Run(() => listControls()[83].Play(new Uri(textBox84.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox85.Text))
            //{
            //    await Task.Run(() => listControls()[84].Play(new Uri(textBox85.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox86.Text))
            //{
            //    await Task.Run(() => listControls()[85].Play(new Uri(textBox86.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox87.Text))
            //{
            //    await Task.Run(() => listControls()[86].Play(new Uri(textBox87.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox88.Text))
            //{
            //    await Task.Run(() => listControls()[87].Play(new Uri(textBox88.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox89.Text))
            //{
            //    await Task.Run(() => listControls()[88].Play(new Uri(textBox89.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox90.Text))
            //{
            //    await Task.Run(() => listControls()[89].Play(new Uri(textBox90.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox91.Text))
            //{
            //    await Task.Run(() => listControls()[90].Play(new Uri(textBox91.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox92.Text))
            //{
            //    await Task.Run(() => listControls()[91].Play(new Uri(textBox92.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox93.Text))
            //{
            //    await Task.Run(() => listControls()[92].Play(new Uri(textBox93.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox94.Text))
            //{
            //    await Task.Run(() => listControls()[93].Play(new Uri(textBox94.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox95.Text))
            //{
            //    await Task.Run(() => listControls()[94].Play(new Uri(textBox95.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox96.Text))
            //{
            //    await Task.Run(() => listControls()[95].Play(new Uri(textBox96.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox97.Text))
            //{
            //    await Task.Run(() => listControls()[96].Play(new Uri(textBox97.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox98.Text))
            //{
            //    await Task.Run(() => listControls()[97].Play(new Uri(textBox98.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox99.Text))
            //{
            //    await Task.Run(() => listControls()[98].Play(new Uri(textBox99.Text), mediaOptions));
            //}

            //if (!string.IsNullOrWhiteSpace(textBox100.Text))
            //{
            //    await Task.Run(() => listControls()[99].Play(new Uri(textBox100.Text), mediaOptions));
            //}


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
                vlcControl36
                //vlcControl37,
                //vlcControl38,
                //vlcControl39,
                //vlcControl40,
                //vlcControl41,
                //vlcControl42,
                //vlcControl43,
                //vlcControl44,
                //vlcControl45,
                //vlcControl46,
                //vlcControl47,
                //vlcControl48,
                //vlcControl49,
                //vlcControl50,
                //vlcControl51,
                //vlcControl52,
                //vlcControl53,
                //vlcControl54,
                //vlcControl55,
                //vlcControl56,
                //vlcControl57,
                //vlcControl58,
                //vlcControl59,
                //vlcControl60,
                //vlcControl61,
                //vlcControl62,
                //vlcControl63,
                //vlcControl64,
                //vlcControl65,
                //vlcControl66,
                //vlcControl67,
                //vlcControl68,
                //vlcControl69,
                //vlcControl70,
                //vlcControl71,
                //vlcControl72,
                //vlcControl73,
                //vlcControl74,
                //vlcControl75,
                //vlcControl76,
                //vlcControl77,
                //vlcControl78,
                //vlcControl79,
                //vlcControl80,
                //vlcControl81,
                //vlcControl82,
                //vlcControl83,
                //vlcControl84,
                //vlcControl85,
                //vlcControl86,
                //vlcControl87,
                //vlcControl88,
                //vlcControl89,
                //vlcControl90,
                //vlcControl91,
                //vlcControl92,
                //vlcControl93,
                //vlcControl94,
                //vlcControl95,
                //vlcControl96,
                //vlcControl97,
                //vlcControl98,
                //vlcControl99,
                //vlcControl100
            };
        }

        private List<TextBox> listTextBox()
        {
            return new List<TextBox>
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10,
                textBox11,
                textBox12,
                textBox13,
                textBox14,
                textBox15,
                textBox16,
                textBox17,
                textBox18,
                textBox19,
                textBox20,
                textBox21,
                textBox22,
                textBox23,
                textBox24,
                textBox25,
                textBox26,
                textBox27,
                textBox28,
                textBox29,
                textBox30,
                textBox31,
                textBox32,
                textBox33,
                textBox34,
                textBox35,
                textBox36
            };
        }

        private async Task retryPlay(int retry)
        {
            //foreach (var control in listControls())
            //{
            //    for (var i = 0; i < retry; i++)
            //    {
            //        await Task.Delay(5000);
            //        if (control.IsPlaying)
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            await Task.Run(() => control.Play(new Uri(textBox1.Text), mediaOptions));
            //        }
            //    }
            //}

            for (int i = 0; i < listControls().Count; i++) {
                for (var time = 0; i < retry; i++) {
                    await Task.Delay(5000);
                    if (listControls()[i].IsPlaying)
                    {
                        break;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(listTextBox()[i].Text))
                        {
                            await Task.Run(() => listControls()[i].Play(new Uri(listTextBox()[i].Text), mediaOptions));
                        }
                    }
                }
            }
        }
    }
}
