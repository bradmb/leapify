using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapify
{
    public partial class Leapify
    {
        async void Gesture_OnLeapConnection()
        {
            await this.LoadSettingsIntoLeap();

            if (_spotify.IsRunning && !_isPaused)
            {
                _tray.ShowBalloonTip(100, "Leapify", "Ready for gestures!", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        private async Task LoadSettingsIntoLeap()
        {
            var settingsFile = new LeapifySettings();
            var settings = await settingsFile.Read();

            _leap.Gesture.SwipeFingersRequired = settings.SwipeFingersRequired;
            _leap.Gesture.SwipeToolsRequired = settings.SwipeToolsRequired;
            _leap.Gesture.TapFingersRequired = settings.TapFingersRequired;
            _leap.Gesture.TapToolsRequired = settings.TapToolsRequired;
            _leap.Gesture.DistanceRequired = settings.DistanceRequired;
            _leap.Gesture.SpeedRequired = settings.SpeedRequired;
            _leap.Gesture.TimeBeforeNextAction = settings.TimeBeforeNextAction;

            _volumeSpeedIncrease = settings.VolumeSpeedIncrease;
        }

        void Gesture_OnLeapDisconnection()
        {
            _tray.ShowBalloonTip(100, "Leapify", "Leap Motion has disconnected", System.Windows.Forms.ToolTipIcon.Info);
        }

        void Gesture_OnCircleCounterclockwise()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                for (int curVol = 0; curVol < _volumeSpeedIncrease; curVol++)
                {
                    _spotify.VolumeDown();
                }
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        void Gesture_OnCircleClockwise()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                for (int curVol = 0; curVol < _volumeSpeedIncrease; curVol++)
                {
                    _spotify.VolumeUp();
                }
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        void Gesture_OnSwipeDown()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                for (int curVol = 0; curVol < _volumeSpeedIncrease; curVol++)
                {
                    _spotify.VolumeDown();
                }
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        void Gesture_OnSwipeUp()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                for (int curVol = 0; curVol < _volumeSpeedIncrease; curVol++)
                {
                    _spotify.VolumeUp();
                }
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        void Gesture_OnScreenTap()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                _spotify.PlayPause();
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        void Gesture_OnSwipeRight()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                _spotify.NextTrack();
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }

        void Gesture_OnSwipeLeft()
        {
            if (_isPaused)
            {
                return;
            }

            if (_spotify.IsRunning)
            {
                _spotify.PreviousTrack();
            }
            else
            {
                _tray.ShowBalloonTip(100, "Leapify", "Spotify is not running", System.Windows.Forms.ToolTipIcon.Info);
            }
        }
    }
}
