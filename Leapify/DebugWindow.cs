using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leapify
{
    public partial class DebugWindow : Form
    {
        private Core.Spotify.Client _spotify;

        private Core.LeapMotion.Leap _leap;

        public DebugWindow()
        {
            InitializeComponent();

            _spotify = new Core.Spotify.Client();
            _spotify.Initalize();

            _leap = new Core.LeapMotion.Leap();
            _leap.Gesture.OnLeapConnection += Gesture_OnLeapConnection;

            _leap.Gesture.OnSwipeLeft += Gesture_OnSwipeLeft;
            _leap.Gesture.OnSwipeRight += Gesture_OnSwipeRight;
            _leap.Gesture.OnScreenTap += Gesture_OnScreenTap;
            _leap.Gesture.OnSwipeUp += Gesture_OnSwipeUp;
            _leap.Gesture.OnSwipeDown += Gesture_OnSwipeDown;
            _leap.Gesture.OnCircleClockwise += Gesture_OnCircleClockwise;
            _leap.Gesture.OnCircleCounterclockwise += Gesture_OnCircleCounterclockwise;

            spotifyCheck.Start();
            leapMotionCheck.Start();

            LoadSettingsIntoLeap();

            #if DEBUG
            _leap.Gesture.OnMessage += Gesture_OnMessage;
            #endif
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

        void Gesture_OnLeapConnection()
        {
            LoadSettingsIntoLeap();
        }

        private void LoadSettingsIntoLeap()
        {
            _leap.Gesture.SwipeFingersRequired = int.Parse(txtRequiredFingersSwipe.Text);
            _leap.Gesture.SwipeToolsRequired = int.Parse(txtRequiredToolsSwipe.Text);
            _leap.Gesture.TapFingersRequired = int.Parse(txtRequiredFingersTap.Text);
            _leap.Gesture.TapToolsRequired = int.Parse(txtRequiredToolsTap.Text);
            _leap.Gesture.DistanceRequired = int.Parse(txtMinDistance.Text);
            _leap.Gesture.SpeedRequired = int.Parse(txtMinSpeed.Text);
            _leap.Gesture.TimeBeforeNextAction = int.Parse(txtTimeBetween.Text);
        }

        void Gesture_OnSwipeRight()
        {
            if (_spotify.IsRunning)
            {
                _spotify.NextTrack();
            }
            else
            {
                MessageBox.Show("No Spotify, no change");
            }
        }

        void Gesture_OnSwipeLeft()
        {
            if (_spotify.IsRunning)
            {
                _spotify.PreviousTrack();
            }
            else
            {
                MessageBox.Show("No Spotify, no change");
            }
        }

        void Gesture_OnMessage(string message)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    if (message.Contains("Fingers:"))
                    {
                        lblLeapFingersValue.Text = message.Remove(0, 9);
                    }
                    else if (message.Contains("Tools:"))
                    {
                        lblLeapToolsValue.Text = message.Remove(0, 7);
                    }
                    else if (message.Contains("Hands:"))
                    {
                        lblLeapHandsValue.Text = message.Remove(0, 7);
                    }
                    else
                    {
                        txtLeapMessages.AppendText(message + Environment.NewLine);
                    }
                });
            }
            catch (ObjectDisposedException)
            {
                // App just shutting down, no big deal
            }
        }

        private void spotifyCheck_Tick(object sender, EventArgs e)
        {
            lblSpotifyStatus.Text = _spotify.IsRunning ? "Running" : "Not Running";
        }

        private void leapMotionCheck_Tick(object sender, EventArgs e)
        {
            lblLeapStatus.Text = _leap.IsConnected ? "Connected" : "Disconnected";
        }

        private void DebugWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            spotifyCheck.Stop();
            leapMotionCheck.Stop();

            _leap.Gesture.OnSwipeLeft -= Gesture_OnSwipeLeft;
            _leap.Gesture.OnSwipeRight -= Gesture_OnSwipeRight;

            #if DEBUG
            _leap.Gesture.OnMessage -= Gesture_OnMessage;
            #endif
        }

        private void txtRequiredFingers_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void txtRequiredTools_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void txtMinSpeed_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void txtMinDistance_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void txtTimeBetween_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void txtRequiredFingersTap_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void txtRequiredToolsTap_TextChanged(object sender, EventArgs e)
        {
            LoadSettingsIntoLeap();
        }

        private void DebugWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {
            this.Icon = Images.LeapifyIcon;
        }
    }
}