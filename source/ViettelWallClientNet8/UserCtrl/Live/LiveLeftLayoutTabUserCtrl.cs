using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Service.Setting;

namespace ViettelWallClientNet8.UserCtrl.Live
{
    public partial class LiveLeftLayoutTabUserCtrl : UserControl
    {
        private float original_width;
        private float original_height;
        private bool isShiftKeyPress;
        //interface
        private readonly ISettingLayoutService _settingLayoutService;
        //list layout expand
        private List<bool> isExpandList = new List<bool>();
        public LiveLeftLayoutTabUserCtrl()
        {
            _settingLayoutService = new SettingLayoutService();
            updateIsExpandList();
            InitializeComponent();
        }

        private void updateIsExpandList()
        {
            throw new NotImplementedException();
        }

        private void load(object sender, EventArgs e)
        {

        }

        private void keydown(object sender, KeyEventArgs e)
        {

        }

        private void keyup(object sender, KeyEventArgs e)
        {

        }

        private void resize(object sender, EventArgs e)
        {

        }
    }
}
