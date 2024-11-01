using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViettelWallClientNet8.Model.Setting
{
    public class SettingLastView
    {
        public required string mainTabSelected { get; set; }
        public required bool isLeftTabVisible { get; set; }
        public required string? leftTabSelected { get; set; }
        public required bool isRightTabVisible { get; set; }
        public required string? rightTabSelected { get; set; }
        public required bool isFullScreen {  get; set; }    
    }
}
