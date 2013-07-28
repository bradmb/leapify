using Core.LeapMotion.Gestures;
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
        public GestureController Gesture;

        public bool IsConnected { get { return _leap.IsConnected; } }

        private Controller _leap;

        public Leap()
        {
            _leap = new Controller();

            Gesture = new GestureController();
            _leap.AddListener(Gesture);
        }

        public void Disconnect()
        {
            _leap.RemoveListener(Gesture);
            _leap.Dispose();
        }
    }
}
