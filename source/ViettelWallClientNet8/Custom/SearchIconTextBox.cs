using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.Custom
{
    public partial class SearchIconTextBox : UserControl
    {
        public int borderRadius = 10;
        private TextBox textBox;
        private PictureBox iconStart;
        private PictureBox iconEnd;
        public SearchIconTextBox()
        {
            InitializeComponent();
            iconStart = new PictureBox();
            iconStart.Size = new Size(16, 16);
            iconStart.SizeMode = PictureBoxSizeMode.AutoSize;
            iconStart.Image = Properties.Resources.search_icon;
            iconStart.Dock = DockStyle.Left;

            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Height = 25;
            textBox.MaxLength = 50;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Left;
            textBox.Width = this.Width - 20;
            textBox.Font = new Font(ApplicationConst.font_family_name, 10);
            textBox.ForeColor = Color.White;
            textBox.Text = "Nhập tên camera...";
            textBox.BackColor = Color.FromArgb(64, 64, 64);
            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == "Nhập tên camera...")
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.White;
                }
            };
            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Nhập tên camera...";
                    textBox.ForeColor = Color.White;
                }
            };
            textBox.TextChanged += textChanged;

            iconEnd = new PictureBox();
            iconEnd.Size = new Size(16, 16);
            iconEnd.Anchor = AnchorStyles.Right;
            iconEnd.SizeMode = PictureBoxSizeMode.AutoSize;
            iconEnd.Image = Properties.Resources.delete_icon;
            iconEnd.Dock = DockStyle.Right;
            iconEnd.Click += iconEndClick;


            this.Controls.Add(iconEnd);
            this.Controls.Add(textBox);
            this.Controls.Add(iconStart);
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.Padding = new Padding(2);
            this.Size = new Size(200, 30);
            this.BackColor = Color.FromArgb(64, 64, 64);
            iconEnd.Visible = false;
        }

        private void iconEndClick(object? sender, EventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void textChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                iconEnd.Visible = true;
            }
            else
            {
                iconEnd.Visible = false;
            }
        }

        public Image IconStart
        {
            get { return iconStart.Image; }
            set { iconStart.Image = value; }
        }

    
        public Image IconEnd
        {
            get { return iconEnd.Image; }
            set { iconEnd.Image = value; }
        }

   
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using (var path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); 
                path.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90); 
                path.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90); 
                path.CloseAllFigures();

                g.SetClip(path);

                g.Clear(this.BackColor);

                using (Pen pen = new Pen(Color.White, ApplicationConst.border_thickness)) 
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    }
}
