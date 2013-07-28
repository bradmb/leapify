using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LeapMotion.Gestures
{
    public partial class GestureController
    {
        private void ProcessScreenTap(ScreenTapGesture tap)
        {
            if (_visibleHands > 1)
            {
                return;
            }

            if (_visibleFingers != TapFingersRequired)
            {
                #if DEBUG
                SendDebugMessage("Screen Tap -- invalid finger count: " + _visibleFingers);
                #endif
                    
                return;
            }
            else if (_visibleTools != TapToolsRequired)
            {
                #if DEBUG
                SendDebugMessage("Screen Tap -- invalid tool count: " + _visibleTools);
                #endif
                    
                return;
            }

            if (OnScreenTap != null)
            {
                OnScreenTap();
            }

            #if DEBUG
            SendDebugMessage(string.Format("Screen Tap (x:{0} y:{1} dur:{2})",
                tap.Direction.x,
                tap.Direction.y,
                tap.DurationSeconds
            ));
            #endif

            _lastGestureEvent = DateTime.Now;
        }

        private void ProcessKeyTap(KeyTapGesture tap)
        {
            if (_visibleFingers != TapFingersRequired)
            {
                #if DEBUG
                SendDebugMessage("Key Tap -- invalid finger count: " + _visibleFingers);
                #endif
                    
                return;
            }
            else if (_visibleTools != TapToolsRequired)
            {
                #if DEBUG
                SendDebugMessage("Key Tap -- invalid tool count: " + _visibleTools);
                #endif
                    
                return;
            }
            if (OnScreenTap != null)
            {
                OnScreenTap();
            }

            #if DEBUG
            SendDebugMessage(string.Format("Key Tap (x:{0} y:{1} dur:{2})",
                tap.Direction.x,
                tap.Direction.y,
                tap.DurationSeconds
            ));
            #endif

            _lastGestureEvent = DateTime.Now;
        }
    }
}
