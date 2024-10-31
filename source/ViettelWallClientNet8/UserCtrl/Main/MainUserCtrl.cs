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
        //interface...
        private readonly ISettingLayoutService _settingLayoutService;
        public MainUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
            settingTab();
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
                LiveHeaderUserCtrl? liveHeaderUserCtrl = null;
                LiveMainUserCtrl? liveMainUserCtrl = null;

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
                    if (control is LiveMainUserCtrl)
                    {
                        liveMainUserCtrl = (LiveMainUserCtrl)control;
                        break;
                    }
                }

                // Nếu chưa tồn tại, tạo mới và thêm vào TableLayoutPanel
                if (liveHeaderUserCtrl == null)
                {
                    liveHeaderUserCtrl = new LiveHeaderUserCtrl();
                    liveHeaderUserCtrl.Dock = DockStyle.Fill;
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
                        LiveRightTabCLUserCtrl? liveRightTabCLUserCtrl = null;
                        //foreach (Control control in main_table_layout.Controls)
                        //{
                        //    if (control is LiveRightTabCLUserCtrl)
                        //    {
                        //        liveRightTabCLUserCtrl = (LiveRightTabCLUserCtrl)control;
                        //        break;
                        //    }
                        //}

                        //if (liveRightTabCLUserCtrl == null)
                        //{
                        //    liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
                        //    liveRightTabCLUserCtrl.Dock = DockStyle.Fill;
                        //    main_table_layout.Controls.Add(liveRightTabCLUserCtrl);
                        //}
                        liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
                        liveRightTabCLUserCtrl.Dock = DockStyle.Fill;

                        main_table_layout.Controls.Add(liveRightTabCLUserCtrl, 65, 2);
                        main_table_layout.SetColumnSpan(liveRightTabCLUserCtrl, 18);
                        main_table_layout.SetRowSpan(liveRightTabCLUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 0, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 65);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                    } else if(lastView.leftTabSelected == "Tracking")
                    {
                        LiveRightTabTUserCtrl? liveRightTabTUserCtrl = null;
                        //foreach (Control control in main_table_layout.Controls)
                        //{
                        //    if (control is LiveRightTabTUserCtrl)
                        //    {
                        //        liveRightTabTUserCtrl = (LiveRightTabTUserCtrl)control;
                        //        break;
                        //    }
                        //}

                        //if (liveRightTabTUserCtrl == null)
                        //{
                        //    liveRightTabTUserCtrl = new LiveRightTabTUserCtrl();
                        //    liveRightTabTUserCtrl.Dock = DockStyle.Fill;
                        //    main_table_layout.Controls.Add(liveRightTabTUserCtrl);
                        //}
                        liveRightTabTUserCtrl = new LiveRightTabTUserCtrl();
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
                        LiveRightTabCLUserCtrl? liveRightTabCLUserCtrl = null;
                        //foreach (Control control in main_table_layout.Controls)
                        //{
                        //    if (control is LiveRightTabCLUserCtrl)
                        //    {
                        //        liveRightTabCLUserCtrl = (LiveRightTabCLUserCtrl)control;
                        //        break;
                        //    }
                        //}

                        //if (liveRightTabCLUserCtrl == null)
                        //{
                        //    liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
                        //    liveRightTabCLUserCtrl.Dock = DockStyle.Fill;
                        //    main_table_layout.Controls.Add(liveRightTabCLUserCtrl);
                        //}
                        liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
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
                        LiveRightTabTUserCtrl? liveRightTabTUserCtrl = null;
                        //foreach (Control control in main_table_layout.Controls)
                        //{
                        //    if (control is LiveRightTabTUserCtrl)
                        //    {
                        //        liveRightTabTUserCtrl = (LiveRightTabTUserCtrl)control;
                        //        break;
                        //    }
                        //}

                        //if (liveRightTabTUserCtrl == null)
                        //{
                        //    liveRightTabTUserCtrl = new LiveRightTabTUserCtrl();
                        //    liveRightTabTUserCtrl.Dock = DockStyle.Fill;
                        //    main_table_layout.Controls.Add(liveRightTabTUserCtrl);
                        //}
                        liveRightTabTUserCtrl = new LiveRightTabTUserCtrl();
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
            this.Invalidate();
            settingTab();
        }

        private void liveLayoutLeftTabClick(object sender, EventArgs e)
        {
            this.Invalidate();
            settingTab();
        }

        private void liveTrackingLeftTabClick(object sender, EventArgs e)
        {
            this.Invalidate();
            settingTab();
        }
        public void livePanelClick(EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
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

        public void replayPanelClick(EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            _settingLayoutService.updateMainTabLocation("Replay");
            this.Invalidate();
            settingReplayTab();
        }

        public void trackingPanelClick(EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            _settingLayoutService.updateMainTabLocation("Tracking");
            this.Invalidate();
            settingTrackingTab();
        }

    }
}
