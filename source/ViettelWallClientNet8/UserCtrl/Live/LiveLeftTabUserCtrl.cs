using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Service.Setting;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveLeftTabUserCtrl : UserControl
    {
        private Color border_color = Color.WhiteSmoke;
        private bool is_click_camera_tab = true;
        private bool is_click_layout_tab = false;
        private bool is_click_tracking_tab = false;
        public event EventHandler? liveCameraLeftTabClickEvent;
        public event EventHandler? liveLayoutLeftTabClickEvent;
        public event EventHandler? liveTrackingLeftTabClickEvent;
        public event Action<string> sendLinkDoubleClick;
        public event Action<bool> sendToggleStatus;
        public event Action<bool> sendLayoutDetailClick;
        //interface
        private readonly ISettingLayoutService _settingLayoutService;
        public LiveLeftTabUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
        }

        private void InitializeAfter()
        {
            var mouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
            switch (_settingLayoutService.getLastViewSetting().leftTabSelected)
            {
                case "Camera":
                    liveCameraLabelClick(camera_tab_label, mouseEventArgs);
                    break;
                case "Layout":
                    liveLayoutLabelClick(layout_tab_label, mouseEventArgs);
                    break;
                case "Tracking":
                    liveTrackingLabelClick(tracking_tab_label, mouseEventArgs);
                    break;
                default:
                    break;
            }
        }
        private void leftTabControlPaintBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(left_tab_control_panel.BackColor);
            using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
            {
                e.Graphics.DrawLine(pen, left_tab_control_panel.Width - 1, 0, left_tab_control_panel.Width - 1, left_tab_control_panel.Height);
            }
        }

        private void cameraTabBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_camera_tab && !is_click_layout_tab && !is_click_tracking_tab)
            {
                e.Graphics.Clear(camera_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    //e.Graphics.DrawLine(pen, 0, 0, 0, camera_tab_panel.Height);
                    e.Graphics.DrawLine(pen, camera_tab_panel.Width - 1, 0, camera_tab_panel.Width - 1, camera_tab_panel.Height);
                }
                camera_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                layout_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tracking_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                camera_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                layout_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                tracking_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_camera_tab)
            {
                e.Graphics.Clear(camera_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, camera_tab_panel.Width - 1, camera_tab_panel.Height - 1);
                }
            }
        }

        private void liveCameraLabelClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                is_click_camera_tab = true;
                is_click_layout_tab = false;
                is_click_tracking_tab = false;
                camera_tab_panel.Invalidate();
                layout_tab_panel.Invalidate();
                tracking_tab_panel.Invalidate();
                _settingLayoutService.updateLeftTabLocation("Camera");
                liveCameraLeftTabClickEvent?.Invoke(this, EventArgs.Empty);
                left_tab_content.Controls.Clear();
                LiveLeftCameraTabUserCtrl liveLeftCameraTabUserCtrl = new LiveLeftCameraTabUserCtrl();
                liveLeftCameraTabUserCtrl.Dock = DockStyle.Fill;
                liveLeftCameraTabUserCtrl.Padding = new Padding(1);
                liveLeftCameraTabUserCtrl.sendLinkDoubleClick += passLinkDoubleClick;
                left_tab_content.Controls.Add(liveLeftCameraTabUserCtrl);
            }
            
        }

        private void layoutTabBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_layout_tab && !is_click_camera_tab && !is_click_tracking_tab)
            {
                e.Graphics.Clear(layout_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    //e.Graphics.DrawLine(pen, 0, 0, 0, layout_tab_panel.Height);
                    e.Graphics.DrawLine(pen, layout_tab_panel.Width - 1, 0, layout_tab_panel.Width - 1, layout_tab_panel.Height);
                }
                camera_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                layout_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tracking_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                layout_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                camera_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                tracking_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_layout_tab)
            {
                e.Graphics.Clear(layout_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, layout_tab_panel.Width - 1, layout_tab_panel.Height - 1);
                }
            }
        }

        private void liveLayoutLabelClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                is_click_camera_tab = false;
                is_click_layout_tab = true;
                is_click_tracking_tab = false;
                layout_tab_panel.Invalidate();
                camera_tab_panel.Invalidate();
                tracking_tab_panel.Invalidate();
                _settingLayoutService.updateLeftTabLocation("Layout");
                liveLayoutLeftTabClickEvent?.Invoke(this, EventArgs.Empty);
                left_tab_content.Controls.Clear();
                LiveLeftLayoutTabUserCtrl liveLeftLayoutTabUserCtrl = new LiveLeftLayoutTabUserCtrl();
                liveLeftLayoutTabUserCtrl.Dock = DockStyle.Fill;
                liveLeftLayoutTabUserCtrl.Padding = new Padding(1);
                liveLeftLayoutTabUserCtrl.sendLinkDoubleClick += passLinkDoubleClick;
                liveLeftLayoutTabUserCtrl.sendToggleStatus += passToggleStatus;
                liveLeftLayoutTabUserCtrl.sendLayoutDetailClick += passLayoutDetailClick;
                left_tab_content.Controls.Add(liveLeftLayoutTabUserCtrl);
            }
        }

        private void trackingTabBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_tracking_tab && !is_click_layout_tab && !is_click_camera_tab)
            {
                e.Graphics.Clear(tracking_tab_panel.BackColor);
                //using (Pen pen = new Pen(border_color, border_thickness))
                //{
                //    //e.Graphics.DrawLine(pen, 0, 0, 0, tracking_tab_panel.Height);
                //    e.Graphics.DrawLine(pen, tracking_tab_panel.Width - 1, 0, tracking_tab_panel.Width - 1, tracking_tab_panel.Height);
                //}
                camera_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                layout_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tracking_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tracking_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                layout_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                camera_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_tracking_tab)
            {
                e.Graphics.Clear(tracking_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, tracking_tab_panel.Width - 1, tracking_tab_panel.Height - 1);
                }
            }
        }

        private void liveTrackingLabelClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                is_click_camera_tab = false;
                is_click_layout_tab = false;
                is_click_tracking_tab = true;
                tracking_tab_panel.Invalidate();
                camera_tab_panel.Invalidate();
                layout_tab_panel.Invalidate();
                _settingLayoutService.updateLeftTabLocation("Tracking");
                liveTrackingLeftTabClickEvent?.Invoke(this, EventArgs.Empty);
                left_tab_content.Controls.Clear();
            }
        }

        private void passLinkDoubleClick(string link)
        {
            sendLinkDoubleClick?.Invoke(link);
        }

        private void passToggleStatus(bool status)
        {
            sendToggleStatus?.Invoke(status);
        }

        private void passLayoutDetailClick(bool status)
        {
            sendLayoutDetailClick?.Invoke(status);
        }

    }
}
