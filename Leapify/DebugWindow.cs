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
            _leap.Gesture.OnMessage += Gesture_OnMessage;
        }

        void Gesture_OnMessage(object source, string message)
        {
            txtLeapMessages.AppendText(message);
        }

        private void spotifyCheck_Tick(object sender, EventArgs e)
        {
            lblSpotifyStatus.Text = _spotify.IsRunning ? "Running" : "Not Running";
        }

        private void leapMotionCheck_Tick(object sender, EventArgs e)
        {
            lblLeapStatus.Text = _leap.IsConnected ? "Connected" : "Disconnected";
        }
    }
}