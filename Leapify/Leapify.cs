using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leapify
{
    public partial class Leapify : IDisposable
    {
        NotifyIcon _tray;
        private Core.Spotify.Client _spotify;
        private Core.LeapMotion.Leap _leap;
        private bool _isPaused = false;
        private int _volumeSpeedIncrease = 1;

        public Leapify()
        {
            _tray = new NotifyIcon();
        }

        private void DisplayTrayIcon()
        {
            _tray.Icon = Images.leapify_active;
            _tray.Text = "Leapify";
            _tray.Visible = true;

            _tray.MouseClick += _tray_MouseClick;
            _tray.ContextMenuStrip = this.RenderMenu();
            _tray.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
        }

        void _tray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (_isPaused)
            {
                _tray.Text = "Leapify";
                _isPaused = false;
                _tray.Icon = Images.leapify_active;
                return;
            }

            _tray.Text = "Leapify [PAUSED]";
            _isPaused = true;
            _tray.Icon = Images.leapify_paused;
        }

        void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateSpotifyStatus();
            UpdateLeapStatus();
        }

        public void Start()
        {
            this.DisplayTrayIcon();

            _spotify = new Core.Spotify.Client();
            _spotify.Initalize();

            _leap = new Core.LeapMotion.Leap();
            _leap.Gesture.OnLeapConnection += Gesture_OnLeapConnection;
            _leap.Gesture.OnLeapDisconnection += Gesture_OnLeapDisconnection;

            _leap.Gesture.OnSwipeLeft += Gesture_OnSwipeLeft;
            _leap.Gesture.OnSwipeRight += Gesture_OnSwipeRight;
            _leap.Gesture.OnScreenTap += Gesture_OnScreenTap;
            _leap.Gesture.OnSwipeUp += Gesture_OnSwipeUp;
            _leap.Gesture.OnSwipeDown += Gesture_OnSwipeDown;
            _leap.Gesture.OnCircleClockwise += Gesture_OnCircleClockwise;
            _leap.Gesture.OnCircleCounterclockwise += Gesture_OnCircleCounterclockwise;

            #if DEBUG
            this.BindDebugWindow();
            #endif
        }

        public void Stop()
        {
            _leap.Disconnect();
            this.Dispose();
        }

        private void UpdateSpotifyStatus()
        {
            var spotifyItem = _tray.ContextMenuStrip.Items.Find("spotify", false).FirstOrDefault();

            if (spotifyItem == null)
            {
                return;
            }

            spotifyItem.Text = _spotify.IsRunning ? "Spotify: Running" : "Spotify: Not Running";
        }

        private void UpdateLeapStatus()
        {
            var leapItem = _tray.ContextMenuStrip.Items.Find("leapmotion", false).FirstOrDefault();

            if (leapItem == null)
            {
                return;
            }

            leapItem.Text = _leap.IsConnected ? "Leap Motion: Connected" : "Leap Motion: Disconnected";
        }

        public void Dispose()
        {
            _tray.Dispose();
        }
    }
}
