using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Custom;
using ViettelWallClientNet8.UserCtrl.Live;
using ViettelWallClientNet8.UserCtrl.Main;

namespace ViettelWallClientNet8
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            this.MaximumSize = new Size(200, 40);
            this.Size = new Size(200, 40);
            var test = new LiveHeaderUserCtrl();
            test.Dock = DockStyle.Fill;
            this.Controls.Add(test);
            
        }
    }
}
