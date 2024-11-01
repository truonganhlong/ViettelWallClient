using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.Custom
{
    public class LiveRightTabTBorderPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Thiết lập màu sắc và độ dày cho đường viền
            using (Pen pen = new Pen(Color.WhiteSmoke, ApplicationConst.border_thickness)) // Màu đen và độ dày 2
            {
                // Vẽ đường viền trên
                e.Graphics.DrawLine(pen, 0, 0, this.Width, 0); // Vẽ từ (0,0) đến (Width,0)

                // Vẽ đường viền trái
                e.Graphics.DrawLine(pen, 0, 0, 0, this.Height); // Vẽ từ (0,0) đến (0,Height)
            }
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            // Kích hoạt lại vẽ đường viền khi cuộn
            this.Invalidate(); // Vẽ lại để đảm bảo border không bị mất
            base.OnScroll(se);
        }
    }
}
