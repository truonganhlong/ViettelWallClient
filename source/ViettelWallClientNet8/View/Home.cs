using System;
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


namespace ViettelWallClientNet8.View
{
    public partial class Home : Form
    {
        private float border_thickness = 0.75F;
        private Color border_color = Color.WhiteSmoke;
        private PerformanceCounter cpu_counter;
        private PerformanceCounter ram_counter;
        public Home()
        {
            InitializeComponent();
            cpu_counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ram_counter = new PerformanceCounter("Memory", "Available MBytes");
        }

        private void footerBorderPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(footer_panel.BackColor);
            using (Pen pen = new Pen(border_color, border_thickness))
            {
                e.Graphics.DrawLine(pen, 0, 0, footer_panel.Width, 0);
            }
        }

        private void toolbarBorderPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(toolbar_panel.BackColor);
            using (Pen pen = new Pen(border_color, border_thickness))
            {
                e.Graphics.DrawLine(pen, toolbar_panel.Width - 1, 0, toolbar_panel.Width - 1, toolbar_panel.Height);
            }
        }

        private void resize(object sender, EventArgs e)
        {
            footer_panel.Invalidate();
            toolbar_panel.Invalidate();
            live_panel.Invalidate();
        }

        private void livePanelClick(object sender, EventArgs e)
        {
            //navigate later
        }

        private void replayPanelClick(object sender, EventArgs e)
        {
            //navigate later
        }

        private void trackingPanelClick(object sender, EventArgs e)
        {
            //navigate later
        }

        private void livePanelPaint(object sender, PaintEventArgs e)
        {
            if (live_panel.BackgroundImage != null)
            {
                // Tính toán tỷ lệ của hình ảnh
                float imageAspectRatio = (float)live_panel.BackgroundImage.Width / live_panel.BackgroundImage.Height;
                float panelAspectRatio = (float)live_panel.Width / live_panel.Height;

                int newWidth, newHeight;

                // Kiểm tra tỷ lệ để xác định cách vẽ hình ảnh
                if (imageAspectRatio > panelAspectRatio)
                {
                    // Hình ảnh rộng hơn tỷ lệ panel
                    newWidth = live_panel.Width;
                    newHeight = (int)(live_panel.Width / imageAspectRatio);
                }
                else
                {
                    // Hình ảnh cao hơn tỷ lệ panel
                    newHeight = live_panel.Height;
                    newWidth = (int)(live_panel.Height * imageAspectRatio);
                }

                // Tính toán vị trí để căn giữa hình ảnh
                int x = (live_panel.Width - newWidth) / 2;
                int y = (live_panel.Height - newHeight) / 2;

                // Vẽ hình ảnh
                e.Graphics.DrawImage(live_panel.BackgroundImage, x, y, newWidth, newHeight);

            }
        }

        private void cpuAndRamTimerTick(object sender, EventArgs e)
        {
            float cpuUsage = cpu_counter.NextValue();

            float totalRam = GetTotalPhysicalMemory();
            float availableRam = ram_counter.NextValue();
            float usedRam = totalRam - availableRam;

            cpu_and_ram_label.Text = $"CPU:{cpuUsage:F1}%   RAM:{usedRam/totalRam*100:F1}%";
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
    }
}
