using Core.Spotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spotify
{
    public class Application
    {
        public bool IsInitalized { get { return _spotify != null; } }

        public bool IsRunning { get { return GetPointer() != null; } }

        private IntPtr _spotify;

        /// <summary>
        /// Searches for the Spotify main window and, if found, allows for communication with it
        /// </summary>
        /// <returns>Returne the search status result (found/not found)</returns>
        internal AppPointerResult Initialize()
        {
            var window = GetPointer();

            if (window == null)
            {
                return AppPointerResult.NotFound;
            }

            _spotify = window;
            return AppPointerResult.Found;
        }

        private IntPtr GetPointer()
        {
            return Win32.FindWindow("SpotifyMainWindow", null);
        }

        /// <summary>
        /// Sends a command to Spotify
        /// </summary>
        /// <param name="action">The command to send</param>
        internal bool Command(SpotifyAction action)
        {
            if (!IsInitalized)
            {
                return false;
            }

            Win32.SendMessage(_spotify, Win32.Constants.WM_APPCOMMAND, IntPtr.Zero, new IntPtr((long)action));
            return true;
        }
    }
}
