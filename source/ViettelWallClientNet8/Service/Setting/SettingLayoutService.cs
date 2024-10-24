using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Model.Setting;

namespace ViettelWallClientNet8.Service.Setting
{
    public class SettingLayoutService : ISettingLayoutServicce
    {
        public SettingLayout? getLayoutSetting()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(projectDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    return data.FirstOrDefault(x => x.isNowUse);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void updateIsLeftTabVisible()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(projectDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    data.First(x => x.isNowUse).isLeftTabVisible = !data.First(x => x.isNowUse).isLeftTabVisible;
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void updateIsRightTabVisible()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(projectDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    data.First(x => x.isNowUse).isRightTabVisible = !data.First(x => x.isNowUse).isRightTabVisible;
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
