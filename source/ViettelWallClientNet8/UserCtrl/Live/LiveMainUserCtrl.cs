using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Data;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Model.Camera;
using ViettelWallClientNet8.Model.Setting;
using ViettelWallClientNet8.Service.Setting;
using static System.Windows.Forms.LinkLabel;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveMainUserCtrl : UserControl
    {
        private int videoViewIndex = 1;
        private readonly ISettingLayoutService _settingLayoutService;
        public event EventHandler? leftTabClickEvent;
        public event EventHandler? rightTabClickEvent;
        //
        private LibVLC _libVlc;
        private Dictionary<int, MediaPlayer> _dictMediaPlayer;
        private Dictionary<int, VideoView> dictVideoView = new Dictionary<int, VideoView>();
        private Dictionary<int, TextBox> dictTextBox = new Dictionary<int, TextBox>();
        private string[] mediaOptions = new string[]{
                //":network-caching=1000",      // Tăng bộ đệm mạng lên 1000ms (1 giây), tùy chỉnh để giảm độ trễ
                //":http-reconnect",            // Tự động kết nối lại khi mất kết nối HTTP
                //":clock-jitter=0",            // Loại bỏ jitter
                //":avcodec-hw=dxva2",          // Sử dụng giải mã phần cứng
                ////":hls-segment-threads=4",     // Tăng số luồng tải phân đoạn HLS để giảm độ trễ tải phân đoạn
                //":live-caching=1000",         // Bộ đệm cho các luồng live, có thể giảm xuống nếu muốn
                //":sout-mux-caching=500",      // Giảm độ trễ của luồng khi mux (đảm bảo luồng được tạo liên tục)
                //":sout-transcode-vfilter=canvas{width=1280,height=720}", // Điều chỉnh độ phân giải
                //":sout-transcode-fps=30",      // Đặt tốc độ khung hình mong muốn
                "--no-disable-screensaver",
                "--no-sub-autodetect-file",
                "--no-lua",
                "--no-osd",
                "--no-snapshot-preview",
                "--no-spu",
                "--no-interact",
                "--no-stats",
                "--no-keyboard-events",
                "--no-mouse-events",
                "--no-video-deco",
                "--no-sout-x264-nf",
                "--avcodec-hw=dxva2",                    // Giải mã phần cứng (any giúp tự chọn phù hợp)
                "--avcodec-skip-frame=0",              // Không bỏ qua khung hình (để đồng nhất với Python)
                "--avcodec-skip-idct=0",               // Không bỏ qua IDCT (Inverse Discrete Cosine Transform)
                "--avcodec-skiploopfilter=4",          // Bỏ qua lọc vòng cho giảm tải
                "--avcodec-error-resilience=4",        // Thiết lập khả năng chống lỗi
                "--avcodec-hurry-up",                  // Tăng tốc giải mã
                "--avcodec-fast",                      // Thiết lập giải mã nhanh
                "--clock-jitter=0",                    // Giảm thiểu hiện tượng jitter
                "--clock-synchro=0",                   // Không đồng bộ hóa đồng hồ
                "--deinterlace=0",                     // Tắt chế độ deinterlacing
                "--drop-late-frames",                  // Bỏ qua khung hình trễ
                "--skip-frames",                       // Bỏ qua khung hình không cần thiết
                "--swscale-mode=0",                    // Thiết lập chế độ scaler
                "--rtsp-frame-buffer-size=500000",     // Kích thước bộ đệm cho RTSP
                "--network-caching=1000",              // Đệm mạng 1000ms (1 giây)
                "--rtsp-tcp",                          // Sử dụng giao thức TCP cho RTSP
                "--file-caching=1000",                 // Đệm file 1000ms (hữu ích cho HLS)
                "--live-caching=1000"                  // Đệm cho luồng trực tiếp (RTSP, HLS)
        };
        public LiveMainUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
            settingLayout();
            _libVlc = new LibVLC();
            _dictMediaPlayer = new Dictionary<int, MediaPlayer>();
            for (int i = 1; i <= dictVideoView.Count; i++)
            {
                var mediaPlayer = new MediaPlayer(_libVlc);
                dictVideoView[i].MediaPlayer = mediaPlayer;
                _dictMediaPlayer.Add(i, mediaPlayer);
            }
            settingPlayVideo();
        }

        private void leftTabButtonClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (left_tab_button.Text.Equals("<"))
                {
                    left_tab_button.Text = ">";
                }
                else if (left_tab_button.Text.Equals(">"))
                {
                    left_tab_button.Text = "<";
                }
                _settingLayoutService.updateIsLeftTabVisible();
                leftTabClickEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        private void InitializeAfter()
        {
            SettingLastView? lastView = _settingLayoutService.getLastViewSetting();
            if (lastView != null && lastView.isLeftTabVisible)
            {
                left_tab_button.Text = "<";
            }
            else if (lastView != null && !lastView.isLeftTabVisible)
            {
                left_tab_button.Text = ">";
            }
            left_tab_button.Location = new Point(0, (main_panel.Height - left_tab_button.Height) / 2);
            left_tab_button.FlatStyle = FlatStyle.Flat; // Đặt FlatStyle thành Flat
            left_tab_button.FlatAppearance.BorderSize = 0; // Xóa viền
            left_tab_button.BringToFront();

            if (lastView != null && lastView.isRightTabVisible)
            {
                right_tab_button.Text = ">";
            }
            else if (lastView != null && !lastView.isRightTabVisible)
            {
                right_tab_button.Text = "<";
            }
            right_tab_button.Location = new Point(main_panel.Width - right_tab_button.Width, (main_panel.Height - right_tab_button.Height) / 2);
            right_tab_button.FlatStyle = FlatStyle.Flat; // Đặt FlatStyle thành Flat
            right_tab_button.FlatAppearance.BorderSize = 0; // Xóa viền
            right_tab_button.BringToFront();

        }

        public void settingLayout()
        {
            SettingLayout? layout = _settingLayoutService.getLayoutSetting();
            if (layout == null)
            {
                MessageBox.Show("Layout lỗi, xin vui lòng thử lại sau");
            }
            else
            {
                if (videoViewIndex != 1)
                {
                    videoViewIndex = 1;
                    main_table_layout_panel.Controls.Clear();
                    main_table_layout_panel.ColumnStyles.Clear();
                    main_table_layout_panel.RowStyles.Clear();
                }
                main_table_layout_panel.ColumnCount = layout.width;
                for (int i = 0; i < layout.width; i++)
                {
                    main_table_layout_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / layout.width));
                }
                main_table_layout_panel.RowCount = layout.height;
                for (int i = 0; i < layout.height; i++)
                {
                    main_table_layout_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / layout.height));
                }
                float videoViewWidth = main_table_layout_panel.Width / layout.width;
                float videoViewHeight = main_table_layout_panel.Height / layout.height;
                //tạo nhiều videoView theo thứ tự từ trái sang phải, từ trên xuống dưới
                for (int y = 0; y < layout.height; y++)
                {
                    for (int x = 0; x < layout.width; x++)
                    {
                        Panel panel = new Panel();
                        panel.Dock = DockStyle.Fill;
                        panel.Margin = new Padding(3);
                        main_table_layout_panel.Controls.Add(panel, x, y);
                        TextBox textBox = new TextBox();
                        textBox.Name = "textBox" + videoViewIndex;
                        textBox.Dock = DockStyle.Top;
                        textBox.Height = 20;
                        textBox.KeyDown += textBoxKeyDown;
                        textBox.AllowDrop = true;
                        //textBox.DragEnter += dragEnter;
                        //textBox.DragDrop += dragTextBoxDrop;
                        VideoView videoView = new VideoView();
                        //main_table_layout_panel.Controls.Add(videoView, x, y);
                        videoView.BackColor = Color.FromArgb(170, 167, 167);
                        videoView.Dock = DockStyle.Top;
                        videoView.MediaPlayer = null;
                        videoView.Size = new Size((int)Math.Floor(videoViewWidth), (int)Math.Floor(videoViewHeight));
                        videoView.Name = "videoView" + videoViewIndex;
                        videoView.AllowDrop = true;
                        videoView.DragEnter += dragEnter;
                        videoView.DragDrop += dragDrop;
                        //videoView.Margin = new Padding(3, 3, 3, 3);
                        panel.Controls.Add(videoView);
                        panel.Controls.Add(textBox);
                        dictVideoView.Add(videoViewIndex, videoView);
                        dictTextBox.Add(videoViewIndex, textBox);
                        videoViewIndex++;

                        //VideoView videoView = new VideoView();
                        //main_table_layout_panel.Controls.Add(videoView, x, y);
                        //videoView.BackColor = Color.FromArgb(170, 167, 167);
                        //videoView.Dock = DockStyle.Fill;
                        //videoView.MediaPlayer = null;
                        //videoView.Size = new Size((int)Math.Floor(videoViewWidth), (int)Math.Floor(videoViewHeight));
                        //videoView.Name = "videoView" + videoViewIndex;
                        //videoView.Margin = new Padding(3, 3, 3, 3);
                        //videoViewIndex++;
                    }
                }
            }
        }

        private void settingPlayVideo()
        {
            SettingLayout? layout = _settingLayoutService.getLayoutSetting();
            if (layout == null)
            {
                MessageBox.Show("Layout lỗi, xin vui lòng thử lại sau");
            } 
            else
            {
                List<CameraInLayout> listCamera = layout.listCameras;
                if (listCamera != null || listCamera.Count > 0)
                {
                    foreach (CameraInLayout camera in listCamera)
                    {
                        dictTextBox[camera.cameraIndex].Text = camera.cameraLink;
                        run(camera.cameraIndex);
                        Thread.Sleep(100);
                        //await Task.Run(() => run(camera.cameraIndex));
                    }
                }
            }
        }

        private void dragDrop(object? sender, DragEventArgs e)
        {
            VideoView videoView = sender as VideoView;
            List<string> data = (List<string>)e.Data.GetData(typeof(List<string>));
            if (data != null && data.Count > 0)
            {
                string numberPart = new string(videoView.Name.Where(char.IsDigit).ToArray());
                int index = int.Parse(numberPart);
                if (data.Count == 1)
                {
                    dictTextBox[index].Text = data.First();
                }
                else
                {
                    int startIndex = dictVideoView.Select(kvp => kvp.Key).ToList().IndexOf(index);
                    var result = dictVideoView.Skip(startIndex).Take(data.Count);
                    int dataIndex = 0;
                    foreach (var kvp in result)
                    {
                        dictTextBox[kvp.Key].Text = data[dataIndex];
                        dataIndex++;
                    }
                }
            }
            else
            {
                throw new Exception("Không có camera nào được chọn");
            }
        }

        //private void dragTextBoxDrop(object? sender, DragEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    List<string> data = (List<string>)e.Data.GetData(typeof(List<string>));
        //    textBox.Text = string.Join(", ", data);
        //}

        private void dragEnter(object? sender, DragEventArgs e)
        {
            VideoView videoView = sender as VideoView;
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            string numberPart = new string(videoView.Name.Where(char.IsDigit).ToArray());
            int index = int.Parse(numberPart);
            if (_dictMediaPlayer[index].IsPlaying)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private async void textBoxKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null)
                {
                    string numberPart = new string(textBox.Name.Where(char.IsDigit).ToArray());
                    int index = int.Parse(numberPart);
                    try
                    {
                        await Task.Run(() =>
                        {
                            execute(index);
                        });
                        await Task.Run(() =>
                        {
                            retry(index, 3);
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        textBox.Visible = false;
                        dictVideoView[index].Dock = DockStyle.Fill;
                    }
                }
                e.SuppressKeyPress = true;

            }
        }
        
        private async void run(int index)
        {
            try
            {
                await Task.Run(() =>
                {
                    execute(index);
                });
                await Task.Run(() =>
                {
                    retry(index, 3);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dictTextBox[index].Visible = false;
                dictVideoView[index].Dock = DockStyle.Fill;
                //dictTextBox[index].Invoke(new Action(() => {
                //    dictTextBox[index].Visible = false;
                //}));
                
                //dictVideoView[index].Invoke(new Action(() => {
                //    dictVideoView[index].Dock = DockStyle.Fill;
                //}));
            }
        }

        private void rightTabButtonClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (right_tab_button.Text.Equals("<"))
                {
                    right_tab_button.Text = ">";
                }
                else if (right_tab_button.Text.Equals(">"))
                {
                    right_tab_button.Text = "<";
                }
                _settingLayoutService.updateIsRightTabVisible();
                rightTabClickEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        private async void execute(int index)
        {
            if (!string.IsNullOrWhiteSpace(dictTextBox[index].Text))
            {
                var media = new Media(_libVlc, new Uri(dictTextBox[index].Text), mediaOptions);
                var videoWidth = dictVideoView[index].Width;
                var videoHeight = dictVideoView[index].Height;
                var aspectRatio = $"{videoWidth}:{videoHeight}";
                _dictMediaPlayer[index].AspectRatio = aspectRatio;
                _dictMediaPlayer[index].Play(media);
            }
        }

        private async void retry(int index, int retry)
        {
            for (var time = 0; time < retry; time++)
            {
                await Task.Delay(5000);
                if (_dictMediaPlayer[index].IsPlaying)
                {
                    break;
                }
                else
                {
                    execute(index);
                }
            }
            if (_dictMediaPlayer[index].IsPlaying)
            {
                dictVideoView.Remove(index);
            }
        }

        public void runVideoDoubleClick(string link)
        {
            if (!string.IsNullOrWhiteSpace(link))
            {
                int index = dictVideoView.First().Key;
                dictTextBox[index].Text = link;
                run(index);
            }
        }

        public void removeVideo()
        {
            for (int i = 1; i <= _dictMediaPlayer.Count; i++)
            {
                _dictMediaPlayer[i].Stop();
                _dictMediaPlayer[i].Dispose();
            }
            _libVlc.Dispose();
        }
    }
}
