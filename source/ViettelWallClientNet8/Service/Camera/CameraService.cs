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

        public List<CameraGroup> getListCameraGroup()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            string jsonFilePath = Path.Combine(projectDirectory, "ApiResult", "cameragroup.json");
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var data = JsonSerializer.Deserialize<List<CameraGroup>>(jsonData);
                if (data != null)
                {
                    return data.ToList();
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
