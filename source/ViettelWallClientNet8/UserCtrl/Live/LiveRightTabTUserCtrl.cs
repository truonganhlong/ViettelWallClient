using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Custom;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveRightTabTUserCtrl : UserControl
    {
        private int childPanelCount = 8;
        private Color border_color = Color.WhiteSmoke;
        public LiveRightTabTUserCtrl()
        {
            InitializeComponent();
            InitializeAfter();
        }

        private void InitializeAfter()
        {
            scrollable_panel.AutoScroll = false;
            scrollable_panel.HorizontalScroll.Maximum = 0;
            scrollable_panel.VerticalScroll.Maximum = 0;
            //scrollable_panel.VerticalScroll.Visible = false;
            //scrollable_panel.HorizontalScroll.Visible = false;
            scrollable_panel.AutoScroll = true;
            live_right_tab_t_flow_layout_panel.Size = new Size(scrollable_panel.Width, scrollable_panel.Height / 6 * childPanelCount);
            live_right_tab_t_flow_layout_panel.Controls.Clear();
            for (int i = 0; i < childPanelCount; i++)
            {
                RoundedPanel childPanel = new RoundedPanel();
                childPanel.BorderRadius = 10;

                childPanel.Size = new Size(scrollable_panel.Width - 6, (scrollable_panel.Height - 36) / 6);
                childPanel.BackColor = Color.WhiteSmoke;
                childPanel.Margin = new Padding(3, 3, 1, 3);
                live_right_tab_t_flow_layout_panel.Controls.Add(childPanel);
            }
        }

        private void resize(object sender, EventArgs e)
        {
            InitializeAfter();
        }

        //private void liveRightTabBorderPaint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.Clear(live_right_tab_t_flow_layout_panel.BackColor);
        //    using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
        //    {
        //        e.Graphics.DrawLine(pen, 0, 0, live_right_tab_t_flow_layout_panel.Width, 0); // Vẽ từ (0,0) đến (Width,0)

        //        e.Graphics.DrawLine(pen, 0, 0, 0, live_right_tab_t_flow_layout_panel.Height); // Vẽ từ (0,0) đến (0,Height)
        //    }
        //}

        private void scrollablePanelBorderPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(scrollable_panel.BackColor);
            using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
            {
                e.Graphics.DrawLine(pen, 0, 0, scrollable_panel.Width, 0); // Vẽ từ (0,0) đến (Width,0)

                e.Graphics.DrawLine(pen, 0, 0, 0, scrollable_panel.Height); // Vẽ từ (0,0) đến (0,Height)
            }
        }
    }
}
