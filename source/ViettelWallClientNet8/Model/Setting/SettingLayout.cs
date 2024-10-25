using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ViettelWallClientNet8.Model.Setting
{
    public class SettingLayout
    {
        public required string name { get; set; }
        public required int width { get; set; }
        public required int height { get; set; }
        public required bool isNowUse { get; set; }
    }
}
