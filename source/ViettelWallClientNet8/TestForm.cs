using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.UserCtrl.Live;

namespace ViettelWallClientNet8
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            this.Size = new Size(705, 705);
            var test = new LiveMainUserCtrl();
            test.Dock = DockStyle.Fill;
            this.Controls.Add(test);
            
        }
    }
}
