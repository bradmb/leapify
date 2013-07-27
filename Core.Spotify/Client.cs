using Core.Spotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spotify
{
    public class Client
    {
        private Application _app;

        public bool IsRunning { get { return _app != null && _app.IsRunning; } }

        public Client()
        {
            _app = new Application();
        }

        public AppPointerResult Initalize()
        {
            return _app.Initialize();
        }

        public bool PlayPause()
        {
            return _app.Command(SpotifyAction.PlayPause);
        }

        public bool Stop()
        {
            return _app.Command(SpotifyAction.Stop);
        }

        public bool PreviousTrack()
        {
            return _app.Command(SpotifyAction.PreviousTrack);
        }

        public bool NextTrack()
        {
            return _app.Command(SpotifyAction.NextTrack);
        }

        public bool VolumeUp()
        {
            return _app.Command(SpotifyAction.VolumeUp);
        }

        public bool VolumeDown()
        {
            return _app.Command(SpotifyAction.VolumeDown);
        }

        public bool Mute()
        {
            return _app.Command(SpotifyAction.Mute);
        }
    }
}
