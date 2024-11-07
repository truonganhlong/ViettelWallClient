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
using ViettelWallClientNet8.UserCtrl.Live;
using ViettelWallClientNet8.View;

namespace ViettelWallClientNet8.UserCtrl.Main
{
    public partial class MainUserCtrl : UserControl
    {
        private bool isResizeLayout = false;
        private LiveHeaderUserCtrl? liveHeaderUserCtrl = null;
        private LiveMainUserCtrl? liveMainUserCtrl = null;
        private LiveRightTabCLUserCtrl? liveRightTabCLUserCtrl = null;
        private LiveRightTabTUserCtrl? liveRightTabTUserCtrl = null;
        //interface...
        private readonly ISettingLayoutService _settingLayoutService;
        public MainUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
            //settingTab();
        }

        private void InitializeAfter()
        {

        }

        private void settingTab()
        {
            SettingLastView? lastView = _settingLayoutService.getLastViewSetting();
            if (lastView == null)
            {
                MessageBox.Show("Layout lỗi, xin vui lòng thử lại sau");
            }
            else
            {
                switch (lastView.mainTabSelected)
                {
                    case "Live":
                        settingLiveTab();
                        break;
                    case "Replay":
                        settingReplayTab();
                        break;
                    case "Tracking":
                        settingTrackingTab();
                        break;
                    default:
                        break;
                }
            }
        }

        private void settingLiveTab()
        {
            SettingLastView? lastView = _settingLayoutService.getLastViewSetting();
            if (lastView == null)
            {
                MessageBox.Show("Layout lỗi, xin vui lòng thử lại sau");
            }
            else
            {
                //LiveHeaderUserCtrl? liveHeaderUserCtrl = null;
                //LiveMainUserCtrl? liveMainUserCtrl = null;

                //LiveRightTabCLUserCtrl? liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
                //LiveRightTabTUserCtrl? liveRightTabTUserCtrl = new LiveRightTabTUserCtrl();

                foreach (Control control in main_table_layout.Controls)
                {
                    if (control is LiveHeaderUserCtrl)
                    {
                        liveHeaderUserCtrl = (LiveHeaderUserCtrl)control;
                        break;
                    }
                }

                foreach (Control control in main_table_layout.Controls)
                {
                    if (control is LiveMainUserCtrl && !isResizeLayout)
                    {
                        liveMainUserCtrl = (LiveMainUserCtrl)control;
                        break;
                    }
                }

                foreach (Control control in main_table_layout.Controls)
                {
                    if (control is LiveRightTabCLUserCtrl && !isResizeLayout)
                    {
                        liveRightTabCLUserCtrl = (LiveRightTabCLUserCtrl)control;
                        break;
                    }
                }

                foreach (Control control in main_table_layout.Controls)
                {
                    if (control is LiveRightTabTUserCtrl && !isResizeLayout)
                    {
                        liveRightTabTUserCtrl = (LiveRightTabTUserCtrl)control;
                        break;
                    }
                }

                // Nếu chưa tồn tại, tạo mới và thêm vào TableLayoutPanel
                if (liveHeaderUserCtrl == null)
                {
                    liveHeaderUserCtrl = new LiveHeaderUserCtrl();
                    liveHeaderUserCtrl.Dock = DockStyle.Fill;
                    liveHeaderUserCtrl.panel1x1ClickEvent += settingLayoutAfterSelectSize;
                    liveHeaderUserCtrl.panel2x2ClickEvent += settingLayoutAfterSelectSize;
                    liveHeaderUserCtrl.panel3x3ClickEvent += settingLayoutAfterSelectSize;
                    liveHeaderUserCtrl.panel4x4ClickEvent += settingLayoutAfterSelectSize;
                    liveHeaderUserCtrl.panel5x5ClickEvent += settingLayoutAfterSelectSize;
                    main_table_layout.Controls.Add(liveHeaderUserCtrl);
                }

                if (liveMainUserCtrl == null)
                {
                    liveMainUserCtrl = new LiveMainUserCtrl();
                    liveMainUserCtrl.leftTabClickEvent += leftTabButtonClick;
                    liveMainUserCtrl.rightTabClickEvent += rightTabButtonClick;
                    liveMainUserCtrl.Dock = DockStyle.Fill;
                    main_table_layout.Controls.Add(liveMainUserCtrl);
                }

                if(liveRightTabCLUserCtrl == null)
                {
                    liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
                }

                if(liveRightTabTUserCtrl == null)
                {
                    liveRightTabTUserCtrl = new LiveRightTabTUserCtrl();
                }

                if (!lastView.isLeftTabVisible && !lastView.isRightTabVisible)
                {
                    left_tab_panel.Visible = false;
                    main_table_layout.Controls.Add(liveHeaderUserCtrl, 0, 0);
                    main_table_layout.SetColumnSpan(liveHeaderUserCtrl, 83);
                    main_table_layout.SetRowSpan(liveHeaderUserCtrl, 2);
                    main_table_layout.Controls.Add(liveMainUserCtrl, 0, 2);
                    main_table_layout.SetColumnSpan(liveMainUserCtrl, 83);
                    main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                }
                else if (lastView.isLeftTabVisible && !lastView.isRightTabVisible)
                {
                    left_tab_panel.Visible = true;
                    main_table_layout.Controls.Add(liveHeaderUserCtrl, 16, 0);
                    main_table_layout.SetColumnSpan(liveHeaderUserCtrl, 67);
                    main_table_layout.SetRowSpan(liveHeaderUserCtrl, 2);
                    main_table_layout.Controls.Add(liveMainUserCtrl, 16, 2);
                    main_table_layout.SetColumnSpan(liveMainUserCtrl, 67);
                    main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                }
                else if (!lastView.isLeftTabVisible && lastView.isRightTabVisible)
                {
                    left_tab_panel.Visible = false;
                    main_table_layout.Controls.Add(liveHeaderUserCtrl, 0, 0);
                    main_table_layout.SetColumnSpan(liveHeaderUserCtrl, 83);
                    main_table_layout.SetRowSpan(liveHeaderUserCtrl, 2);
                    //code later
                    if(lastView.leftTabSelected == "Camera" || lastView.leftTabSelected == "Layout")
                    {
                        liveRightTabCLUserCtrl.Dock = DockStyle.Fill;
                        main_table_layout.Controls.Add(liveRightTabCLUserCtrl, 65, 2);
                        main_table_layout.SetColumnSpan(liveRightTabCLUserCtrl, 18);
                        main_table_layout.SetRowSpan(liveRightTabCLUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 0, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 65);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                    } else if(lastView.leftTabSelected == "Tracking")
                    {
                        liveRightTabTUserCtrl.Dock = DockStyle.Fill;
                        main_table_layout.Controls.Add(liveRightTabTUserCtrl, 71, 2);
                        main_table_layout.SetColumnSpan(liveRightTabTUserCtrl, 12);
                        main_table_layout.SetRowSpan(liveRightTabTUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 0, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 71);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                    }
                }
                else if (lastView.isLeftTabVisible && lastView.isRightTabVisible)
                {
                    left_tab_panel.Visible = true;
                    main_table_layout.Controls.Add(liveHeaderUserCtrl, 16, 0);
                    main_table_layout.SetColumnSpan(liveHeaderUserCtrl, 67);
                    main_table_layout.SetRowSpan(liveHeaderUserCtrl, 2);
                    //code later
                    if (lastView.leftTabSelected == "Camera" || lastView.leftTabSelected == "Layout")
                    {
                        liveRightTabCLUserCtrl.Dock = DockStyle.Fill;
                        main_table_layout.Controls.Add(liveRightTabCLUserCtrl, 65, 2);
                        main_table_layout.SetColumnSpan(liveRightTabCLUserCtrl, 18);
                        main_table_layout.SetRowSpan(liveRightTabCLUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 16, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 49);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                    }
                    else if (lastView.leftTabSelected == "Tracking")
                    {
                        liveRightTabTUserCtrl.Dock = DockStyle.Fill;
                        main_table_layout.Controls.Add(liveRightTabTUserCtrl, 71, 2);
                        main_table_layout.SetColumnSpan(liveRightTabTUserCtrl, 12);
                        main_table_layout.SetRowSpan(liveRightTabTUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 16, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 55);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                    }

                }
            }
        }

        private void settingLayoutAfterSelectSize(object? sender, EventArgs e)
        {
            //LiveMainUserCtrl liveMainUserCtrlResize = new LiveMainUserCtrl();
            //main_table_layout.Controls.Remove(liveMainUserCtrl);
            //main_table_layout.Controls.Add(liveMainUserCtrlResize, main_start_index, main_end_index);
            //main_table_layout.SetColumnSpan(liveMainUserCtrlResize, main_width_index);
            //main_table_layout.SetRowSpan(liveMainUserCtrlResize, main_height_index);
            //liveMainUserCtrl = liveMainUserCtrlResize;
            isResizeLayout = true;
            liveMainUserCtrl = null;
            liveRightTabCLUserCtrl = null;
            liveRightTabTUserCtrl = null;
            this.Invalidate();
            settingTab();
        }

        private void settingReplayTab()
        {

        }

        private void settingTrackingTab()
        {

        }

        private void leftTabButtonClick(object sender, EventArgs e)
        {
            this.Invalidate();
            settingTab();
        }

        private void rightTabButtonClick(object sender, EventArgs e)
        {
            this.Invalidate();
            settingTab();
        }

        private void liveCameraLeftTabClick(object sender, EventArgs e)
        {
            clearMainTableLayoutPanelExcept(left_tab_panel);
            settingTab();
        }

        private void liveLayoutLeftTabClick(object sender, EventArgs e)
        {
            clearMainTableLayoutPanelExcept(left_tab_panel);
            settingTab();
        }

        private void liveTrackingLeftTabClick(object sender, EventArgs e)
        {
            clearMainTableLayoutPanelExcept(left_tab_panel);
            settingTab();
        }
        public void livePanelClick(EventArgs e, int width, int height)
        {
            this.Controls.Clear();
            InitializeComponent();
            main_table_layout.Height = height;
            main_table_layout.Width = width;
            var liveLeftTabUserCtrl = new LiveLeftTabUserCtrl();
            liveLeftTabUserCtrl.Dock = DockStyle.Fill;
            liveLeftTabUserCtrl.liveCameraLeftTabClickEvent += liveCameraLeftTabClick;
            liveLeftTabUserCtrl.liveLayoutLeftTabClickEvent += liveLayoutLeftTabClick;
            liveLeftTabUserCtrl.liveTrackingLeftTabClickEvent += liveTrackingLeftTabClick;
            left_tab_panel.Controls.Add(liveLeftTabUserCtrl);
            _settingLayoutService.updateMainTabLocation("Live");
            this.Invalidate();
            settingLiveTab();
        }

        public void replayPanelClick(EventArgs e, int width, int height)
        {
            this.Controls.Clear();
            InitializeComponent();
            main_table_layout.Height = height;
            main_table_layout.Width = width;
            _settingLayoutService.updateMainTabLocation("Replay");
            this.Invalidate();
            settingReplayTab();
        }

        public void trackingPanelClick(EventArgs e, int width, int height)
        {
            this.Controls.Clear();
            InitializeComponent();
            main_table_layout.Height = height;
            main_table_layout.Width = width;
            _settingLayoutService.updateMainTabLocation("Tracking");
            this.Invalidate();
            settingTrackingTab();
        }

        private void clearMainTableLayoutPanelExcept(params Control[] excludeControls)
        {
            // Tạo một danh sách chứa các control cần giữ lại để tiện kiểm tra
            var controlsToKeep = new HashSet<Control>(excludeControls);

            // Lặp qua các control trong TableLayoutPanel
            for (int i = main_table_layout.Controls.Count - 1; i >= 0; i--)
            {
                Control control = main_table_layout.Controls[i];

                // Nếu control không nằm trong danh sách cần giữ lại, thì xóa nó
                if (!controlsToKeep.Contains(control))
                {
                    main_table_layout.Controls.Remove(control);
                }
            }
        }

    }
}
