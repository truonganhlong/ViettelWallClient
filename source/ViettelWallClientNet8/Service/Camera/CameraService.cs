using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViettelWallClientNet8.Interface.Camera;
using ViettelWallClientNet8.Model.Camera;

namespace ViettelWallClientNet8.Service.Camera
{
    public class CameraService : ICameraService
    {

        public List<CameraGroup> getListCameraGroup(string search)
        {
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApiResult", "cameragroup.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<CameraGroup>>(jsonData);
                if (data != null)
                {
                    data.Sort((p1, p2) => string.Compare(p1.groupName, p2.groupName, StringComparison.OrdinalIgnoreCase));
                    return searchFunction(search, data);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<CameraGroup>? searchFunction(string search, List<CameraGroup> data)
        {
            if (string.IsNullOrEmpty(search))
            {
                return data;
            }
            else
            {
                List<CameraGroup>? result = new List<CameraGroup>();
                foreach (var cameraGroup in data)
                {
                    if (cameraGroup.groupName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        result.Add(cameraGroup);
                    }
                    else
                    {
                        if (cameraGroup.listCameras != null)
                        {
                            List<Model.Camera.Camera>? camera = cameraGroup.listCameras.Where(p => p.cameraName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                            if (camera.Any())
                            {
                                cameraGroup.listCameras.Clear();
                                cameraGroup.listCameras.AddRange(camera);
                                result.Add(cameraGroup);
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}
