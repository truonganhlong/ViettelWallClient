using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViettelWallClientNet8.Model.Camera;

namespace ViettelWallClientNet8.Interface.Camera
{
    public interface ICameraService
    {
        List<CameraGroup> getListCameraGroup(string search);
    }
}
