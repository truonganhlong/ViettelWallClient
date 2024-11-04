using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViettelWallClientNet8.Model.Camera
{
    public class CameraGroup
    {
        public required string groupName {  get; set; }
        public required List<Camera> listCameras { get; set; }
    }
}
