namespace ViettelWallClientNet8.UserCtrl.Live
{
    partial class LiveLeftTabUserCtrl
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
            left_tab_control_panel = new TableLayoutPanel();
            camera_tab_panel = new Panel();
            camera_tab_label = new Label();
            layout_tab_panel = new Panel();
            layout_tab_label = new Label();
            tracking_tab_panel = new Panel();
            tracking_tab_label = new Label();
            left_tab_content = new Panel();
            left_tab_control_panel.SuspendLayout();
            camera_tab_panel.SuspendLayout();
            layout_tab_panel.SuspendLayout();
            tracking_tab_panel.SuspendLayout();
            SuspendLayout();
            // 
            // left_tab_control_panel
            // 
            left_tab_control_panel.BackColor = Color.FromArgb(64, 64, 64);
            left_tab_control_panel.ColumnCount = 3;
            left_tab_control_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            left_tab_control_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            left_tab_control_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            left_tab_control_panel.Controls.Add(camera_tab_panel, 0, 0);
            left_tab_control_panel.Controls.Add(layout_tab_panel, 1, 0);
            left_tab_control_panel.Controls.Add(tracking_tab_panel, 2, 0);
            left_tab_control_panel.Controls.Add(left_tab_content, 0, 1);
            left_tab_control_panel.Dock = DockStyle.Fill;
            left_tab_control_panel.Location = new Point(0, 0);
            left_tab_control_panel.Margin = new Padding(0);
            left_tab_control_panel.Name = "left_tab_control_panel";
            left_tab_control_panel.RowCount = 25;
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 4F));
            left_tab_control_panel.Size = new Size(240, 735);
            left_tab_control_panel.TabIndex = 2;
            left_tab_control_panel.Paint += leftTabControlPaintBorder;
            // 
            // camera_tab_panel
            // 
            camera_tab_panel.Controls.Add(camera_tab_label);
            camera_tab_panel.Dock = DockStyle.Fill;
            camera_tab_panel.Location = new Point(1, 1);
            camera_tab_panel.Margin = new Padding(1);
            camera_tab_panel.Name = "camera_tab_panel";
            camera_tab_panel.Size = new Size(78, 27);
            camera_tab_panel.TabIndex = 0;
            camera_tab_panel.Paint += cameraTabBorderPaint;
            // 
            // camera_tab_label
            // 
            camera_tab_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            camera_tab_label.ForeColor = Color.White;
            camera_tab_label.Location = new Point(0, 0);
            camera_tab_label.Margin = new Padding(1);
            camera_tab_label.Name = "camera_tab_label";
            camera_tab_label.Size = new Size(76, 25);
            camera_tab_label.TabIndex = 0;
            camera_tab_label.Text = "Cameras";
            camera_tab_label.TextAlign = ContentAlignment.MiddleCenter;
            camera_tab_label.Click += liveCameraLabelClick;
            // 
            // layout_tab_panel
            // 
            layout_tab_panel.Controls.Add(layout_tab_label);
            layout_tab_panel.Dock = DockStyle.Fill;
            layout_tab_panel.Location = new Point(81, 1);
            layout_tab_panel.Margin = new Padding(1);
            layout_tab_panel.Name = "layout_tab_panel";
            layout_tab_panel.Size = new Size(78, 27);
            layout_tab_panel.TabIndex = 1;
            layout_tab_panel.Paint += layoutTabBorderPaint;
            // 
            // layout_tab_label
            // 
            layout_tab_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            layout_tab_label.ForeColor = Color.White;
            layout_tab_label.Location = new Point(0, 0);
            layout_tab_label.Margin = new Padding(1);
            layout_tab_label.Name = "layout_tab_label";
            layout_tab_label.Size = new Size(76, 25);
            layout_tab_label.TabIndex = 0;
            layout_tab_label.Text = "Layouts";
            layout_tab_label.TextAlign = ContentAlignment.MiddleCenter;
            layout_tab_label.Click += liveLayoutLabelClick;
            // 
            // tracking_tab_panel
            // 
            tracking_tab_panel.Controls.Add(tracking_tab_label);
            tracking_tab_panel.Dock = DockStyle.Fill;
            tracking_tab_panel.Location = new Point(161, 1);
            tracking_tab_panel.Margin = new Padding(1);
            tracking_tab_panel.Name = "tracking_tab_panel";
            tracking_tab_panel.Size = new Size(78, 27);
            tracking_tab_panel.TabIndex = 2;
            tracking_tab_panel.Paint += trackingTabBorderPaint;
            // 
            // tracking_tab_label
            // 
            tracking_tab_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tracking_tab_label.ForeColor = Color.White;
            tracking_tab_label.Location = new Point(0, 0);
            tracking_tab_label.Margin = new Padding(1);
            tracking_tab_label.Name = "tracking_tab_label";
            tracking_tab_label.Size = new Size(76, 25);
            tracking_tab_label.TabIndex = 0;
            tracking_tab_label.Text = "Tracking";
            tracking_tab_label.TextAlign = ContentAlignment.MiddleCenter;
            tracking_tab_label.Click += liveTrackingLabelClick;
            // 
            // left_tab_content
            // 
            left_tab_control_panel.SetColumnSpan(left_tab_content, 3);
            left_tab_content.Dock = DockStyle.Fill;
            left_tab_content.Location = new Point(1, 30);
            left_tab_content.Margin = new Padding(1);
            left_tab_content.Name = "left_tab_content";
            left_tab_control_panel.SetRowSpan(left_tab_content, 24);
            left_tab_content.Size = new Size(238, 704);
            left_tab_content.TabIndex = 3;
            // 
            // LiveLeftTabUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(left_tab_control_panel);
            Margin = new Padding(0);
            Name = "LiveLeftTabUserCtrl";
            Size = new Size(240, 735);
            left_tab_control_panel.ResumeLayout(false);
            camera_tab_panel.ResumeLayout(false);
            layout_tab_panel.ResumeLayout(false);
            tracking_tab_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel left_tab_control_panel;
        private Panel tracking_tab_panel;
        private Panel camera_tab_panel;
        private Panel layout_tab_panel;
        private Label camera_tab_label;
        private Label layout_tab_label;
        private Label tracking_tab_label;
        private Panel left_tab_content;
    }
}
