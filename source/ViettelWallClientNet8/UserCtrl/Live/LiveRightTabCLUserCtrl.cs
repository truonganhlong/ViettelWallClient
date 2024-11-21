using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveRightTabCLUserCtrl : UserControl
    {
        private Color border_color = Color.WhiteSmoke;
        private bool is_click_all_tab = true;
        private bool is_click_security_tab = false;
        private bool is_click_person_tab = false;
        private bool is_click_transportation_tab = false;
        private bool is_click_traffic_tab = false;
        public LiveRightTabCLUserCtrl()
        {
            InitializeComponent();
        }

        private void allTabPanelBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_all_tab && !is_click_security_tab && !is_click_person_tab && !is_click_transportation_tab && !is_click_traffic_tab)
            {
                e.Graphics.Clear(all_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    //e.Graphics.DrawLine(pen, 0, 0, 0, camera_tab_panel.Height);
                    e.Graphics.DrawLine(pen, all_tab_panel.Width - 1, 0, all_tab_panel.Width - 1, all_tab_panel.Height);
                }
                all_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                security_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                person_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                transportation_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                traffic_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                all_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                security_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                person_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                transportation_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                traffic_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_all_tab)
            {
                e.Graphics.Clear(all_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, all_tab_panel.Width - 1, all_tab_panel.Height - 1);
                }
            }
        }

        private void personTabPanelBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_person_tab && !is_click_all_tab && !is_click_security_tab && !is_click_traffic_tab && !is_click_transportation_tab)
            {
                e.Graphics.Clear(person_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    //e.Graphics.DrawLine(pen, 0, 0, 0, layout_tab_panel.Height);
                    e.Graphics.DrawLine(pen, person_tab_panel.Width - 1, 0, person_tab_panel.Width - 1, person_tab_panel.Height);
                }
                all_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                security_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                person_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                transportation_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                traffic_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                all_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                security_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                person_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                transportation_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                traffic_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_person_tab)
            {
                e.Graphics.Clear(person_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, person_tab_panel.Width - 1, person_tab_panel.Height - 1);
                }
            }
        }

        private void securityTabPanelBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_security_tab && !is_click_all_tab && !is_click_person_tab && !is_click_transportation_tab && !is_click_traffic_tab)
            {
                e.Graphics.Clear(security_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    //e.Graphics.DrawLine(pen, 0, 0, 0, layout_tab_panel.Height);
                    e.Graphics.DrawLine(pen, security_tab_panel.Width - 1, 0, security_tab_panel.Width - 1, security_tab_panel.Height);
                }
                all_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                security_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                person_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                transportation_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                traffic_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                all_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                security_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                person_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                transportation_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                traffic_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_security_tab)
            {
                e.Graphics.Clear(security_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, security_tab_panel.Width - 1, security_tab_panel.Height - 1);
                }
            }
        }

        private void trafficTabPanelBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_traffic_tab && !is_click_all_tab && !is_click_person_tab && !is_click_security_tab && !is_click_transportation_tab)
            {
                e.Graphics.Clear(traffic_tab_panel.BackColor);
                //using (Pen pen = new Pen(border_color, border_thickness))
                //{
                //    //e.Graphics.DrawLine(pen, 0, 0, 0, tracking_tab_panel.Height);
                //    e.Graphics.DrawLine(pen, tracking_tab_panel.Width - 1, 0, tracking_tab_panel.Width - 1, tracking_tab_panel.Height);
                //}
                all_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                security_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                person_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                transportation_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                traffic_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                all_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                security_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                person_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                transportation_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                traffic_tab_label.BackColor = Color.FromArgb(64, 64, 64);
            }
            else if (!is_click_traffic_tab)
            {
                e.Graphics.Clear(traffic_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, traffic_tab_panel.Width - 1, traffic_tab_panel.Height - 1);
                }
            }
        }

        private void transportationTabPanelBorderPaint(object sender, PaintEventArgs e)
        {
            if (is_click_transportation_tab && !is_click_all_tab && !is_click_person_tab && !is_click_security_tab && !is_click_traffic_tab)
            {
                e.Graphics.Clear(transportation_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    //e.Graphics.DrawLine(pen, 0, 0, 0, layout_tab_panel.Height);
                    e.Graphics.DrawLine(pen, transportation_tab_panel.Width - 1, 0, transportation_tab_panel.Width - 1, transportation_tab_panel.Height);
                }
                all_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                security_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                person_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                transportation_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                traffic_tab_label.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                all_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                security_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                person_tab_label.BackColor = Color.FromArgb(170, 167, 167);
                transportation_tab_label.BackColor = Color.FromArgb(64, 64, 64);
                traffic_tab_label.BackColor = Color.FromArgb(170, 167, 167);
            }
            else if (!is_click_transportation_tab)
            {
                e.Graphics.Clear(transportation_tab_panel.BackColor);
                using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, transportation_tab_panel.Width - 1, transportation_tab_panel.Height - 1);
                }
            }
        }

        private void allTabLabelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                is_click_all_tab = true;
                is_click_person_tab = false;
                is_click_security_tab = false;
                is_click_traffic_tab = false;
                is_click_transportation_tab = false;
                all_tab_panel.Invalidate();
                person_tab_panel.Invalidate();
                security_tab_panel.Invalidate();
                traffic_tab_panel.Invalidate();
                transportation_tab_panel.Invalidate();
            }
        }

        private void personTabLabelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                is_click_all_tab = false;
                is_click_person_tab = true;
                is_click_security_tab = false;
                is_click_traffic_tab = false;
                is_click_transportation_tab = false;
                all_tab_panel.Invalidate();
                person_tab_panel.Invalidate();
                security_tab_panel.Invalidate();
                traffic_tab_panel.Invalidate();
                transportation_tab_panel.Invalidate();
            }
        }

        private void securityTabLabelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                is_click_all_tab = false;
                is_click_security_tab = true;
                is_click_traffic_tab = false;
                is_click_person_tab = false;
                is_click_transportation_tab = false;
                all_tab_panel.Invalidate();
                person_tab_panel.Invalidate();
                security_tab_panel.Invalidate();
                traffic_tab_panel.Invalidate();
                transportation_tab_panel.Invalidate();
            }
        }

        private void trafficTabLabelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                is_click_all_tab = false;
                is_click_security_tab = false;
                is_click_traffic_tab = true;
                is_click_person_tab = false;
                is_click_transportation_tab = false;
                all_tab_panel.Invalidate();
                person_tab_panel.Invalidate();
                security_tab_panel.Invalidate();
                traffic_tab_panel.Invalidate();
                transportation_tab_panel.Invalidate();
            }
        }

        private void transportationTabLabelClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                is_click_all_tab = false;
                is_click_security_tab = false;
                is_click_traffic_tab = false;
                is_click_person_tab = false;
                is_click_transportation_tab = true;
                all_tab_panel.Invalidate();
                person_tab_panel.Invalidate();
                security_tab_panel.Invalidate();
                traffic_tab_panel.Invalidate();
                transportation_tab_panel.Invalidate();
            }
        }

        private void rightTabClControlPaintBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(right_tab_cl_control_panel.BackColor);
            using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
            {
                e.Graphics.DrawLine(pen, 0, 0, 0, right_tab_cl_control_panel.Height);
                e.Graphics.DrawLine(pen, 0, 0, right_tab_cl_control_panel.Width, 0);
            }
        }
    }
}
