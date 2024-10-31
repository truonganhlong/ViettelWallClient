using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveRightTabTUserCtrl : UserControl
    {
        private int childPanelCount = 8;
        public LiveRightTabTUserCtrl()
        {
            InitializeComponent();
            InitializeAfter();
        }

        private void InitializeAfter()
        {
            live_right_tab_t_flow_layout_panel.Size = new Size(scrollable_panel.Width, scrollable_panel.Height / 6 * childPanelCount);
            for (int i = 0; i < childPanelCount; i++)
            {
                Panel childPanel = new Panel();
                childPanel.Size = new Size(scrollable_panel.Width, scrollable_panel.Height / 6);
                childPanel.BackColor = (i % 2 == 0) ? Color.LightBlue : Color.LightGreen;
                childPanel.Margin = new Padding(0);
                live_right_tab_t_flow_layout_panel.Controls.Add(childPanel);
            }
        }
    }
}
