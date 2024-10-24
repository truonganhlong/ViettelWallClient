using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViettelWallClientNet8.Custom
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 20; // Bán kính bo góc

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Tạo hình chữ nhật với các góc bo tròn
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path); // Thiết lập hình dạng cho Button

            // Vẽ nền cho Button
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            // Vẽ chữ lên Button
            //TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, new Point(0, 0), this.ForeColor);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            // Thay đổi màu nền khi chuột vào
            this.BackColor = Color.LightCoral; // Ví dụ màu khi hover
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            // Đặt lại màu nền khi chuột rời khỏi nút
            this.BackColor = Color.LightBlue; // Màu nền ban đầu
            base.OnMouseLeave(e);
        }
    }
}
