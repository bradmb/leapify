using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spotify.Models
{
    public class AppPointer
    {
        public IntPtr ApplicationPointer { get; set; }

        public AppPointerResult Result { get; set; }
    }

    public enum AppPointerResult
    {
        Found,
        NotFound
    }
}
