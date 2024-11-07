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
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveHeaderUserCtrl : UserControl
    {
        private bool isPrivate = true;
        private Color border_color = Color.WhiteSmoke;
        // event handle
        public event EventHandler? panel1x1ClickEvent;
        public event EventHandler? panel2x2ClickEvent;
        public event EventHandler? panel3x3ClickEvent;
        public event EventHandler? panel4x4ClickEvent;
        public event EventHandler? panel5x5ClickEvent;
        //interface
        private readonly ISettingLayoutService _settingLayoutService;
        public LiveHeaderUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            InitializeComponent();
            InitializeAfter();
        }

        private void InitializeAfter()
        {
            SettingLayout? settingLayout = _settingLayoutService.getLayoutSetting();
            if (settingLayout != null)
            {
                string layoutName = settingLayout.name.ToString();
                if (settingLayout.name.Count() > 15)
                {
                    layoutName = settingLayout.name.Substring(0, 15) + "...";
                }
                layout_label.Text = layoutName;
            }

            if (isPrivate)
            {
                setupPanel1x1();
                setupPanel2x2();
                setupPanel3x3();
                setupPanel4x4();
                setupPanel5x5();
                setupPanelCustom();
            }
        }

        private void setupPanel1x1()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Width = header.Height;
            tableLayoutPanel.Height = header.Height;
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.BackColor = Color.FromArgb(170, 167, 167);
            tableLayoutPanel.ColumnCount = 1;
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowCount = 1;
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Paint += TableLayoutPanel_Paint;
            Label label = new Label();
            label.Dock = DockStyle.Left;
            label.Padding = new Padding(5, 0, 0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "1x1 Ô";
            label.ForeColor = Color.White;
            tableLayoutPanel.Click += panel_1x1_click;
            label.Click += panel_1x1_click;
            panel_1x1.Controls.Add(label);
            panel_1x1.Controls.Add(tableLayoutPanel);
        }

        private void setupPanel2x2()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Width = header.Height;
            tableLayoutPanel.Height = header.Height;
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.BackColor = Color.FromArgb(170, 167, 167);
            tableLayoutPanel.ColumnCount = 2;
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowCount = 2;
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Paint += TableLayoutPanel_Paint;
            Label label = new Label();
            label.Dock = DockStyle.Left;
            label.Padding = new Padding(5, 0, 0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "2x2 Ô";
            label.ForeColor = Color.White;
            tableLayoutPanel.Click += panel_2x2_click;
            label.Click += panel_2x2_click;
            panel_2x2.Controls.Add(label);
            panel_2x2.Controls.Add(tableLayoutPanel);
        }

        private void setupPanel3x3()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Width = header.Height;
            tableLayoutPanel.Height = header.Height;
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.BackColor = Color.FromArgb(170, 167, 167);
            tableLayoutPanel.ColumnCount = 3;
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            tableLayoutPanel.RowCount = 3;
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            tableLayoutPanel.Paint += TableLayoutPanel_Paint;
            Label label = new Label();
            label.Dock = DockStyle.Left;
            label.Padding = new Padding(5, 0, 0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "3x3 Ô";
            label.ForeColor = Color.White;
            tableLayoutPanel.Click += panel_3x3_click;
            label.Click += panel_3x3_click;
            panel_3x3.Controls.Add(label);
            panel_3x3.Controls.Add(tableLayoutPanel);
        }

        private void setupPanel4x4()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Width = header.Height;
            tableLayoutPanel.Height = header.Height;
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.BackColor = Color.FromArgb(170, 167, 167);
            tableLayoutPanel.ColumnCount = 4;
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowCount = 4;
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Paint += TableLayoutPanel_Paint;
            Label label = new Label();
            label.Dock = DockStyle.Left;
            label.Padding = new Padding(5, 0, 0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "4x4 Ô";
            label.ForeColor = Color.White;
            tableLayoutPanel.Click += panel_4x4_click;
            label.Click += panel_4x4_click;
            panel_4x4.Controls.Add(label);
            panel_4x4.Controls.Add(tableLayoutPanel);
        }

        private void setupPanel5x5()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Width = header.Height;
            tableLayoutPanel.Height = header.Height;
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.BackColor = Color.FromArgb(170, 167, 167);
            tableLayoutPanel.ColumnCount = 5;
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowCount = 5;
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.Paint += TableLayoutPanel_Paint;
            Label label = new Label();
            label.Dock = DockStyle.Left;
            label.Padding = new Padding(5, 0, 0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "5x5 Ô";
            label.ForeColor = Color.White;
            tableLayoutPanel.Click += panel_5x5_click;
            label.Click += panel_5x5_click;
            panel_5x5.Controls.Add(label);
            panel_5x5.Controls.Add(tableLayoutPanel);
        }

        private void setupPanelCustom()
        {
            Label label = new Label();
            label.Dock = DockStyle.Fill;
            label.Margin = new Padding(0);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = "Tùy chỉnh";
            label.ForeColor = Color.White;
            label.Image = Properties.Resources.setting_layout_icon;
            label.ImageAlign = ContentAlignment.MiddleLeft;
            label.Location = new Point(0, 0);
            panel_custom.Controls.Add(label);
        }
        private void TableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            TableLayoutPanel tableLayoutPanel = sender as TableLayoutPanel;
            if (tableLayoutPanel == null) return;

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(64, 64, 64));

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
        }

        private void resize(object sender, EventArgs e)
        {
            panel_1x1.Controls.Clear();
            panel_2x2.Controls.Clear();
            panel_3x3.Controls.Clear();
            panel_4x4.Controls.Clear();
            panel_5x5.Controls.Clear();
            panel_custom.Controls.Clear();
            InitializeAfter();
        }

        private void panel_1x1_click(object sender, EventArgs e)
        {
            _settingLayoutService.updateLayoutSize(1, 1);
            panel1x1ClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void panel_2x2_click(object sender, EventArgs e)
        {
            _settingLayoutService.updateLayoutSize(2, 2);
            panel2x2ClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void panel_3x3_click(object sender, EventArgs e)
        {
            _settingLayoutService.updateLayoutSize(3, 3);
            panel3x3ClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void panel_4x4_click(object sender, EventArgs e)
        {
            _settingLayoutService.updateLayoutSize(4, 4);
            panel4x4ClickEvent?.Invoke(this, EventArgs.Empty);
        }

        private void panel_5x5_click(object sender, EventArgs e)
        {
            _settingLayoutService.updateLayoutSize(5, 5);
            panel5x5ClickEvent?.Invoke(this, EventArgs.Empty);
        }

        //private void headerBorderPaint(object sender, PaintEventArgs e)
        //{
        //    //e.Graphics.Clear(header.BackColor);
        //    //using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
        //    //{
        //    //    e.Graphics.DrawLine(pen, 0, header.Height - 1, header.Width, header.Height - 1); // Vẽ từ (0,0) đến (Width,0)
        //    //}
        //}
    }
}
