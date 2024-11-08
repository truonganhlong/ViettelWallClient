using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    partial class LiveHeaderUserCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            header = new Panel();
            header_tlp = new TableLayoutPanel();
            panel_custom = new Panel();
            panel_5x5 = new Panel();
            panel_4x4 = new Panel();
            layout_label = new Label();
            remove_label = new Label();
            panel_1x1 = new Panel();
            panel_2x2 = new Panel();
            panel_3x3 = new Panel();
            header.SuspendLayout();
            header_tlp.SuspendLayout();
            SuspendLayout();
            // 
            // header
            // 
            header.Controls.Add(header_tlp);
            header.Dock = DockStyle.Fill;
            header.Location = new Point(0, 0);
            header.Margin = new Padding(0);
            header.Name = "header";
            header.Size = new Size(1005, 30);
            header.TabIndex = 0;
            header.Resize += resize;
            // 
            // header_tlp
            // 
            header_tlp.ColumnCount = 10;
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            header_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            header_tlp.Controls.Add(panel_custom, 7, 0);
            header_tlp.Controls.Add(panel_5x5, 6, 0);
            header_tlp.Controls.Add(panel_4x4, 5, 0);
            header_tlp.Controls.Add(layout_label, 0, 0);
            header_tlp.Controls.Add(remove_label, 9, 0);
            header_tlp.Controls.Add(panel_1x1, 2, 0);
            header_tlp.Controls.Add(panel_2x2, 3, 0);
            header_tlp.Controls.Add(panel_3x3, 4, 0);
            header_tlp.Dock = DockStyle.Fill;
            header_tlp.Location = new Point(0, 0);
            header_tlp.Margin = new Padding(0);
            header_tlp.Name = "header_tlp";
            header_tlp.RowCount = 1;
            header_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            header_tlp.Size = new Size(1005, 30);
            header_tlp.TabIndex = 0;
            // 
            // panel_custom
            // 
            panel_custom.Dock = DockStyle.Fill;
            panel_custom.Location = new Point(650, 0);
            panel_custom.Margin = new Padding(0);
            panel_custom.Name = "panel_custom";
            panel_custom.Size = new Size(100, 30);
            panel_custom.TabIndex = 7;
            // 
            // panel_5x5
            // 
            panel_5x5.Dock = DockStyle.Fill;
            panel_5x5.Location = new Point(550, 0);
            panel_5x5.Margin = new Padding(0);
            panel_5x5.Name = "panel_5x5";
            panel_5x5.Size = new Size(100, 30);
            panel_5x5.TabIndex = 6;
            panel_5x5.Click += panel_5x5_click;
            // 
            // panel_4x4
            // 
            panel_4x4.Dock = DockStyle.Fill;
            panel_4x4.Location = new Point(450, 0);
            panel_4x4.Margin = new Padding(0);
            panel_4x4.Name = "panel_4x4";
            panel_4x4.Size = new Size(100, 30);
            panel_4x4.TabIndex = 5;
            panel_4x4.Click += panel_4x4_click;
            // 
            // layout_label
            // 
            layout_label.AutoEllipsis = true;
            header_tlp.SetColumnSpan(layout_label, 2);
            layout_label.Dock = DockStyle.Fill;
            layout_label.ForeColor = Color.White;
            layout_label.Image = Properties.Resources.layout_icon;
            layout_label.ImageAlign = ContentAlignment.MiddleLeft;
            layout_label.Location = new Point(0, 0);
            layout_label.Margin = new Padding(0);
            layout_label.Name = "layout_label";
            layout_label.Padding = new Padding(20, 0, 0, 0);
            layout_label.Size = new Size(150, 30);
            layout_label.TabIndex = 0;
            layout_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // remove_label
            // 
            remove_label.Dock = DockStyle.Fill;
            remove_label.ForeColor = Color.White;
            remove_label.Image = Properties.Resources.broom_icon;
            remove_label.ImageAlign = ContentAlignment.MiddleLeft;
            remove_label.Location = new Point(900, 0);
            remove_label.Margin = new Padding(0);
            remove_label.Name = "remove_label";
            remove_label.Size = new Size(105, 30);
            remove_label.TabIndex = 1;
            remove_label.Text = "Xóa hết";
            remove_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_1x1
            // 
            panel_1x1.Dock = DockStyle.Fill;
            panel_1x1.Location = new Point(150, 0);
            panel_1x1.Margin = new Padding(0);
            panel_1x1.Name = "panel_1x1";
            panel_1x1.Size = new Size(100, 30);
            panel_1x1.TabIndex = 2;
            panel_1x1.Click += panel_1x1_click;
            // 
            // panel_2x2
            // 
            panel_2x2.Dock = DockStyle.Fill;
            panel_2x2.Location = new Point(250, 0);
            panel_2x2.Margin = new Padding(0);
            panel_2x2.Name = "panel_2x2";
            panel_2x2.Size = new Size(100, 30);
            panel_2x2.TabIndex = 3;
            panel_2x2.Click += panel_2x2_click;
            // 
            // panel_3x3
            // 
            panel_3x3.Dock = DockStyle.Fill;
            panel_3x3.Location = new Point(350, 0);
            panel_3x3.Margin = new Padding(0);
            panel_3x3.Name = "panel_3x3";
            panel_3x3.Size = new Size(100, 30);
            panel_3x3.TabIndex = 4;
            panel_3x3.Click += panel_3x3_click;
            // 
            // LiveHeaderUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(header);
            Margin = new Padding(0);
            Name = "LiveHeaderUserCtrl";
            Size = new Size(1005, 30);
            header.ResumeLayout(false);
            header_tlp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel header;
        private TableLayoutPanel header_tlp;
        private Label layout_label;
        private Label remove_label;
        private Panel panel_1x1;
        private Panel panel_custom;
        private Panel panel_5x5;
        private Panel panel_4x4;
        private Panel panel_2x2;
        private Panel panel_3x3;
    }
}
