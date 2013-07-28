using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapify
{
    public partial class Leapify
    {
        void Gesture_OnMessage(string message)
        {
            //_tray.ShowBalloonTip(1000, "Leapify", message, ToolTipIcon.Info);
        }

        void Gesture_OnCircleCounterclockwise()
        {
            _spotify.VolumeDown();
        }

        void Gesture_OnCircleClockwise()
        {
            _spotify.VolumeUp();
        }

        void Gesture_OnSwipeDown()
        {
            _spotify.VolumeDown();
        }

        void Gesture_OnSwipeUp()
        {
            _spotify.VolumeUp();
        }

        void Gesture_OnScreenTap()
        {
            _spotify.PlayPause();
        }

        void Gesture_OnSwipeRight()
        {
            if (_spotify.IsRunning)
            {
                _spotify.NextTrack();
            }
        }

        void Gesture_OnSwipeLeft()
        {
            if (_spotify.IsRunning)
            {
                _spotify.PreviousTrack();
            }
        }
    }
}
