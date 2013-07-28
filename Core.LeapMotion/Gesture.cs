using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LeapMotion
{
    public delegate void LeapMessageHandler(string message);

    public delegate void LeapActionHandler();

    public class GestureListener : Listener
    {
        public event LeapMessageHandler OnMessage;

        public event LeapActionHandler OnSwipeLeft;

        public event LeapActionHandler OnSwipeRight;

        public int FingersRequired { get; set; }

        public int ToolsRequired { get; set; }

        public int DistanceRequired { get; set; }

        public int SpeedRequired { get; set; }

        public int TimeBeforeNextAction { get; set; }

        #region Action Tracking Variables
        private bool currentlyTracking;
        private int currentActionFingers;
        private int currentActionTools;
        #endregion

        #region System Variables
        private int visibleFingers;
        private int visibleTools;
        private DateTime _lastGestureEvent;
        private Object thisLock = new Object();
        #endregion

        private void SendDebugMessage(string message)
        {
            if (OnMessage != null)
            {
                OnMessage(message);
            }
        }

        #if DEBUG
        public override void OnInit(Controller controller)
        {
            SendDebugMessage("Initialized");
        }
        #endif

        public override void OnConnect(Controller controller)
        {
            #if DEBUG
            SendDebugMessage("Connected");
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
            SendDebugMessage("Disconnected");
        }
        #endif

        #if DEBUG
        public override void OnExit(Controller controller)
        {
            SendDebugMessage("Exited");
        }
        #endif

        public override void OnFrame(Controller controller)
        {
            var frame = controller.Frame();
            var gestures = frame.Gestures();

            visibleFingers = frame.Fingers.Count();
            visibleTools = frame.Tools.Count();

            #if DEBUG
            SendDebugMessage("Fingers: " + visibleFingers);
            SendDebugMessage("Tools: " + visibleTools);
            #endif
            
            var trackedGest = gestures;

            if (!trackedGest.Any())
            {
                return;
            }

            var thisGesture = trackedGest.First();

            switch (thisGesture.Type)
            {
                case Gesture.GestureType.TYPESWIPE:
                    var swipe = new SwipeGesture(thisGesture);
                    ProcessSwipe(swipe);
                    break;
            }
        }

        private void ProcessSwipe(SwipeGesture swipe)
        {
            if (swipe.State == Gesture.GestureState.STATESTART && !currentlyTracking && _lastGestureEvent < DateTime.Now.AddMilliseconds(-TimeBeforeNextAction))
            {
                currentlyTracking = true;
                currentActionFingers = 0;

                #if DEBUG
                SendDebugMessage(string.Format("Swipe Start (posX:{0} posY:{1} fing:{2} tool:{3})", swipe.Position.x, swipe.Position.y, visibleFingers, visibleTools));
                #endif
            }
            else if (swipe.State == Gesture.GestureState.STATESTOP && currentlyTracking)
            {
                currentlyTracking = false;

                if (currentActionFingers != FingersRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- invalid finger count");
                    #endif
                    
                    return;
                }
                else if (currentActionTools != ToolsRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- invalid tool count");
                    #endif
                    
                    return;
                } else if (swipe.Speed < SpeedRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- speed too low");
                    #endif
                    
                    return;
                } else if (swipe.StartPosition.DistanceTo(swipe.Position) < DistanceRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- distance too low");
                    #endif
                    
                    return;
                }


                if (swipe.Position.x < 0 && OnSwipeLeft != null)
                {
                    OnSwipeLeft();
                } else if (swipe.Position.x > 0 && OnSwipeRight != null)
                {
                    OnSwipeRight();
                }

                #if DEBUG
                SendDebugMessage(string.Format("Swipe Stop (x:{0} y:{1} dur:{2} dist:{3} speed:{4})",
                    swipe.Direction.x,
                    swipe.Direction.y,
                    swipe.DurationSeconds,
                    swipe.StartPosition.DistanceTo(swipe.Position),
                    swipe.Speed
                ));
                #endif

                _lastGestureEvent = DateTime.Now;
            }
            else if (swipe.State == Gesture.GestureState.STATEUPDATE && currentlyTracking)
            {
                if (currentActionFingers < visibleFingers)
                {
                    currentActionFingers = visibleFingers;
                }

                if (currentActionTools < visibleTools)
                {
                    currentActionTools = visibleTools;
                }
            }
        }
    }
}
