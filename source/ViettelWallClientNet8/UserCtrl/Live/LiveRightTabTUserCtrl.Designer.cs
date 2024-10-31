namespace ViettelWallClientNet8.UserCtrl.Live
{
    partial class LiveRightTabTUserCtrl
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
            scrollable_panel = new Panel();
            live_right_tab_t_flow_layout_panel = new FlowLayoutPanel();
            scrollable_panel.SuspendLayout();
            SuspendLayout();
            // 
            // scrollable_panel
            // 
            scrollable_panel.BackColor = Color.FromArgb(64, 64, 64);
            scrollable_panel.Controls.Add(live_right_tab_t_flow_layout_panel);
            scrollable_panel.Dock = DockStyle.Fill;
            scrollable_panel.Location = new Point(0, 0);
            scrollable_panel.Margin = new Padding(0);
            scrollable_panel.Name = "scrollable_panel";
            scrollable_panel.Size = new Size(180, 705);
            scrollable_panel.TabIndex = 0;
            scrollable_panel.AutoScroll = true;
            // 
            // live_right_tab_t_flow_layout_panel
            // 
            live_right_tab_t_flow_layout_panel.Dock = DockStyle.Fill;
            live_right_tab_t_flow_layout_panel.FlowDirection = FlowDirection.TopDown;
            live_right_tab_t_flow_layout_panel.Location = new Point(0, 0);
            live_right_tab_t_flow_layout_panel.Margin = new Padding(0);
            live_right_tab_t_flow_layout_panel.Name = "live_right_tab_t_flow_layout_panel";
            live_right_tab_t_flow_layout_panel.TabIndex = 0;
            live_right_tab_t_flow_layout_panel.WrapContents = false;
            // 
            // LiveRightTabTUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(scrollable_panel);
            Margin = new Padding(0);
            Name = "LiveRightTabTUserCtrl";
            Size = new Size(180, 705);
            scrollable_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel scrollable_panel;
        private FlowLayoutPanel live_right_tab_t_flow_layout_panel;
    }
}
