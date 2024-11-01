using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Util.Const;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveHeaderUserCtrl : UserControl
    {

        private Color border_color = Color.WhiteSmoke;
        public LiveHeaderUserCtrl()
        {
            InitializeComponent();
        }

        //private void headerBorderPaint(object sender, PaintEventArgs e)
        //{
        //    //e.Graphics.Clear(header.BackColor);
        //    //using (Pen pen = new Pen(border_color, ApplicationConst.border_thickness))
        //    //{
        //    //    e.Graphics.DrawLine(pen, 0, header.Height - 1, header.Width, header.Height - 1); // Vẽ từ (0,0) đến (Width,0)
        //    //}
        //}
    }
}
