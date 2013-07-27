using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LeapMotion
{
    public delegate void LeapMessageHandler(object source, string message);

    public class GestureListener : Listener
    {
        public event LeapMessageHandler OnMessage;

        public int FingersRequired { get; set; }

        public int ToolsRequired { get; set; }

        public int DistanceRequired { get; set; }

        #region Internal Variables
        private Gesture.GestureState _lastGesture;
        private DateTime _lastGestureEvent;
        private Object thisLock = new Object();
        #endregion

        public override void OnInit(Controller controller)
        {
            OnMessage(this, "Initialized");
        }

        public override void OnConnect(Controller controller)
        {
            OnMessage(this, "Connected");

            controller.SetPolicyFlags(Controller.PolicyFlag.POLICYBACKGROUNDFRAMES);
            //controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
            //controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
        }

        public override void OnDisconnect(Controller controller)
        {
            //Note: not dispatched when running in a debugger.
            OnMessage(this, "Disconnected");
        }

        public override void OnExit(Controller controller)
        {
            OnMessage(this, "Exited");
        }

        public override void OnFrame(Controller controller)
        {
            var frame = controller.Frame();
            var gestures = frame.Gestures();

            foreach (var g in gestures.Where(ges => ges.State == Gesture.GestureState.STATESTART || ges.State == Gesture.GestureState.STATESTOP))
            {
                switch (g.Type)
                {
                    case Gesture.GestureType.TYPESWIPE:
                        if (g.State == Gesture.GestureState.STATESTART) {
                            OnMessage(this, "Swipe Start");
                        } else if (g.State == Gesture.GestureState.STATESTOP) {
                            OnMessage(this, "Swipe Stop");
                        }
                        break;
                }
            }
        }
    }
}
