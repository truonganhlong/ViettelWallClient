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
            SuspendLayout();
            // 
            // header
            // 
            header.Dock = DockStyle.Fill;
            header.Location = new Point(300, 0);
            header.Margin = new Padding(0);
            header.Name = "header";
            header.Size = new Size(1005, 30);
            header.TabIndex = 0;
            // 
            // LiveHeaderUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(header);
            Margin = new Padding(0);
            Name = "LiveHeaderUserCtrl";
            Size = new Size(1005, 30);
            ResumeLayout(false);
        }

        #endregion

        private Panel header;
    }
}
