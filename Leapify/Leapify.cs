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

        public Leapify()
        {
            _tray = new NotifyIcon();
        }

        private void DisplayTrayIcon()
        {
            _tray.Icon = Images.LeapifyIcon;
            _tray.Text = "Leapify";
            _tray.Visible = true;

            var trayMenu = new Menu();
            _tray.ContextMenuStrip = trayMenu.Render();
            _tray.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
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
            _leap.Gesture.OnLeapConnection +=Gesture_OnLeapConnection;

            _leap.Gesture.OnSwipeLeft += Gesture_OnSwipeLeft;
            _leap.Gesture.OnSwipeRight += Gesture_OnSwipeRight;
            _leap.Gesture.OnScreenTap += Gesture_OnScreenTap;
            _leap.Gesture.OnSwipeUp += Gesture_OnSwipeUp;
            _leap.Gesture.OnSwipeDown += Gesture_OnSwipeDown;
            _leap.Gesture.OnCircleClockwise += Gesture_OnCircleClockwise;
            _leap.Gesture.OnCircleCounterclockwise += Gesture_OnCircleCounterclockwise;

            //spotifyCheck.Start();
            //leapMotionCheck.Start();

            //_tray.ContextMenuStrip.Items.Find("spotify", false).First().Text = "Speeeeeetify!";

            #if DEBUG
            this.BindDebugWindow();
            #endif
        }

        public void Stop()
        {
            _leap.Disconnect();
            this.Dispose();
        }

        #if DEBUG
        private void BindDebugWindow()
        {
            var debug = _tray.ContextMenuStrip.Items.Find("debugwindow", false).FirstOrDefault();

            if (debug == null)
            {
                return;
            }

            debug.Click += debug_Click;
        }

        void debug_Click(object sender, EventArgs e)
        {
            this.Stop();

            var debug = new DebugWindow();
            debug.Show();
        }
        #endif

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

        private void LoadSettingsIntoLeap()
        {
            //_leap.Gesture.SwipeFingersRequired = int.Parse();
            //_leap.Gesture.SwipeToolsRequired = int.Parse();
            //_leap.Gesture.TapFingersRequired = int.Parse();
            //_leap.Gesture.TapToolsRequired = int.Parse();
            //_leap.Gesture.DistanceRequired = int.Parse();
            //_leap.Gesture.SpeedRequired = int.Parse();
            //_leap.Gesture.TimeBeforeNextAction = int.Parse();
        }

        void Gesture_OnLeapConnection()
        {
            LoadSettingsIntoLeap();
        }

        public void Dispose()
        {
            _tray.Dispose();
        }
    }
}
