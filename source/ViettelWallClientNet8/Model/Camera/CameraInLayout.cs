using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViettelWallClientNet8.Model.Camera
{
    public class CameraInLayout
    {
        public required string cameraName { get; set; }
        public required string cameraLink { get; set; }
        public required int xIndex { get; set; }
        public required int yIndex { get; set; }
    }
}
