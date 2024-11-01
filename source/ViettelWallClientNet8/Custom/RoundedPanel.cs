using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViettelWallClientNet8.Custom
{
    public class RoundedPanel : Panel
    {
        private int borderRadius = 10; // Thiết lập bán kính bo góc mặc định

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate(); // Vẽ lại Panel khi thay đổi BorderRadius
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Tạo đường viền bo góc
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            // Đặt đường viền làm vùng cắt của Panel
            this.Region = new Region(path);

            // Vẽ viền nếu cần thiết
            using (Pen pen = new Pen(Color.Black, 1)) // Đặt màu và độ dày đường viền
            {
                graphics.DrawPath(pen, path);
            }
        }
    }
}
