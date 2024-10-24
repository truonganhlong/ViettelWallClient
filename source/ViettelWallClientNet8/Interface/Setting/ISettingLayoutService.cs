using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViettelWallClientNet8.Model.Setting;

namespace ViettelWallClientNet8.Interface.Setting
{
    public interface ISettingLayoutService
    {
        SettingLayout? getLayoutSetting();
        SettingLastView? getLastViewSetting();
        void updateIsLeftTabVisible();
        void updateIsRightTabVisible();
    }
}
