using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spotify
{
    /// <remarks>
    /// Thanks to "Sypher" for the information!
    /// http://stackoverflow.com/a/8461181
    /// </remarks>
    internal static class Win32
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        internal static class Constants
        {
            internal const uint WM_APPCOMMAND = 0x0319;
        }
    }
}
