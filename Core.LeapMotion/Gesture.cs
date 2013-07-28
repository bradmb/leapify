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
        #if DEBUG
        public event LeapMessageHandler OnMessage;
        #endif

        #region Public Access Variables
        public event LeapActionHandler OnSwipeLeft;

        public event LeapActionHandler OnSwipeRight;

        public event LeapActionHandler OnSwipeUp;

        public event LeapActionHandler OnSwipeDown;

        public event LeapActionHandler OnScreenTap;

        public event LeapActionHandler OnLeapConnection;

        public int SwipeFingersRequired { get; set; }

        public int TapFingersRequired { get; set; }

        public int SwipeToolsRequired { get; set; }

        public int TapToolsRequired { get; set; }

        public int DistanceRequired { get; set; }

        public int SpeedRequired { get; set; }

        public int TimeBeforeNextAction { get; set; }
        #endregion

        #region Action Tracking Variables
        private bool _currentlyTracking;
        private int _currentActionFingers;
        private int _currentActionTools;
        #endregion

        #region System Variables
        private int _visibleFingers;
        private int _visibleTools;
        private DateTime _lastGestureEvent;
        #endregion

        #if DEBUG
        private void SendDebugMessage(string message)
        {
            if (OnMessage != null)
            {
                OnMessage(message);
            }
        }

        public override void OnInit(Controller controller)
        {
            SendDebugMessage("Initialized");
        }
        #endif

        public override void OnConnect(Controller controller)
        {
            if (OnLeapConnection != null)
            {
                OnLeapConnection();
            }
            controller.SetPolicyFlags(Controller.PolicyFlag.POLICYBACKGROUNDFRAMES);
            controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
            controller.EnableGesture(Gesture.GestureType.TYPESWIPE);

            #if DEBUG
            SendDebugMessage("Connected");
            #endif

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

            _visibleFingers = frame.Fingers.Count();
            _visibleTools = frame.Tools.Count();

            #if DEBUG
            SendDebugMessage("Fingers: " + _visibleFingers);
            SendDebugMessage("Tools: " + _visibleTools);
            #endif
            
            var trackedGest = gestures;

            if (!trackedGest.Any() || _lastGestureEvent > DateTime.Now.AddMilliseconds(TimeBeforeNextAction))
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
                case Gesture.GestureType.TYPESCREENTAP:
                    var screenTap = new ScreenTapGesture(thisGesture);
                    ProcessScreenTap(screenTap);
                    break;
                case Gesture.GestureType.TYPEKEYTAP:
                    var keyTap = new KeyTapGesture(thisGesture);
                    ProcessKeyTap(keyTap);
                    break;
                case Gesture.GestureType.TYPECIRCLE:
                    var circle = new CircleGesture(thisGesture);
                    ProcessCirlcle(circle);
                    break;
            }
        }

        private void ProcessCirlcle(CircleGesture circle)
        {
        }

        private void ProcessScreenTap(ScreenTapGesture tap)
        {
            if (_visibleFingers != TapFingersRequired)
            {
                #if DEBUG
                SendDebugMessage("Screen Tap -- invalid finger count: " + _visibleFingers);
                #endif
                    
                return;
            }
            else if (_visibleTools != TapToolsRequired)
            {
                #if DEBUG
                SendDebugMessage("Screen Tap -- invalid tool count: " + _visibleTools);
                #endif
                    
                return;
            }

            if (OnScreenTap != null)
            {
                OnScreenTap();
            }

            #if DEBUG
            SendDebugMessage(string.Format("Screen Tap (x:{0} y:{1} dur:{2})",
                tap.Direction.x,
                tap.Direction.y,
                tap.DurationSeconds
            ));
            #endif

            _lastGestureEvent = DateTime.Now;
        }

        private void ProcessKeyTap(KeyTapGesture tap)
        {
            if (_visibleFingers != TapFingersRequired)
            {
                #if DEBUG
                SendDebugMessage("Key Tap -- invalid finger count: " + _visibleFingers);
                #endif
                    
                return;
            }
            else if (_visibleTools != TapToolsRequired)
            {
                #if DEBUG
                SendDebugMessage("Key Tap -- invalid tool count: " + _visibleTools);
                #endif
                    
                return;
            }
            if (OnScreenTap != null)
            {
                OnScreenTap();
            }

            #if DEBUG
            SendDebugMessage(string.Format("Key Tap (x:{0} y:{1} dur:{2})",
                tap.Direction.x,
                tap.Direction.y,
                tap.DurationSeconds
            ));
            #endif

            _lastGestureEvent = DateTime.Now;
        }

        private void ProcessSwipe(SwipeGesture swipe)
        {
            if (swipe.State == Gesture.GestureState.STATESTART && !_currentlyTracking)
            {
                _currentlyTracking = true;
                _currentActionFingers = 0;
                _currentActionTools = 0;

                #if DEBUG
                SendDebugMessage(string.Format("Swipe Start (posX:{0} posY:{1} fing:{2} tool:{3})", swipe.Position.x, swipe.Position.y, _visibleFingers, _visibleTools));
                #endif
            }
            else if (swipe.State == Gesture.GestureState.STATESTOP && _currentlyTracking)
            {
                _currentlyTracking = false;

                if (_currentActionFingers != SwipeFingersRequired)
                {
                    #if DEBUG
                    SendDebugMessage("Swipe Stop -- invalid finger count");
                    #endif
                    
                    return;
                }
                else if (_currentActionTools != SwipeToolsRequired)
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


                if (swipe.Position.x < 0 && swipe.Direction.y > -0.5 && swipe.Direction.y < 0.5 && OnSwipeLeft != null)
                {
                    OnSwipeLeft();
                }
                else if (swipe.Position.x > 0 && swipe.Direction.y > -0.5 && swipe.Direction.y < 0.5 && OnSwipeRight != null)
                {
                    OnSwipeRight();
                }
                else if (swipe.Direction.y > 0.7 && OnSwipeUp != null)
                {
                    OnSwipeUp();
                }
                else if (swipe.Direction.y < -0.7 && OnSwipeDown != null)
                {
                    OnSwipeDown();
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
            else if (swipe.State == Gesture.GestureState.STATEUPDATE && _currentlyTracking)
            {
                if (_currentActionFingers < _visibleFingers)
                {
                    _currentActionFingers = _visibleFingers;
                }

                if (_currentActionTools < _visibleTools)
                {
                    _currentActionTools = _visibleTools;
                }
            }
        }
    }
}
