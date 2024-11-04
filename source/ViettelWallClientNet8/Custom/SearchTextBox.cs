using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.Custom
{
    public class SearchTextBox : TextBox
    {
        public SearchTextBox()
        {
            this.BorderStyle = BorderStyle.None;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Vẽ border
            using (Pen pen = new Pen(Color.WhiteSmoke, 1))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        // Ghi đè phương thức OnHandleCreated để vẽ border khi Control đã được tạo
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Thiết lập thêm lớp để vẽ
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        // Vẽ border khi điều chỉnh kích thước
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); // Vẽ lại
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Không vẽ nền, chỉ để border nổi bật
        }
    }
}
