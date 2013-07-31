using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapify.Models
{
    public class Settings
    {
        public string ConfigVersion { get; set; }

        public int SwipeFingersRequired { get; set; }

        public int SwipeToolsRequired { get; set; }
        
        public int TapFingersRequired { get; set; }
        
        public int TapToolsRequired { get; set; }
        
        public int DistanceRequired { get; set; }
        
        public int SpeedRequired { get; set; }
        
        public int TimeBeforeNextAction { get; set; }

        public int VolumeSpeedIncrease { get; set; }
    }
}
