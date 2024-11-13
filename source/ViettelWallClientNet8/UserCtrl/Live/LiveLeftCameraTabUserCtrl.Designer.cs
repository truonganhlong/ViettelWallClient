namespace ViettelWallClientNet8.UserCtrl.Live
{
    partial class LiveLeftCameraTabUserCtrl
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
            live_left_camera_tlp = new TableLayoutPanel();
            main_content_panel = new Panel();
            live_left_camera_flp = new FlowLayoutPanel();
            top_content = new Panel();
            live_left_camera_tlp.SuspendLayout();
            main_content_panel.SuspendLayout();
            SuspendLayout();
            // 
            // live_left_camera_tlp
            // 
            live_left_camera_tlp.ColumnCount = 1;
            live_left_camera_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            live_left_camera_tlp.Controls.Add(main_content_panel, 0, 1);
            live_left_camera_tlp.Controls.Add(top_content, 0, 0);
            live_left_camera_tlp.Dock = DockStyle.Fill;
            live_left_camera_tlp.Location = new Point(0, 0);
            live_left_camera_tlp.Margin = new Padding(0);
            live_left_camera_tlp.Name = "live_left_camera_tlp";
            live_left_camera_tlp.RowCount = 9;
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_camera_tlp.Size = new Size(238, 704);
            live_left_camera_tlp.TabIndex = 0;
            // 
            // main_content_panel
            // 
            main_content_panel.AutoScroll = true;
            main_content_panel.Controls.Add(live_left_camera_flp);
            main_content_panel.Dock = DockStyle.Fill;
            main_content_panel.Location = new Point(0, 78);
            main_content_panel.Margin = new Padding(0);
            main_content_panel.Name = "main_content_panel";
            main_content_panel.Padding = new Padding(1);
            live_left_camera_tlp.SetRowSpan(main_content_panel, 8);
            main_content_panel.Size = new Size(238, 626);
            main_content_panel.TabIndex = 0;
            // 
            // live_left_camera_flp
            // 
            live_left_camera_flp.FlowDirection = FlowDirection.TopDown;
            live_left_camera_flp.Location = new Point(1, 1);
            live_left_camera_flp.Margin = new Padding(0);
            live_left_camera_flp.Name = "live_left_camera_flp";
            live_left_camera_flp.Padding = new Padding(10, 0, 10, 0);
            live_left_camera_flp.Size = new Size(236, 100);
            live_left_camera_flp.TabIndex = 0;
            live_left_camera_flp.WrapContents = false;
            // 
            // top_content
            // 
            top_content.Dock = DockStyle.Fill;
            top_content.Location = new Point(1, 1);
            top_content.Margin = new Padding(1);
            top_content.Name = "top_content";
            top_content.Padding = new Padding(10, 0, 10, 0);
            top_content.Size = new Size(236, 76);
            top_content.TabIndex = 1;
            // 
            // LiveLeftCameraTabUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(live_left_camera_tlp);
            Margin = new Padding(0);
            Name = "LiveLeftCameraTabUserCtrl";
            Size = new Size(238, 704);
            Load += load;
            KeyDown += keydown;
            KeyUp += keyup;
            Resize += resize;
            live_left_camera_tlp.ResumeLayout(false);
            main_content_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel live_left_camera_tlp;
        private Panel main_content_panel;
        private FlowLayoutPanel live_left_camera_flp;
        private Panel top_content;
    }
}
