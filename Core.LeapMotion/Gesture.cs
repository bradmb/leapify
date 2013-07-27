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
        private bool currentlyTracking;
        private Gesture.GestureState _lastGesture;
        private DateTime _lastGestureEvent;
        private Object thisLock = new Object();
        #endregion

        private void SendDebugMessage(object sender, string message)
        {
            if (OnMessage != null)
            {
                OnMessage(sender, message);
            }
        }

        #if DEBUG
        public override void OnInit(Controller controller)
        {
            SendDebugMessage(this, "Initialized");
        }
        #endif

        public override void OnConnect(Controller controller)
        {
            #if DEBUG
            SendDebugMessage(this, "Connected");
            #endif

            controller.SetPolicyFlags(Controller.PolicyFlag.POLICYBACKGROUNDFRAMES);
            //controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
            //controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
        }

        #if DEBUG
        public override void OnDisconnect(Controller controller)
        {
            SendDebugMessage(this, "Disconnected");
        }
        #endif

        #if DEBUG
        public override void OnExit(Controller controller)
        {
            SendDebugMessage(this, "Exited");
        }
        #endif

        public override void OnFrame(Controller controller)
        {
            var frame = controller.Frame();
            var gestures = frame.Gestures();

            var fingers = frame.Fingers.Count();
            var tools = frame.Tools.Count();

            #if DEBUG
            SendDebugMessage(this, "Fingers: " + fingers);
            SendDebugMessage(this, "Tools: " + tools);
            #endif
            
            var trackedGest = gestures.Where(ges => ges.State == Gesture.GestureState.STATESTART || ges.State == Gesture.GestureState.STATESTOP);

            if (!trackedGest.Any())
            {
                return;
            }

            var thisGesture = trackedGest.First();

            switch (thisGesture.Type)
            {
                case Gesture.GestureType.TYPESWIPE:
                    var swipe = new SwipeGesture(thisGesture);

                    if (swipe.State == Gesture.GestureState.STATESTART && !currentlyTracking)
                    {
                        currentlyTracking = true;

                        #if DEBUG
                        SendDebugMessage(this, "Swipe Start");
                        #endif
                    }
                    else if (swipe.State == Gesture.GestureState.STATESTOP && currentlyTracking)
                    {
                        currentlyTracking = false;

                        #if DEBUG
                        SendDebugMessage(this, string.Format("Swipe Stop (x:{0} y:{1} dur:{2})", swipe.Direction.x, swipe.Direction.y, swipe.DurationSeconds));
                        #endif
                    }
                    break;
            }
        }
    }
}
