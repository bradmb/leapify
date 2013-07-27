using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spotify.Models
{
    /// <remarks>
    /// Thanks to "Sypher" for the information!
    /// http://stackoverflow.com/a/8461181
    /// </remarks>
    /// <summary>
    /// Provides the command required to tell Spotify what to do
    /// </summary>
    public enum SpotifyAction : long
    {
        PlayPause = 917504,
        Mute = 524288,
        VolumeDown = 589824,
        VolumeUp = 655360,
        Stop = 851968,
        PreviousTrack = 786432,
        NextTrack = 720896
    }
}
