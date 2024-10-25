namespace ViettelWallClientNet8.UserCtrl.Live
{
    partial class LiveMainUserCtrl
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
            main_panel = new Panel();
            main_table_layout_panel = new TableLayoutPanel();
            left_tab_button = new Button();
            right_tab_button = new Button();
            main_panel.SuspendLayout();
            SuspendLayout();
            // 
            // main_panel
            // 
            main_panel.Controls.Add(main_table_layout_panel);
            main_panel.Controls.Add(left_tab_button);
            main_panel.Controls.Add(right_tab_button);
            main_panel.Dock = DockStyle.Fill;
            main_panel.Location = new Point(0, 0);
            main_panel.Margin = new Padding(0);
            main_panel.Name = "main_panel";
            main_panel.Size = new Size(1005, 705);
            main_panel.TabIndex = 0;
            // 
            // main_table_layout_panel
            // 
            main_table_layout_panel.Dock = DockStyle.Fill;
            main_table_layout_panel.Location = new Point(0, 0);
            main_table_layout_panel.Name = "main_table_layout_panel";
            main_table_layout_panel.Size = new Size(1005, 705);
            main_table_layout_panel.TabIndex = 0;
            // 
            // left_tab_button
            // 
            left_tab_button.Anchor = AnchorStyles.Left;
            left_tab_button.BackColor = Color.FromArgb(227, 225, 231);
            left_tab_button.FlatAppearance.BorderSize = 0;
            left_tab_button.FlatStyle = FlatStyle.Flat;
            left_tab_button.Font = new Font("Arial", 10F, FontStyle.Bold);
            left_tab_button.ForeColor = Color.Red;
            left_tab_button.Location = new Point(0, 705);
            left_tab_button.Margin = new Padding(0);
            left_tab_button.Name = "left_tab_button";
            left_tab_button.Size = new Size(12, 60);
            left_tab_button.TabIndex = 0;
            left_tab_button.Text = "<";
            left_tab_button.UseVisualStyleBackColor = false;
            left_tab_button.Click += leftTabButtonClick;
            // 
            // right_tab_button
            // 
            right_tab_button.Anchor = AnchorStyles.Right;
            right_tab_button.BackColor = Color.FromArgb(227, 225, 231);
            right_tab_button.FlatAppearance.BorderSize = 0;
            right_tab_button.FlatStyle = FlatStyle.Flat;
            right_tab_button.Font = new Font("Arial", 10F, FontStyle.Bold);
            right_tab_button.ForeColor = Color.Red;
            right_tab_button.Location = new Point(1005, 705);
            right_tab_button.Margin = new Padding(0);
            right_tab_button.Name = "right_tab_button";
            right_tab_button.Size = new Size(12, 60);
            right_tab_button.TabIndex = 0;
            right_tab_button.Text = "<";
            right_tab_button.UseVisualStyleBackColor = false;
            right_tab_button.Click += rightTabButtonClick;
            // 
            // LiveMainUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(main_panel);
            Margin = new Padding(0);
            Name = "LiveMainUserCtrl";
            Size = new Size(1005, 705);
            main_panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel main_panel;
        private TableLayoutPanel main_table_layout_panel;
        private Button left_tab_button;
        private Button right_tab_button;
    }
}
