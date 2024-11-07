using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Model.Setting;
using ViettelWallClientNet8.Service.Setting;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveMainUserCtrl : UserControl
    {
        private int videoViewIndex = 1;
        private readonly ISettingLayoutService _settingLayoutService;
        public event EventHandler? leftTabClickEvent;
        public event EventHandler? rightTabClickEvent;
        public LiveMainUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
            settingLayout();
        }

        private void leftTabButtonClick(object sender, EventArgs e)
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
                        VideoView videoView = new VideoView();
                        main_table_layout_panel.Controls.Add(videoView, x, y);
                        videoView.BackColor = Color.FromArgb(170, 167, 167);
                        videoView.Dock = DockStyle.Fill;
                        videoView.MediaPlayer = null;
                        videoView.Size = new Size((int)Math.Floor(videoViewWidth), (int)Math.Floor(videoViewHeight));
                        videoView.Name = "videoView" + videoViewIndex;
                        videoView.Margin = new Padding(3, 3, 3, 3);
                        videoViewIndex++;
                    }
                }
            }
        }

        private void rightTabButtonClick(object sender, EventArgs e)
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
}
