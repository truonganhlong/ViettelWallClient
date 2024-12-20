﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Windows.Forms;
using System.Management;
using System.Windows.Forms.VisualStyles;
using ViettelWallClientNet8.Model.Setting;
using LibVLCSharp.WinForms;
using LibVLCSharp.Shared;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Service.Setting;
using ViettelWallClientNet8.UserCtrl.Live;
using ViettelWallClientNet8.UserCtrl.Main;


namespace ViettelWallClientNet8.View
{
    public partial class Home : Form
    {
        private float original_width;
        private float original_height;
        private float border_thickness = 0.75F;
        private Color border_color = Color.WhiteSmoke;
        private PerformanceCounter cpu_counter;
        private PerformanceCounter ram_counter;
        private float original_icon_size;
        private float original_icon_size_type2;
        private float original_cpu_and_ram_label_width;
        private float original_cpu_and_ram_label_height;
        private float original_cpu_and_ram_label_location_x;
        private float original_cpu_and_ram_label_location_y;
        private float original_cpu_and_ram_label_font_size;
        private float original_tracking_on_label_width;
        private float original_tracking_on_label_height;
        private float original_tracking_on_label_location_x;
        private float original_tracking_on_label_location_y;
        private float original_tracking_on_label_font_size;
        private float original_full_screen_label_width;
        private float original_full_screen_label_height;
        private float original_full_screen_label_location_x;
        private float original_full_screen_label_location_y;
        private float original_full_screnn_label_font_size;
        private float original_main_user_ctrl_width;
        private float original_main_user_ctrl_height;
        private int videoViewIndex = 1;

        //interface...
        private readonly ISettingLayoutService _settingLayoutService;
        public Home()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
            InitialMouseDown();
            cpu_counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ram_counter = new PerformanceCounter("Memory", "Available MBytes");
        }


        /// <summary>
        /// paint border for footer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void footerBorderPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(footer_panel.BackColor);
            using (Pen pen = new Pen(border_color, border_thickness))
            {
                e.Graphics.DrawLine(pen, 0, 0, footer_panel.Width, 0);
            }
        }
        /// <summary>
        /// paint border for toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbarBorderPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(toolbar_panel.BackColor);
            using (Pen pen = new Pen(border_color, border_thickness))
            {
                e.Graphics.DrawLine(pen, toolbar_panel.Width - 1, 0, toolbar_panel.Width - 1, toolbar_panel.Height);
            }
        }
        /// <summary>
        /// resize form event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resize(object sender, EventArgs e)
        {
            footer_panel.Invalidate();
            toolbar_panel.Invalidate();
            main_user_ctrl.Invalidate();
            float minResizeRatio = returnMinSizeRatio();
            float widthResizeRatio = returnWidthSizeRatio();
            float heightResizeRatio = returnHeightSizeRatio();
            live_panel.Width = (int)(original_icon_size * minResizeRatio);
            live_panel.Height = (int)(original_icon_size * minResizeRatio);
            replay_panel.Width = (int)(original_icon_size * minResizeRatio);
            replay_panel.Height = (int)(original_icon_size * minResizeRatio);
            tracking_panel.Width = (int)(original_icon_size * minResizeRatio);
            tracking_panel.Height = (int)(original_icon_size * minResizeRatio);
            cpu_and_ram_label.Width = (int)(original_cpu_and_ram_label_width * widthResizeRatio);
            cpu_and_ram_label.Height = (int)(original_cpu_and_ram_label_height * heightResizeRatio);
            cpu_and_ram_label.Font = new Font(cpu_and_ram_label.Font.FontFamily, original_cpu_and_ram_label_font_size * minResizeRatio);
            cpu_and_ram_label.Location = new Point((int)(original_cpu_and_ram_label_location_x * widthResizeRatio), (int)(original_cpu_and_ram_label_location_y * heightResizeRatio));
            tracking_on_label.Width = (int)(original_tracking_on_label_width * widthResizeRatio);
            tracking_on_label.Height = (int)(original_tracking_on_label_height * heightResizeRatio);
            tracking_on_label.Font = new Font(tracking_on_label.Font.FontFamily, original_tracking_on_label_font_size * minResizeRatio);
            tracking_on_label.Location = new Point((int)(original_tracking_on_label_location_x * widthResizeRatio), (int)(original_tracking_on_label_location_y * heightResizeRatio));
            if (original_icon_size_type2 != 0 && tracking_on_label.Image != null)
            {
                Size newSize = new Size((int)(tracking_on_label.Image.Width * minResizeRatio), (int)(tracking_on_label.Image.Height * minResizeRatio));
                Image resizedImage = new Bitmap(tracking_on_label.Image, newSize);
                tracking_on_label.Image = resizedImage;
            }

            full_screen_label.Width = (int)(original_full_screen_label_width * widthResizeRatio);
            full_screen_label.Height = (int)(original_full_screen_label_height * heightResizeRatio);
            full_screen_label.Font = new Font(full_screen_label.Font.FontFamily, original_full_screnn_label_font_size * minResizeRatio);
            full_screen_label.Location = new Point((int)(original_full_screen_label_location_x * widthResizeRatio), (int)(original_full_screen_label_location_y * heightResizeRatio));
            if (original_icon_size_type2 != 0 && full_screen_label.Image != null)
            {
                Size newSize = new Size((int)(full_screen_label.Image.Width * minResizeRatio), (int)(full_screen_label.Image.Height * minResizeRatio));
                Image resizedImage = new Bitmap(full_screen_label.Image, newSize);
                full_screen_label.Image = resizedImage;
            }
            main_user_ctrl.Width = (int)(original_main_user_ctrl_width * this.ClientSize.Width / original_width);
            main_user_ctrl.Height = (int)(original_main_user_ctrl_height * this.ClientSize.Height / original_height);
        }
        /// <summary>
        /// event when click on live panel in toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livePanelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                live_panel.BackgroundImage = Properties.Resources.red_live_icon;
                replay_panel.BackgroundImage = Properties.Resources.white_replay_icon;
                tracking_panel.BackgroundImage = Properties.Resources.white_alert_icon;
                main_user_ctrl.livePanelClick(e, main_user_ctrl.Width, main_user_ctrl.Height);
            }
        }
        /// <summary>
        /// event when click on replay panel in toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replayPanelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                live_panel.BackgroundImage = Properties.Resources.white_live_icon;
                replay_panel.BackgroundImage = Properties.Resources.red_replay_icon;
                tracking_panel.BackgroundImage = Properties.Resources.white_alert_icon;
                main_user_ctrl.replayPanelClick(e, main_user_ctrl.Width, main_user_ctrl.Height);
            }
        }
        /// <summary>
        /// event when click on tracking panel in toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackingPanelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                live_panel.BackgroundImage = Properties.Resources.white_live_icon;
                replay_panel.BackgroundImage = Properties.Resources.white_replay_icon;
                tracking_panel.BackgroundImage = Properties.Resources.red_alert_icon;
                main_user_ctrl.trackingPanelClick(e, main_user_ctrl.Width, main_user_ctrl.Height);
            }
        }

        //}
        /// <summary>
        /// get % cpu and ram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpuAndRamTimerTick(object sender, EventArgs e)
        {
            float cpuUsage = cpu_counter.NextValue();

            float totalRam = GetTotalPhysicalMemory();
            float availableRam = ram_counter.NextValue();
            float usedRam = totalRam - availableRam;

            cpu_and_ram_label.Text = $"CPU:{cpuUsage:F1}%   RAM:{usedRam / totalRam * 100:F1}%";
        }
        private void Home_Load(object sender, EventArgs e)
        {
            original_width = this.ClientSize.Width;
            original_height = this.ClientSize.Height;
            original_cpu_and_ram_label_font_size = cpu_and_ram_label.Font.Size;
            original_icon_size = Math.Min(live_panel.Width, live_panel.Height);
            original_tracking_on_label_font_size = tracking_on_label.Font.Size;
            original_full_screnn_label_font_size = full_screen_label.Font.Size;
            original_cpu_and_ram_label_location_x = cpu_and_ram_label.Location.X;
            original_cpu_and_ram_label_location_y = cpu_and_ram_label.Location.Y;
            original_tracking_on_label_location_x = tracking_on_label.Location.X;
            original_tracking_on_label_location_y = tracking_on_label.Location.Y;
            original_full_screen_label_location_x = full_screen_label.Location.X;
            original_full_screen_label_location_y = full_screen_label.Location.Y;
            if (full_screen_label.Image != null)
            {
                original_icon_size_type2 = Math.Min(full_screen_label.Image.Width, full_screen_label.Image.Height);
            }
            original_cpu_and_ram_label_width = cpu_and_ram_label.Width;
            original_cpu_and_ram_label_height = cpu_and_ram_label.Height;
            original_tracking_on_label_width = tracking_on_label.Width;
            original_tracking_on_label_height = tracking_on_label.Height;
            original_full_screen_label_width = full_screen_label.Width;
            original_full_screen_label_height = full_screen_label.Height;
            original_main_user_ctrl_width = main_user_ctrl.Width;
            original_main_user_ctrl_height = main_user_ctrl.Height;
            SettingLastView? settingLastView = _settingLayoutService.getLastViewSetting();
            if (settingLastView != null && settingLastView.isFullScreen)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (settingLastView != null && !settingLastView.isFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void full_screen_label_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    full_screen_label.Image = Properties.Resources.white_full_screen_icon;
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    full_screen_label.Image = Properties.Resources.white_minimize_screen_icon;
                }
                _settingLayoutService.updateIsFullScreen();
            }
        }

        private void tracking_on_label_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                //later   
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------//
        private void InitializeAfter()
        {
            // set main tab selected in history
            var mouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
            SettingLastView? settingLastView = _settingLayoutService.getLastViewSetting();
            if (settingLastView != null)
            {
                switch (settingLastView.mainTabSelected)
                {
                    case "Live":
                        livePanelClick(live_panel, mouseEventArgs);
                        break;
                    case "Replay":
                        replayPanelClick(replay_panel, mouseEventArgs);
                        break;
                    case "Tracking":
                        trackingPanelClick(tracking_panel, mouseEventArgs);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                // think later
            }
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                UpdateKeyPress(this, true, false);  
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                UpdateKeyPress(this, false, true);
            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                UpdateKeyPress(this, false, false);
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                UpdateKeyPress(this, false, false);
            }
        }

        private float GetTotalPhysicalMemory()
        {
            // Sử dụng WMI để lấy tổng bộ nhớ vật lý
            var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in searcher.Get())
            {
                return Convert.ToSingle(obj["TotalVisibleMemorySize"]) / 1024; // Chuyển đổi từ KB sang MB
            }
            return 0;
        }

        private float returnMinSizeRatio()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0 || original_width == 0 || original_height == 0)
            {
                return 1;
            }
            float widthRatio = (float)this.ClientSize.Width / original_width;
            float heightRatio = (float)this.ClientSize.Height / original_height;
            return Math.Min(widthRatio, heightRatio);
        }

        private float returnWidthSizeRatio()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0 || original_width == 0 || original_height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Width / original_width;
        }

        private float returnHeightSizeRatio()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0 || original_width == 0 || original_height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Height / original_height;
        }

        private void sizeChanged(object sender, EventArgs e)
        {
            _settingLayoutService.updateIsFullScreen();
        }

        private void InitialMouseDown()
        {
            RegisterMouseDown(this);
        }
        private void RegisterMouseDown(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                control.MouseDown += Control_MouseDown;
                RegisterMouseDown(control); 
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!main_user_ctrl.setting_layout_panel.Bounds.Contains(this.PointToClient(Cursor.Position)) && main_user_ctrl.setting_layout_panel.Visible)
            {
                main_user_ctrl.setting_layout_panel.Visible = false;
            }
        }

        private void UpdateKeyPress(Control parent, bool isShiftKey, bool isCtrlKey)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is LiveLeftCameraTabUserCtrl liveLeftCameraTabUserCtrl)
                {
                    liveLeftCameraTabUserCtrl.isShiftKeyPress = isShiftKey;
                    liveLeftCameraTabUserCtrl.isCtrlKeyPress = isCtrlKey;
                }

                if (control is LiveLeftLayoutTabUserCtrl liveLeftLayoutTabUserCtrl) { 
                    liveLeftLayoutTabUserCtrl.isShiftKeyPress = isShiftKey;
                    liveLeftLayoutTabUserCtrl.isCtrlKeyPress = isCtrlKey;
                }

                if (control.HasChildren)
                {
                    UpdateKeyPress(control, isShiftKey, isCtrlKey);
                }
            }
        }

    }
}
