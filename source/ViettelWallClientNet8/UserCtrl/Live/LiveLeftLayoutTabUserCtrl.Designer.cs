using System.Drawing;
using System.Windows.Forms;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    partial class LiveLeftLayoutTabUserCtrl
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
            live_left_layout_tlp = new TableLayoutPanel();
            main_content_panel = new Panel();
            live_left_layout_flp = new FlowLayoutPanel();
            top_content = new Panel();
            live_left_layout_tlp.SuspendLayout();
            main_content_panel.SuspendLayout();
            SuspendLayout();
            // 
            // live_left_layout_tlp
            // 
            live_left_layout_tlp.ColumnCount = 1;
            live_left_layout_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            live_left_layout_tlp.Controls.Add(main_content_panel, 0, 1);
            live_left_layout_tlp.Controls.Add(top_content, 0, 0);
            live_left_layout_tlp.Dock = DockStyle.Fill;
            live_left_layout_tlp.Location = new Point(0, 0);
            live_left_layout_tlp.Margin = new Padding(0);
            live_left_layout_tlp.Name = "live_left_layout_tlp";
            live_left_layout_tlp.RowCount = 9;
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 12.4F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 9.8F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));
            live_left_layout_tlp.Size = new Size(238, 704);
            live_left_layout_tlp.TabIndex = 0;
            // 
            // main_content_panel
            // 
            main_content_panel.AutoScroll = true;
            main_content_panel.Controls.Add(live_left_layout_flp);
            main_content_panel.Dock = DockStyle.Fill;
            main_content_panel.Location = new Point(0, 87);
            main_content_panel.Margin = new Padding(0);
            main_content_panel.Name = "main_content_panel";
            main_content_panel.Padding = new Padding(1);
            live_left_layout_tlp.SetRowSpan(main_content_panel, 8);
            main_content_panel.Size = new Size(238, 617);
            main_content_panel.TabIndex = 0;
            // 
            // live_left_layout_flp
            // 
            live_left_layout_flp.FlowDirection = FlowDirection.TopDown;
            live_left_layout_flp.Location = new Point(1, 1);
            live_left_layout_flp.Margin = new Padding(0);
            live_left_layout_flp.Name = "live_left_layout_flp";
            live_left_layout_flp.Padding = new Padding(3, 0, 3, 0);
            live_left_layout_flp.Size = new Size(236, 100);
            live_left_layout_flp.TabIndex = 0;
            live_left_layout_flp.WrapContents = false;
            // 
            // top_content
            // 
            top_content.Dock = DockStyle.Fill;
            top_content.Location = new Point(1, 1);
            top_content.Margin = new Padding(1);
            top_content.Name = "top_content";
            top_content.Padding = new Padding(3, 0, 3, 0);
            top_content.Size = new Size(236, 85);
            top_content.TabIndex = 1;
            // 
            // LiveLeftLayoutTabUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(live_left_layout_tlp);
            Margin = new Padding(0);
            Name = "LiveLeftLayoutTabUserCtrl";
            Size = new Size(238, 704);
            Load += load;
            KeyDown += keydown;
            KeyUp += keyup;
            Resize += resize;
            live_left_layout_tlp.ResumeLayout(false);
            main_content_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel live_left_layout_tlp;
        private Panel main_content_panel;
        private FlowLayoutPanel live_left_layout_flp;
        private Panel top_content;
    }
}
