using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LeapMotion
{
    public class Leap
    {
        public GestureListener Gesture;

        public bool IsConnected { get { return _leap.IsConnected; } }

        private Controller _leap;

        public Leap()
        {
            _leap = new Controller();

            Gesture = new GestureListener();
            _leap.AddListener(Gesture);
        }
    }
}
