using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using ViettelWallClientNet8.Interface.Setting;
using ViettelWallClientNet8.Model.Camera;
using ViettelWallClientNet8.Model.Setting;
using static System.Windows.Forms.LinkLabel;

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

        public List<SettingLayout>? getAllSettingLayout(bool isCreateNewLayoutRecent, string search)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    if (isCreateNewLayoutRecent)
                    {
                        List<SettingLayout> result = new List<SettingLayout>();
                        SettingLayout newLayout = data.Last();
                        result.Add(newLayout);
                        data.Remove(newLayout);
                        data.Sort((p1, p2) => string.Compare(p1.name, p2.name, StringComparison.OrdinalIgnoreCase));
                        result.AddRange(data);
                        return searchFunction(search, result);
                    } else
                    {
                        data.Sort((p1, p2) => string.Compare(p1.name, p2.name, StringComparison.OrdinalIgnoreCase));
                        return searchFunction(search, data);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void addLayout(string name)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                SettingLayout newLayout = new SettingLayout()
                {
                    name = name,
                    height = 1,
                    width = 1,
                    isNowUse = false,
                    sharedBy = null,
                    listCameras = null
                };
                data.Add(newLayout);
                string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, updateJson);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<SettingLayout>? searchFunction(string search, List<SettingLayout> data)
        {
            if (string.IsNullOrEmpty(search))
            {
                return data;    
            } else
            {
                List<SettingLayout>? result = new List<SettingLayout>();
                foreach (var settingLayout in data)
                {
                    if (settingLayout.name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        result.Add(settingLayout);
                    }
                    else
                    {
                        if (settingLayout.listCameras != null)
                        {
                            List<CameraInLayout>? cameraInLayouts = settingLayout.listCameras.Where(p => p.cameraName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                            if (cameraInLayouts.Any())
                            {
                                settingLayout.listCameras.Clear();
                                settingLayout.listCameras.AddRange(cameraInLayouts);
                                result.Add(settingLayout);
                            }
                        }
                    }
                }
                return result;
            }
        }

        public void addCamera(string name, string link, int index)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    data.FirstOrDefault(x => x.isNowUse).listCameras.Add(new CameraInLayout
                    {
                        cameraIndex = index,
                        cameraLink = link,
                        cameraName = name,
                    });
                    string updateJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonFilePath, updateJson);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void removeCameras()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset", "Json", "settinglayout.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<SettingLayout>>(jsonData);
                if (data != null)
                {
                    data.FirstOrDefault(x => x.isNowUse).listCameras.Clear();
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
