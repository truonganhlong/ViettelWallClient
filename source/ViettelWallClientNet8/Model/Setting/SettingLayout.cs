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

        //public static SettingLayout? getLayoutSetting() {
        //    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
        //    string jsonFilePath = Path.Combine(projectDirectory, "Asset", "Json", "settinglayout.json");
        //    try
        //    {
        //        var jsonData = File.ReadAllText(jsonFilePath);
        //        var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
        //        if(data != null)
        //        {
        //            return data.FirstOrDefault(x => x.isNowUse);
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
