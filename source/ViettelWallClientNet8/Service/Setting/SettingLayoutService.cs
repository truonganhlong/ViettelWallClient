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
    public class SettingLayoutService : ISettingLayoutService
    {
        //NOTE: đầu tiên không nên có 2 file json setting, khi ứng dụng khởi đầu chạy lần đầu tiên hẵng tạo (test sau), từ đó các đoạn code if bên dưới sẽ thêm else là khởi tạo file 
        public SettingLastView? getLastViewSetting()
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData =  File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SettingLayout? getLayoutSetting()
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    return data.First(x => x.isNowUse);
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
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                if (data != null)
                {
                    data.isLeftTabVisible = !data.isLeftTabVisible;
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
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                if (data != null)
                {
                    data.isRightTabVisible = !data.isRightTabVisible;
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void updateMainTabLocation(string location)
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                if (data != null) {
                    switch (location)
                    {
                        case "Live":
                            data.mainTabSelected = "Live";
                            break;
                        case "Replay":
                            data.mainTabSelected = "Replay";
                            break;
                        case "Tracking":
                            data.mainTabSelected = "Tracking";
                            break;
                        default:
                            break;
                    }
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void updateLeftTabLocation(string location)
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                if (data != null)
                {
                    switch (location)
                    {
                        case "Camera":
                            data.leftTabSelected = "Camera";
                            break;
                        case "Layout":
                            data.leftTabSelected = "Layout";
                            break;
                        case "Tracking":
                            data.leftTabSelected = "Tracking";
                            break;
                        case "CameraList":
                            data.leftTabSelected = "CameraList";
                            break;
                        case "EventFilter":
                            data.leftTabSelected = "EventFilter";
                            break;
                        default:
                            break;
                    }
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void updateRightTabLocation(string location)
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                if (data != null)
                {
                    switch (location)
                    {
                        case "All":
                            data.rightTabSelected = "All";
                            break;
                        case "Security":
                            data.rightTabSelected = "Security";
                            break;
                        case "Person":
                            data.rightTabSelected = "Person";
                            break;
                        case "Transportation":
                            data.rightTabSelected = "Transportation";
                            break;
                        case "Traffic":
                            data.rightTabSelected = "Traffic";
                            break;
                        default:
                            break;
                    }
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void updateIsFullScreen()
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglastview.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<SettingLastView>(jsonData);
                if (data != null)
                {
                    data.isFullScreen = !data.isFullScreen;
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void updateLayoutSize(int width, int height)
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    data.First(x => x.isNowUse).width = width;
                    data.First(x => x.isNowUse).height = height;
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<SettingLayout>? getAllSettingLayout()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    return data;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
