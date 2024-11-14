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
        private LiveHeaderUserCtrl? liveHeaderUserCtrl = null;
        private LiveMainUserCtrl? liveMainUserCtrl = null;
        private LiveRightTabCLUserCtrl? liveRightTabCLUserCtrl = null;
        private LiveRightTabTUserCtrl? liveRightTabTUserCtrl = null;
        //interface...
        private readonly ISettingLayoutService _settingLayoutService;

        //
        private int main_start_index;
        private int main_end_index;
        private int main_width_index;
        private int main_height_index;
        //
        private bool isOpenLayoutSetting = false;
        //
        private Label setting_layout_result_label = new Label();
        private TableLayoutPanel setting_table_layout = new TableLayoutPanel();
        //
        private int startRow = 0;
        private int startColumn = 9;
        private int hoverRowEnd = 0;
        private int hoverColumnEnd = 0;
        private int previousRow = -1;
        private int previousColumn = -1;
        private bool isChooseLayout = false;
        public MainUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
            //settingTab();
        }

        private void InitializeAfter()
        {
            this.MouseDown += new MouseEventHandler(UserControl_MouseDown);
        }

        private void UserControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!this.ClientRectangle.Contains(e.Location))
            {
                if (!setting_table_layout.Bounds.Contains(e.Location))
                {
                    setting_layout_panel.Visible = false;
                }
            }
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
                    if (control is LiveMainUserCtrl)
                    {
                        liveMainUserCtrl = (LiveMainUserCtrl)control;
                        break;
                    }
                }

                foreach (Control control in main_table_layout.Controls)
                {
                    if (control is LiveRightTabCLUserCtrl)
                    {
                        liveRightTabCLUserCtrl = (LiveRightTabCLUserCtrl)control;
                        break;
                    }
                }

                foreach (Control control in main_table_layout.Controls)
                {
                    if (control is LiveRightTabTUserCtrl)
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
                    liveHeaderUserCtrl.panelCustomClickEvent += openLayoutSetting;
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

                if (liveRightTabCLUserCtrl == null)
                {
                    liveRightTabCLUserCtrl = new LiveRightTabCLUserCtrl();
                }

                if (liveRightTabTUserCtrl == null)
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
                    main_start_index = 0;
                    main_end_index = 2;
                    main_width_index = 83;
                    main_height_index = 47;
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
                    main_start_index = 16;
                    main_end_index = 2;
                    main_width_index = 67;
                    main_height_index = 47;
                }
                else if (!lastView.isLeftTabVisible && lastView.isRightTabVisible)
                {
                    left_tab_panel.Visible = false;
                    main_table_layout.Controls.Add(liveHeaderUserCtrl, 0, 0);
                    main_table_layout.SetColumnSpan(liveHeaderUserCtrl, 83);
                    main_table_layout.SetRowSpan(liveHeaderUserCtrl, 2);
                    //code later
                    if (lastView.leftTabSelected == "Camera" || lastView.leftTabSelected == "Layout")
                    {
                        liveRightTabCLUserCtrl.Dock = DockStyle.Fill;
                        main_table_layout.Controls.Add(liveRightTabCLUserCtrl, 65, 2);
                        main_table_layout.SetColumnSpan(liveRightTabCLUserCtrl, 18);
                        main_table_layout.SetRowSpan(liveRightTabCLUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 0, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 65);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                        main_start_index = 0;
                        main_end_index = 2;
                        main_width_index = 65;
                        main_height_index = 47;
                    }
                    else if (lastView.leftTabSelected == "Tracking")
                    {
                        liveRightTabTUserCtrl.Dock = DockStyle.Fill;
                        main_table_layout.Controls.Add(liveRightTabTUserCtrl, 71, 2);
                        main_table_layout.SetColumnSpan(liveRightTabTUserCtrl, 12);
                        main_table_layout.SetRowSpan(liveRightTabTUserCtrl, 47);
                        main_table_layout.Controls.Add(liveMainUserCtrl, 0, 2);
                        main_table_layout.SetColumnSpan(liveMainUserCtrl, 71);
                        main_table_layout.SetRowSpan(liveMainUserCtrl, 47);
                        main_start_index = 0;
                        main_end_index = 2;
                        main_width_index = 71;
                        main_height_index = 47;
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
                        main_start_index = 16;
                        main_end_index = 2;
                        main_width_index = 49;
                        main_height_index = 47;
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
                        main_start_index = 16;
                        main_end_index = 2;
                        main_width_index = 55;
                        main_height_index = 47;
                    }

                }
            }
        }

        private void openLayoutSetting(object? sender, EventArgs e)
        {
            if (!isOpenLayoutSetting)
            {
                setting_layout_panel.Invalidate();
                Point rightMostPoint = GetCellLocation(main_table_layout, 65, 2);
                Point leftMostPoint = new Point((int)(liveHeaderUserCtrl.Location.X + liveHeaderUserCtrl.Width * 0.49), rightMostPoint.Y + 6);
                int width = rightMostPoint.X - leftMostPoint.X - 15;
                setting_layout_panel.Location = leftMostPoint;
                setting_layout_panel.Size = new Size(width, (int)(width * 1.1));
                setting_layout_panel.Visible = true;
                setting_layout_panel.BringToFront();
                isOpenLayoutSetting = true;
                setting_layout_result_label.Size = new Size(setting_layout_panel.Width - 6, (setting_layout_panel.Width - 6)/10);
                setting_layout_result_label.Dock = DockStyle.Top;
                setting_layout_result_label.BackColor = Color.FromArgb(100, 100, 100);
                setting_layout_result_label.TextAlign = ContentAlignment.MiddleLeft;
                setting_layout_result_label.ForeColor = Color.White;
                setting_layout_result_label.Padding = new Padding(5, 0, 0, 0);
                setting_layout_result_label.Text = "Chọn ô";
                setting_layout_panel.Padding = new Padding(3);
                setting_table_layout.BackColor = Color.FromArgb(232, 232, 232);
                setting_table_layout.Width = setting_layout_panel.Width - 6;
                setting_table_layout.Height = setting_layout_panel.Width - 6;
                setting_table_layout.Dock = DockStyle.Top;
                setting_table_layout.ColumnCount = 10;
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                setting_table_layout.RowCount = 10;
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                setting_table_layout.Paint += settingTableLayoutPaint;
                setting_table_layout.MouseMove += settingTableLayoutMouseMove;
                setting_table_layout.MouseLeave += settingTableLayoutMouseLeave;
                setting_layout_panel.Controls.Add(setting_layout_result_label);
                setting_layout_panel.Controls.Add(setting_table_layout);
            } else
            {
                setting_layout_panel.Controls.Clear();
                setting_layout_panel.Visible = false;
                isOpenLayoutSetting = false;
            }
            
        }

        private void settingTableLayoutMouseLeave(object? sender, EventArgs e)
        {
            setting_layout_result_label.Text = "Chọn Ô";
            hoverRowEnd = 0;
            hoverColumnEnd = 0;
            setting_table_layout.Invalidate();
            isChooseLayout = false;
        }

        private void settingTableLayoutMouseMove(object? sender, MouseEventArgs e)
        {
            TableLayoutPanel setting_table_layout = sender as TableLayoutPanel;
            int mouseX = e.X;
            int mouseY = e.Y;

            int cellWidth = setting_table_layout.Width / setting_table_layout.ColumnCount;
            int cellHeight = setting_table_layout.Height / setting_table_layout.RowCount;


            int currentColumn = mouseX / cellWidth;
            int currentRow = mouseY / cellHeight;

            int rowCount = currentRow - startRow + 1;
            int columnCount = startColumn - currentColumn + 1;
            setting_layout_result_label.Text = $"{columnCount} x {rowCount} Ô";

            hoverRowEnd = currentRow;
            hoverColumnEnd = currentColumn;
            isChooseLayout = true;
            if (currentRow != previousRow || currentColumn != previousColumn)
            {
                previousRow = currentRow;
                previousColumn = currentColumn;
                setting_table_layout.Invalidate();
            }
        }

        private void settingTableLayoutPaint(object? sender, PaintEventArgs e)
        {
            TableLayoutPanel tableLayoutPanel = sender as TableLayoutPanel;
            if (tableLayoutPanel == null) return;

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White);

            int cellWidth = tableLayoutPanel.ClientSize.Width / tableLayoutPanel.ColumnCount;
            int cellHeight = tableLayoutPanel.ClientSize.Height / tableLayoutPanel.RowCount;

            for (int i = 0; i <= tableLayoutPanel.RowCount; i++)
            {
                g.DrawLine(pen, 0, i * cellHeight, tableLayoutPanel.ClientSize.Width, i * cellHeight);
            }

            for (int j = 0; j <= tableLayoutPanel.ColumnCount; j++)
            {
                g.DrawLine(pen, j * cellWidth, 0, j * cellWidth, tableLayoutPanel.ClientSize.Height);
            }

            if (isChooseLayout)
            {
                using (Pen hoverPen = new Pen(Color.Red))
                {
                    for (int row = startRow; row <= hoverRowEnd; row++)
                    {
                        for (int col = hoverColumnEnd; col <= startColumn; col++)
                        {
                            Rectangle cellRect = new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight);
                            e.Graphics.DrawRectangle(hoverPen, cellRect);
                        }
                    }
                }
            }
        }

        private void settingLayoutAfterSelectSize(object? sender, EventArgs e)
        {
            LiveMainUserCtrl liveMainUserCtrlResize = new LiveMainUserCtrl();
            liveMainUserCtrlResize.leftTabClickEvent += leftTabButtonClick;
            liveMainUserCtrlResize.rightTabClickEvent += rightTabButtonClick;
            liveMainUserCtrlResize.Dock = DockStyle.Fill;
            main_table_layout.Controls.Remove(liveMainUserCtrl);
            main_table_layout.Controls.Add(liveMainUserCtrlResize, main_start_index, main_end_index);
            main_table_layout.SetColumnSpan(liveMainUserCtrlResize, main_width_index);
            main_table_layout.SetRowSpan(liveMainUserCtrlResize, main_height_index);
            liveMainUserCtrl = liveMainUserCtrlResize;
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

        private Point GetCellLocation(TableLayoutPanel tableLayoutPanel, int column, int row)
        {
            // Bắt đầu tọa độ từ góc trên cùng trái của TableLayoutPanel
            int x = tableLayoutPanel.Location.X;
            int y = tableLayoutPanel.Location.Y;

            // Tính toán tổng chiều rộng của các cột trước ô cần tìm
            for (int i = 0; i < column; i++)
            {
                x += tableLayoutPanel.GetColumnWidths()[i];
            }

            // Tính toán tổng chiều cao của các hàng trước ô cần tìm
            for (int i = 0; i < row; i++)
            {
                y += tableLayoutPanel.GetRowHeights()[i];
            }

            return new Point(x, y);
        }

        private void resize(object sender, EventArgs e)
        {
            if (isOpenLayoutSetting)
            {
                openLayoutSetting(this, EventArgs.Empty);
            }
        }
    }
}
