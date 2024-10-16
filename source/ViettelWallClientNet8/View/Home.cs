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
        private bool is_click_camera_tab = true;
        private bool is_click_layout_tab = false;
        private bool is_click_tracking_tab = false;
        public Home()
        {
            InitializeComponent();
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
        }
        /// <summary>
        /// event when click on live panel in toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livePanelClick(object sender, EventArgs e)
        {
            live_panel.BackgroundImage = Properties.Resources.red_live_icon;
            replay_panel.BackgroundImage = Properties.Resources.white_replay_icon;
            tracking_panel.BackgroundImage = Properties.Resources.white_alert_icon;
            //navigate later
        }
        /// <summary>
        /// event when click on replay panel in toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replayPanelClick(object sender, EventArgs e)
        {
            live_panel.BackgroundImage = Properties.Resources.white_live_icon;
            replay_panel.BackgroundImage = Properties.Resources.red_replay_icon;
            tracking_panel.BackgroundImage = Properties.Resources.white_alert_icon;
            //navigate later
        }
        /// <summary>
        /// event when click on tracking panel in toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackingPanelClick(object sender, EventArgs e)
        {
            live_panel.BackgroundImage = Properties.Resources.white_live_icon;
            replay_panel.BackgroundImage = Properties.Resources.white_replay_icon;
            tracking_panel.BackgroundImage = Properties.Resources.red_alert_icon;
            //navigate later
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
        }

        private void full_screen_label_Click(object sender, EventArgs e)
        {
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
        }
        private void cameraTabBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_camera_tab && !is_click_layout_tab && !is_click_tracking_tab)
            {
                e.Graphics.Clear(camera_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, border_thickness))
                {
                    e.Graphics.DrawLine(pen, 0, 0, camera_tab_panel.Width - 1, camera_tab_panel.Height);
                    e.Graphics.DrawLine(pen, camera_tab_panel.Width - 1, 0, camera_tab_panel.Width - 1, camera_tab_panel.Height);
                }
            }
            else if (!is_click_camera_tab)
            {
                e.Graphics.Clear(camera_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, camera_tab_panel.Width - 1, camera_tab_panel.Height - 1);
                }
            }
        }
        private void layoutTabBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_layout_tab && !is_click_camera_tab && !is_click_tracking_tab)
            {
                e.Graphics.Clear(layout_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, border_thickness))
                {
                    e.Graphics.DrawLine(pen, 0, 0, layout_tab_panel.Width - 1, layout_tab_panel.Height);
                    e.Graphics.DrawLine(pen, layout_tab_panel.Width - 1, 0, layout_tab_panel.Width - 1, layout_tab_panel.Height);
                }
            }
            else if (!is_click_layout_tab)
            {
                e.Graphics.Clear(layout_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, layout_tab_panel.Width - 1, layout_tab_panel.Height - 1);
                }
            }
        }

        private void trackingTabBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_tracking_tab && !is_click_layout_tab && !is_click_camera_tab)
            {
                e.Graphics.Clear(tracking_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, border_thickness))
                {
                    e.Graphics.DrawLine(pen, 0, 0, tracking_tab_panel.Width - 1, tracking_tab_panel.Height);
                    e.Graphics.DrawLine(pen, tracking_tab_panel.Width - 1, 0, tracking_tab_panel.Width - 1, tracking_tab_panel.Height);
                }
            }
            else if (!is_click_tracking_tab)
            {
                e.Graphics.Clear(tracking_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, tracking_tab_panel.Width - 1, tracking_tab_panel.Height - 1);
                }
            }
        }

        private void liveCameraLabelClick(object sender, EventArgs e)
        {
            is_click_camera_tab = true;
            is_click_layout_tab = false;
            is_click_tracking_tab = false;
            camera_tab_label.BackColor = Color.FromArgb(64, 64, 64);
            layout_tab_label.BackColor = Color.FromArgb(190, 186, 191);
            tracking_tab_label.BackColor = Color.FromArgb(190, 186, 191);
            //set camera content
        }

        private void liveLayoutLabelClick(object sender, EventArgs e)
        {
            is_click_camera_tab = false;
            is_click_layout_tab = true;
            is_click_tracking_tab = false;
            layout_tab_label.BackColor = Color.FromArgb(64, 64, 64);
            camera_tab_label.BackColor = Color.FromArgb(190, 186, 191);
            tracking_tab_label.BackColor = Color.FromArgb(190, 186, 191);
            //set layout content
        }

        private void liveTrackingLabelClick(object sender, EventArgs e)
        {
            is_click_camera_tab = false;
            is_click_layout_tab = false;
            is_click_tracking_tab = true;
            tracking_tab_label.BackColor = Color.FromArgb(64, 64, 64);
            layout_tab_label.BackColor = Color.FromArgb(190, 186, 191);
            camera_tab_label.BackColor = Color.FromArgb(190, 186, 191);
            //set tracking content
        }

        private void tracking_on_label_Click(object sender, EventArgs e)
        {
            //later
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//
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
            if (this.ClientSize.Width == 0 && this.ClientSize.Height == 0)
            {
                return 1;
            }
            float widthRatio = (float)this.ClientSize.Width / original_width;
            float heightRatio = (float)this.ClientSize.Height / original_height;
            return Math.Min(widthRatio, heightRatio);
        }

        private float returnWidthSizeRatio()
        {
            if (this.ClientSize.Width == 0 && this.ClientSize.Height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Width / original_width;
        }

        private float returnHeightSizeRatio()
        {
            if (this.ClientSize.Width == 0 && this.ClientSize.Height == 0)
            {
                return 1;
            }
            return (float)this.ClientSize.Height / original_height;
        }
    }
}
